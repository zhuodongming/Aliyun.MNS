using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aliyun.MNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.MNS.Model;
using Aliyun.MNS.Util;
using System.Globalization;

namespace Aliyun.MNS.Tests
{
    [TestClass()]
    public class QueueTests
    {
        private const string _accessKeyId = "<your access key id>";
        private const string _secretAccessKey = "<your secret access key>";
        private const string _endpoint = "<valid endpoint>";

        private IMNS client;

        public static string CalculateMD5(string message)
        {
            var messageBytes = Encoding.UTF8.GetBytes(message);
            return CalculateMD5(messageBytes);
        }

        public static string CalculateMD5(byte[] bytes)
        {
            var md5Hash = CryptoUtilFactory.CryptoInstance.ComputeMD5Hash(bytes);
            var calculatedMd5 = BitConverter.ToString(md5Hash).Replace("-", string.Empty).ToLower(CultureInfo.InvariantCulture);
            return calculatedMd5;
        }

        [TestInitialize()]
        public void SetUp()
        {
            client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            client.CreateQueue("UTQueue");
            try
            {
                client.DeleteQueue("UTQueue2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [TestMethod()]
        public void SendDelaySecondsMessageTest()
        {
            Queue queue = client.GetNativeQueue("UTQueue");

            string messageBody = "test";
            string md5 = CalculateMD5(messageBody);
            var resp = queue.SendMessage(messageBody, 10, 8);
            Assert.AreEqual(resp.MessageBodyMD5.ToUpper(), md5.ToUpper());
        }

        [TestMethod()]
        public void SetAttributesTest()
        {
            Queue queue = client.GetNativeQueue("UTQueue");

            var resp = queue.GetAttributes();
            var originalLoggingEnabled = resp.Attributes.LoggingEnabled;

            QueueAttributes qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(originalLoggingEnabled, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = false };
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = true };
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes();
            queue.SetAttributes(qa);
            resp = queue.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new QueueAttributes() { LoggingEnabled = true };
            var req = new CreateQueueRequest() { QueueName = "UTQueue2", Attributes = qa };
            Queue queue2 = client.CreateQueue(req);
            resp = queue2.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            client.DeleteQueue("UTQueue2");

            qa = new QueueAttributes() { LoggingEnabled = false };
            req = new CreateQueueRequest() { QueueName = "UTQueue2", Attributes = qa };
            queue2 = client.CreateQueue(req);
            resp = queue2.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);
        }

        [TestCleanup()]
        public void CleanUp()
        {
            client.DeleteQueue("UTQueue");
            try
            {
                client.DeleteQueue("UTQueue2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}