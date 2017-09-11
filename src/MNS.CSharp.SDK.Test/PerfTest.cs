using Aliyun.MNS.Model;
using Aliyun.MNS.Runtime;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aliyun.MNS.PerfTest
{
    public class PerfTest
    {
        private const string _accessKeyId = "<your access key id>";
        private const string _secretAccessKey = "<your secret access key>";
        private const string _endpoint = "<valid endpoint>";

        private const string _queueName = "chsarpsdkqueue";

        private const int _threadCount = 5;
        private const int _totalTime = 1000;

        private static IMNS client = null;

        private const string REQUEST_COUNT_KEY = "RequestCount";
        private const string FAIL_COUNT_KEY = "FailCount";

        private const int SYNC_SEND_MESSAGE_TYPE = 0;
        private const int SYNC_RECEIVE_MESSAGE_TYPE = 1;
        private const int ASYNC_SEND_MESSAGE_TYPE = 2;
        private const int ASYNC_RECEIVE_MESSAGE_TYPE = 3;

        private static System.Object lockCount = new System.Object();
        private static int count = 0;

        static Dictionary<int, Dictionary<string, long>> _detailPerfData = new Dictionary<int, Dictionary<string, long>>();

        static Dictionary<string, long> MergePerfData(Dictionary<int, Dictionary<string, long>> perfData)
        {
            Dictionary<string, long> mergedPerfData = new Dictionary<string, long>();
            foreach (var threadId in perfData.Keys)
            {
                Dictionary<string, long> rawPerfData = perfData[threadId];
                foreach (var key in rawPerfData.Keys)
                {
                    if (mergedPerfData.ContainsKey(key))
                    {
                        mergedPerfData[key] += rawPerfData[key];
                    }
                    else
                    {
                        mergedPerfData[key] = rawPerfData[key];
                    }
                }
            }
            return mergedPerfData;
        }

        static void PrintPerfData(Dictionary<string, long> perfData)
        {
            foreach (var key in perfData.Keys)
            {
                Console.WriteLine(string.Format("{0} : {1}", key, perfData[key]));
            }
        }

        static void AsyncReceiveCallbackFunc(IAsyncResult ar)
        {
            try
            {
                Queue nativeQueue = (Queue)ar.AsyncState;
                nativeQueue.EndReceiveMessage(ar);
            }
            catch (Exception)
            {
                ;
            }
            lock(lockCount)
            {
                count -= 1;
            }
        }

        static void AsyncSendCallbackFunc(IAsyncResult ar)
        {
            try
            {
                Queue nativeQueue = (Queue)ar.AsyncState;
                nativeQueue.EndSendMessage(ar);
            }
            catch (Exception)
            {
                ;
            }
            lock (lockCount)
            {
                //Console.WriteLine("A" + count.ToString());
                count -= 1;
            }
        }

        static void AsyncTestThreadFunc(object typeObj)
        {
            int type = (int)typeObj;

            int threadId = Thread.CurrentThread.ManagedThreadId;
            var nativeQueue = client.GetNativeQueue(_queueName);

            _detailPerfData[threadId][FAIL_COUNT_KEY] = 0;

            long requestCount = 0;
            TimeSpan elapsed = new TimeSpan(0);

            while (true)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                try
                {
                    switch (type)
                    {
                        case ASYNC_SEND_MESSAGE_TYPE:
                            nativeQueue.BeginSendMessage(new SendMessageRequest("test"), AsyncSendCallbackFunc, nativeQueue);
                            break;
                        case ASYNC_RECEIVE_MESSAGE_TYPE:
                            nativeQueue.BeginReceiveMessage(new ReceiveMessageRequest(), AsyncReceiveCallbackFunc, nativeQueue);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _detailPerfData[threadId][FAIL_COUNT_KEY] += 1;

                    if (ex is AliyunServiceException)
                    {
                        string errorCode = ((AliyunServiceException)ex).ErrorCode;
                        if (errorCode != null)
                        {
                            Console.WriteLine(errorCode);
                            if (_detailPerfData[threadId].ContainsKey(errorCode))
                            {
                                _detailPerfData[threadId][errorCode] = 1;
                            }
                            else
                            {
                                _detailPerfData[threadId][errorCode] += 1;
                            }
                        }
                    }
                }
                stopWatch.Stop();
                elapsed += stopWatch.Elapsed;
                requestCount += 1;

                lock (lockCount)
                {
                    count += 1;
                }

                if (elapsed.TotalMilliseconds >= _totalTime)
                {
                    break;
                }
            }
            _detailPerfData[threadId][REQUEST_COUNT_KEY] = requestCount;
            while (true)
            {
                lock (lockCount)
                {
                    if (count <= 0)
                    {
                        break;
                    }
                }
            }
        }

        static void SyncTestThreadFunc(object typeObj)
        {
            int type = (int)typeObj;

            int threadId = Thread.CurrentThread.ManagedThreadId;
            var nativeQueue = client.GetNativeQueue(_queueName);

            _detailPerfData[threadId][FAIL_COUNT_KEY] = 0;

            long requestCount = 0;
            TimeSpan elapsed = new TimeSpan(0);

            while (true)
            {
                Stopwatch stopWatch = Stopwatch.StartNew();
                try
                {
                    switch (type)
                    {
                        case SYNC_SEND_MESSAGE_TYPE:
                            nativeQueue.SendMessage(new SendMessageRequest("test"));
                            break;
                        case SYNC_RECEIVE_MESSAGE_TYPE:
                            nativeQueue.ReceiveMessage(new ReceiveMessageRequest());
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _detailPerfData[threadId][FAIL_COUNT_KEY] += 1;

                    if (ex is AliyunServiceException)
                    {
                        string errorCode = ((AliyunServiceException)ex).ErrorCode;
                        if (errorCode != null)
                        {
                            Console.WriteLine(errorCode);
                            if (_detailPerfData[threadId].ContainsKey(errorCode))
                            {
                                _detailPerfData[threadId][errorCode] = 1;
                            }
                            else
                            {
                                _detailPerfData[threadId][errorCode] += 1;
                            }
                        }
                    }
                }
                stopWatch.Stop();

                elapsed += stopWatch.Elapsed;
                requestCount += 1;

                if (elapsed.TotalMilliseconds >= _totalTime)
                {
                    break;
                }
            }
            
            _detailPerfData[threadId][REQUEST_COUNT_KEY] = requestCount;
        }

        static void SyncSendMessagePerfTest()
        {
            DoPerfTest(SYNC_SEND_MESSAGE_TYPE);
        }

        static void SyncReceiveMessagePerfTest()
        {
            DoPerfTest(SYNC_RECEIVE_MESSAGE_TYPE);
        }

        static void AsyncSendMessagePerfTest()
        {
            DoPerfTest(ASYNC_SEND_MESSAGE_TYPE);
        }

        static void AsyncReceiveMessagePerfTest()
        {
            DoPerfTest(ASYNC_RECEIVE_MESSAGE_TYPE);
        }

        static void DoPerfTest(int type)
        {
            _detailPerfData.Clear();

            client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);

            var createQueueRequest = new CreateQueueRequest
            {
                QueueName = _queueName,
                Attributes =
                {
                    DelaySeconds = 0,
                    VisibilityTimeout = 30,
                    MaximumMessageSize = 40960,
                    MessageRetentionPeriod = 345600,
                    PollingWaitSeconds = 0
                }
            };

            try
            {
                var queue = client.CreateQueue(createQueueRequest);
                Console.WriteLine("Create queue successfully, queue name: {0}", queue.QueueName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create queue failed in SyncSendMessagePerfTest, exception info: " + ex.Message + ex.StackTrace);
                return;
            }

            Thread[] threads = new Thread[_threadCount];
            for (int i = 0; i < _threadCount; ++i)
            {
                Thread thread = null;
                switch (type)
                {
                    case SYNC_SEND_MESSAGE_TYPE:
                    case SYNC_RECEIVE_MESSAGE_TYPE:
                        thread = new Thread(new ParameterizedThreadStart(SyncTestThreadFunc));
                        break;
                    case ASYNC_SEND_MESSAGE_TYPE:
                    case ASYNC_RECEIVE_MESSAGE_TYPE:
                        thread = new Thread(new ParameterizedThreadStart(AsyncTestThreadFunc));
                        break;
                    default:
                        Console.WriteLine("UnknownType: " + type.ToString());
                        return;
                }
                _detailPerfData[thread.ManagedThreadId] = new Dictionary<string, long>();
                threads[i] = thread;
            }

            for (int i = 0; i < _threadCount; ++i)
            {
                threads[i].Start(type);
            }
            for (int i = 0; i < _threadCount; ++i)
            {
                threads[i].Join();
            }

            var perfData = MergePerfData(_detailPerfData);
            Console.WriteLine((perfData[REQUEST_COUNT_KEY]) / (_totalTime / 1000.0));

            PrintPerfData(perfData);
        }

        static void Main(string[] args)
        {
            Stopwatch sendMessagePerfWatch = Stopwatch.StartNew();
            DoPerfTest(SYNC_SEND_MESSAGE_TYPE);
            //DoPerfTest(SYNC_RECEIVE_MESSAGE_TYPE);
            //DoPerfTest(ASYNC_SEND_MESSAGE_TYPE);
            //DoPerfTest(ASYNC_RECEIVE_MESSAGE_TYPE);

            Console.ReadKey();
        }
    }
}