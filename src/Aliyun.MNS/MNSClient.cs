/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Internal;
using Aliyun.MNS.Model;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Runtime.Internal.Auth;
using Aliyun.MNS.Runtime.Pipeline;
using Aliyun.MNS.Runtime.Pipeline.Handlers;

namespace Aliyun.MNS
{
    /// <summary>
    /// Implementation for accessing MNS
    /// </summary>
    public partial class MNSClient : AliyunServiceClient, IMNS
    {
        #region Constructors

        /// <summary>
        /// Constructs MNSClient with Aliyun Service Credentials.
        /// </summary>
        /// <param name="credentials">Aliyun Service Credentials</param>
        /// <param name="regionEndpoint">The region endpoint to connect.</param>
        public MNSClient(ServiceCredentials credentials, String regionEndpoint)
            : this(credentials, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) })
        {
        }

        /// <summary>
        /// Constructs MNSClient with Aliyun Service Credentials and an
        /// MNSClient Configuration object.
        /// </summary>
        /// <param name="credentials">Aliyun Service Credentials</param>
        /// <param name="clientConfig">The MNSClient Configuration Object</param>
        public MNSClient(ServiceCredentials credentials, MNSConfig clientConfig)
            : base(credentials, clientConfig)
        {
        }

        /// <summary>
        /// Constructs MNSClient with Aliyun Access Key ID and Aliyun Secret Key
        /// </summary>
        /// <param name="accessKeyId">Aliyun Access Key ID</param>
        /// <param name="secretAccessKey">Aliyun Secret Access Key</param>
        /// <param name="regionEndpoint">The region endpoint to connect. 
        /// http://$AccountID.mns.<region>.aliyuncs.com</param>
        public MNSClient(string accessKeyId, string secretAccessKey, string regionEndpoint)
			: this(accessKeyId, secretAccessKey, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) }, null)
        {
        }

		public MNSClient(string accessKeyId, string secretAccessKey, string regionEndpoint, string stsToken)
			: this(accessKeyId, secretAccessKey, new MNSConfig { RegionEndpoint = new Uri(regionEndpoint) }, stsToken)
		{
		}

        /// <summary>
        /// Constructs MNSClient with Aliyun Access Key ID, Secret Access Key and an
        /// MNSClient Configuration object. 
        /// </summary>
        /// <param name="accessKeyId">Aliyun Access Key ID</param>
        /// <param name="secretAccessKey">Aliyun Secret Access Key</param>
        /// <param name="clientConfig">The MNSClient Configuration Object</param>
        public MNSClient(string accessKeyId, string secretAccessKey, MNSConfig clientConfig, string stsToken)
			: base(accessKeyId, secretAccessKey, clientConfig, stsToken)
        {
        }

        #endregion

        #region Overrides

        protected override IServiceSigner CreateSigner()
        {
            return new MNSSigner();
        }

        protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
        {
            pipeline.AddHandlerAfter<Marshaller>(new ResponseValidationHandler());
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

        #region  CreateQueue

        /// <inheritdoc/>
        public Queue CreateQueue(string queueName)
        {
            var request = new CreateQueueRequest {QueueName = queueName};
            return CreateQueue(request);
        }

        /// <inheritdoc/>
        public Queue CreateQueue(CreateQueueRequest request)
        {
            var marshaller = new CreateQueueRequestMarshaller();
            var unmarshaller = CreateQueueResponseUnmarshaller.Instance;

            var response = Invoke<CreateQueueRequest, CreateQueueResponse>(request, marshaller, unmarshaller);
            return new Queue(response.QueueUrl.Substring(response.QueueUrl.LastIndexOf("/") + 1), this);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginCreateQueue(CreateQueueRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new CreateQueueRequestMarshaller();
            var unmarshaller = CreateQueueResponseUnmarshaller.Instance;

            return BeginInvoke<CreateQueueRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public Queue EndCreateQueue(IAsyncResult asyncResult)
        {
            var response = EndInvoke<CreateQueueResponse>(asyncResult);
            return new Queue(response.QueueUrl.Substring(response.QueueUrl.LastIndexOf("/") + 1), this);
        }

        #endregion

        #region GetNativeQueue

        /// <inheritdoc/>
        public Queue GetNativeQueue(string queueName)
        {
            return new Queue(queueName, this);
        }

        #endregion

        #region  DeleteQueue

        /// <inheritdoc/>
        public DeleteQueueResponse DeleteQueue(string queueName)
        {
            var request = new DeleteQueueRequest { QueueName = queueName };
            return DeleteQueue(request);
        }

        /// <inheritdoc/>
        public DeleteQueueResponse DeleteQueue(DeleteQueueRequest request)
        {
            var marshaller = new DeleteQueueRequestMarshaller();
            var unmarshaller = DeleteQueueResponseUnmarshaller.Instance;

            return Invoke<DeleteQueueRequest,DeleteQueueResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginDeleteQueue(DeleteQueueRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new DeleteQueueRequestMarshaller();
            var unmarshaller = DeleteQueueResponseUnmarshaller.Instance;

            return BeginInvoke<DeleteQueueRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public  DeleteQueueResponse EndDeleteQueue(IAsyncResult asyncResult)
        {
            return EndInvoke<DeleteQueueResponse>(asyncResult);
        }

        #endregion

        #region  ListQueue

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(string queueNamePrefix)
        {
            var request = new ListQueueRequest()
            {
                QueueNamePrefix = queueNamePrefix
            };
            return ListQueue(request);
        }

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(string queueNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListQueueRequest()
            {
                QueueNamePrefix = queueNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return ListQueue(request);
        }

        /// <inheritdoc/>
        public ListQueueResponse ListQueue(ListQueueRequest request)
        {
            var marshaller = new ListQueueRequestMarshaller();
            var unmarshaller = ListQueueResponseUnmarshaller.Instance;

            return Invoke<ListQueueRequest, ListQueueResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginListQueue(ListQueueRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new ListQueueRequestMarshaller();
            var unmarshaller = ListQueueResponseUnmarshaller.Instance;

            return BeginInvoke<ListQueueRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public ListQueueResponse EndListQueue(IAsyncResult asyncResult)
        {
            return EndInvoke<ListQueueResponse>(asyncResult);
        }

        #endregion

        #region  CreateTopic

        /// <inheritdoc/>
        public Topic CreateTopic(string topicName)
        {
            var request = new CreateTopicRequest { TopicName = topicName };
            return CreateTopic(request);
        }

        /// <inheritdoc/>
        public Topic CreateTopic(CreateTopicRequest request)
        {
            var marshaller = new CreateTopicRequestMarshaller();
            var unmarshaller = CreateTopicResponseUnmarshaller.Instance;

            var response = Invoke<CreateTopicRequest, CreateTopicResponse>(request, marshaller, unmarshaller);
            return new Topic(response.TopicUrl.Substring(response.TopicUrl.LastIndexOf("/") + 1), this);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginCreateTopic(CreateTopicRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new CreateTopicRequestMarshaller();
            var unmarshaller = CreateTopicResponseUnmarshaller.Instance;

            return BeginInvoke<CreateTopicRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public Topic EndCreateTopic(IAsyncResult asyncResult)
        {
            var response = EndInvoke<CreateTopicResponse>(asyncResult);
            return new Topic(response.TopicUrl.Substring(response.TopicUrl.LastIndexOf("/") + 1), this);
        }

        #endregion

        #region GetNativeTopic

        /// <inheritdoc/>
        public Topic GetNativeTopic(string topicName)
        {
            return new Topic(topicName, this);
        }

        #endregion

        #region  DeleteTopic

        /// <inheritdoc/>
        public DeleteTopicResponse DeleteTopic(string topicName)
        {
            var request = new DeleteTopicRequest { TopicName = topicName };
            return DeleteTopic(request);
        }

        /// <inheritdoc/>
        public DeleteTopicResponse DeleteTopic(DeleteTopicRequest request)
        {
            var marshaller = new DeleteTopicRequestMarshaller();
            var unmarshaller = DeleteTopicResponseUnmarshaller.Instance;

            return Invoke<DeleteTopicRequest, DeleteTopicResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginDeleteTopic(DeleteTopicRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new DeleteTopicRequestMarshaller();
            var unmarshaller = DeleteTopicResponseUnmarshaller.Instance;

            return BeginInvoke<DeleteTopicRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public DeleteTopicResponse EndDeleteTopic(IAsyncResult asyncResult)
        {
            return EndInvoke<DeleteTopicResponse>(asyncResult);
        }

        #endregion

        #region  ListTopic

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(string topicNamePrefix)
        {
            var request = new ListTopicRequest()
            {
                TopicNamePrefix = topicNamePrefix
            };
            return ListTopic(request);
        }

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(string topicNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListTopicRequest()
            {
                TopicNamePrefix = topicNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return ListTopic(request);
        }

        /// <inheritdoc/>
        public ListTopicResponse ListTopic(ListTopicRequest request)
        {
            var marshaller = new ListTopicRequestMarshaller();
            var unmarshaller = ListTopicResponseUnmarshaller.Instance;

            return Invoke<ListTopicRequest, ListTopicResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginListTopic(ListTopicRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new ListTopicRequestMarshaller();
            var unmarshaller = ListTopicResponseUnmarshaller.Instance;

            return BeginInvoke<ListTopicRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public ListTopicResponse EndListTopic(IAsyncResult asyncResult)
        {
            return EndInvoke<ListTopicResponse>(asyncResult);
        }

        #endregion

        #region SetAccountAttributes

        /// <inheritdoc/>
        public SetAccountAttributesResponse SetAccountAttributes(AccountAttributes attributes)
        {
            var request = new SetAccountAttributesRequest { Attributes = attributes };
            return SetAccountAttributes(request);
        }

        /// <inheritdoc/>
        public SetAccountAttributesResponse SetAccountAttributes(SetAccountAttributesRequest request)
        {
            var marshaller = new SetAccountAttributesRequestMarshaller();
            var unmarshaller = SetAccountAttributesResponseUnmarshaller.Instance;

            return Invoke<SetAccountAttributesRequest, SetAccountAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSetAccountAttributes(SetAccountAttributesRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new SetAccountAttributesRequestMarshaller();
            var unmarshaller = SetAccountAttributesResponseUnmarshaller.Instance;

            return BeginInvoke<SetAccountAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public SetAccountAttributesResponse EndSetAccountAttributes(IAsyncResult asyncResult)
        {
            return EndInvoke<SetAccountAttributesResponse>(asyncResult);
        }

        #endregion

        #region GetAccountAttributes

        /// <inheritdoc/>
        public GetAccountAttributesResponse GetAccountAttributes()
        {
            var request = new GetAccountAttributesRequest();
            return GetAccountAttributes(request);
        }

        /// <inheritdoc/>
        public GetAccountAttributesResponse GetAccountAttributes(GetAccountAttributesRequest request)
        {
            var marshaller = new GetAccountAttributesRequestMarshaller();
            var unmarshaller = GetAccountAttributesResponseUnmarshaller.Instance;

            return Invoke<GetAccountAttributesRequest, GetAccountAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginGetAccountAttributes(GetAccountAttributesRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new GetAccountAttributesRequestMarshaller();
            var unmarshaller = GetAccountAttributesResponseUnmarshaller.Instance;

            return BeginInvoke<GetAccountAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public GetAccountAttributesResponse EndGetAccountAttributes(IAsyncResult asyncResult)
        {
            return EndInvoke<GetAccountAttributesResponse>(asyncResult);
        }

        #endregion
    }
}
