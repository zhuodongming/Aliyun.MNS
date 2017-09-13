/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;
using Aliyun.MNS.Model.Internal.MarshallTransformations;
using Aliyun.MNS.Runtime;
using Aliyun.MNS.Util;
using System.Collections.Generic;

namespace Aliyun.MNS
{
    /// <summary>
    /// Implementation for accessing MNS topic
    /// </summary>
    public partial class Topic : ITopic
    {
        #region Properties

        private string _topicName;
        private readonly AliyunServiceClient _serviceClient;
        private string _accountId = "";
        private string _region = "";

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates Topic with the parameterized properties
        /// </summary>
        public Topic(string topicName, AliyunServiceClient serviceClient)
        {
            _topicName = topicName;
            _serviceClient = serviceClient;

            Uri endpointUri = serviceClient.Config.RegionEndpoint;
            if (endpointUri != null)
            {
                string[] hostPieces = endpointUri.Host.Split('.');
                _accountId = hostPieces[0];
                _region = hostPieces[2].Split(new[] { "-internal" }, StringSplitOptions.RemoveEmptyEntries)[0];
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets and sets the property TopicName
        /// </summary>
        public string TopicName
        {
            get { return this._topicName; }
            set { this._topicName = value; }
        }

        /// <summary>
        /// Check to see if TopicName property is set
        /// </summary>
        public bool IsSetTopicName()
        {
            return this._topicName != null;
        }

        #endregion

        #region  GetAttributes

        /// <inheritdoc/>
        public GetTopicAttributesResponse GetAttributes()
        {
            var request = new GetTopicAttributesRequest();
            return GetAttributes(request);
        }

        /// <inheritdoc/>
        public GetTopicAttributesResponse GetAttributes(GetTopicAttributesRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetTopicAttributesRequestMarshaller();
            var unmarshaller = GetTopicAttributesResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<GetTopicAttributesRequest, GetTopicAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginGetAttributes(GetTopicAttributesRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetTopicAttributesRequestMarshaller();
            var unmarshaller = GetTopicAttributesResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<GetTopicAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public GetTopicAttributesResponse EndGetAttributes(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<GetTopicAttributesResponse>(asyncResult);
        }

        #endregion

        #region  SetAttributes

        /// <inheritdoc/>
        public SetTopicAttributesResponse SetAttributes(TopicAttributes attributes)
        {
            var request = new SetTopicAttributesRequest { Attributes = attributes };
            return SetAttributes(request);
        }

        /// <inheritdoc/>
        public SetTopicAttributesResponse SetAttributes(SetTopicAttributesRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetTopicAttributesRequestMarshaller();
            var unmarshaller = SetTopicAttributesResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<SetTopicAttributesRequest, SetTopicAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSetAttributes(SetTopicAttributesRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetTopicAttributesRequestMarshaller();
            var unmarshaller = SetTopicAttributesResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<SetTopicAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public SetTopicAttributesResponse EndSetAttributes(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<SetTopicAttributesResponse>(asyncResult);
        }

        #endregion

        #region  Subscribe

        /// <inheritdoc/>
        public SubscribeResponse Subscribe(string subscriptionName, string endpoint)
        {
            return Subscribe(new SubscribeRequest(subscriptionName, endpoint));
        }

        /// <inheritdoc/>
        public SubscribeResponse Subscribe(SubscribeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SubscribeRequestMarshaller();
            var unmarshaller = SubscribeResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<SubscribeRequest, SubscribeResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSubscribe(SubscribeRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SubscribeRequestMarshaller();
            var unmarshaller = SubscribeResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<SubscribeRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public SubscribeResponse EndSubscribe(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<SubscribeResponse>(asyncResult);
        }

        #endregion

        #region  Subscribe

        /// <inheritdoc/>
        public UnsubscribeResponse Unsubscribe(string subscriptionName)
        {
            return Unsubscribe(new UnsubscribeRequest(subscriptionName));
        }

        /// <inheritdoc/>
        public UnsubscribeResponse Unsubscribe(UnsubscribeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new UnsubscribeRequestMarshaller();
            var unmarshaller = UnsubscribeResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<UnsubscribeRequest, UnsubscribeResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginUnsubscribe(UnsubscribeRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new UnsubscribeRequestMarshaller();
            var unmarshaller = UnsubscribeResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<UnsubscribeRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public UnsubscribeResponse EndUnsubscribe(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<UnsubscribeResponse>(asyncResult);
        }

        #endregion

        #region  GetSubscriptionAttribute

        /// <inheritdoc/>
        public GetSubscriptionAttributeResponse GetSubscriptionAttribute(string subscriptionName)
        {
            return GetSubscriptionAttribute(new GetSubscriptionAttributeRequest(subscriptionName));
        }

        /// <inheritdoc/>
        public GetSubscriptionAttributeResponse GetSubscriptionAttribute(GetSubscriptionAttributeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = GetSubscriptionAttributeResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<GetSubscriptionAttributeRequest, GetSubscriptionAttributeResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginGetSubscriptionAttribute(GetSubscriptionAttributeRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new GetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = GetSubscriptionAttributeResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<GetSubscriptionAttributeRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public GetSubscriptionAttributeResponse EndGetSubscriptionAttribute(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<GetSubscriptionAttributeResponse>(asyncResult);
        }

        #endregion

        #region  SetSubscriptionAttribute

        /// <inheritdoc/>
        public SetSubscriptionAttributeResponse SetSubscriptionAttribute(string subscriptionName, SubscriptionAttributes attributes)
        {
            return SetSubscriptionAttribute(new SetSubscriptionAttributeRequest(subscriptionName, attributes));
        }

        /// <inheritdoc/>
        public SetSubscriptionAttributeResponse SetSubscriptionAttribute(SetSubscriptionAttributeRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = SetSubscriptionAttributeResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<SetSubscriptionAttributeRequest, SetSubscriptionAttributeResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSetSubscriptionAttribute(SetSubscriptionAttributeRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new SetSubscriptionAttributeRequestMarshaller();
            var unmarshaller = SetSubscriptionAttributeResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<SetSubscriptionAttributeRequest>(request, marshaller, unmarshaller,
                callback, state);
        }


        /// <inheritdoc/>
        public SetSubscriptionAttributeResponse EndSetSubscriptionAttribute(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<SetSubscriptionAttributeResponse>(asyncResult);
        }

        #endregion

        #region  ListSubscription

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix)
        {
            var request = new ListSubscriptionRequest()
            {
                SubscriptionNamePrefix = subscriptionNamePrefix,
                TopicName = this.TopicName
            };
            return ListSubscription(request);
        }

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix, string marker, uint maxReturns)
        {
            var request = new ListSubscriptionRequest()
            {
                TopicName = this.TopicName,
                SubscriptionNamePrefix = subscriptionNamePrefix,
                Marker = marker,
                MaxReturns = maxReturns
            };
            return ListSubscription(request);
        }

        /// <inheritdoc/>
        public ListSubscriptionResponse ListSubscription(ListSubscriptionRequest request)
        {
            request.TopicName = this.TopicName;
            var marshaller = new ListSubscriptionRequestMarshaller();
            var unmarshaller = ListSubscriptionResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<ListSubscriptionRequest, ListSubscriptionResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginListSubscription(ListSubscriptionRequest request, AsyncCallback callback, object state)
        {
            var marshaller = new ListSubscriptionRequestMarshaller();
            var unmarshaller = ListSubscriptionResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<ListSubscriptionRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public ListSubscriptionResponse EndListSubscription(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<ListSubscriptionResponse>(asyncResult);
        }

        #endregion

        #region  PublishMessage

        /// <inheritdoc/>
        public PublishMessageResponse PublishMessage(string messageBody)
        {
            var request = new PublishMessageRequest { MessageBody = messageBody };
            return PublishMessage(request);
        }

        /// <inheritdoc/>
        public PublishMessageResponse PublishMessage(PublishMessageRequest request)
        {
            request.TopicName = this.TopicName;

            var marshaller = new PublishMessageRequestMarshaller();
            var unmarshaller = PublishMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<PublishMessageRequest, PublishMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginPublishMessage(PublishMessageRequest request, AsyncCallback callback, object state)
        {
            request.TopicName = this.TopicName;

            var marshaller = new PublishMessageRequestMarshaller();
            var unmarshaller = PublishMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<PublishMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public PublishMessageResponse EndPublishMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<PublishMessageResponse>(asyncResult);
        }
        #endregion

        #region
        /// <inheritdoc/>
        public string GenerateQueueEndpoint(string queueName)
        { 
            return "acs:mns:" + this._region + ":" + this._accountId + ":queues/" + queueName;
        }

        /// <inheritdoc/>
        public string GenerateMailEndpoint(string mailAddress)
        { 
            return "mail:directmail:" + mailAddress;
        }

        /// <inheritdoc/>
        public string GenerateSmsEndpoint(string phone)
        {
            return "sms:directsms:" + phone;
        }

        /// <inheritdoc/>
        public string GenerateSmsEndpoint()
        {
            return "sms:directsms:anonymous";
        }

        /// <inheritdoc/>
        public string GenerateBatchSmsEndpoint()
        {
            return "sms:directsms:anonymous";
        }
        #endregion
    }
}
