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
    /// Implementation for accessing MNS queue
    /// </summary>
    public partial class Queue : IQueue
    {
        #region Properties

        private string _queueName;
        private readonly AliyunServiceClient _serviceClient;

        #endregion

        #region Constructor

        /// <summary>
        /// Instantiates Queue with the parameterized properties
        /// </summary>
        public Queue(string queueName, AliyunServiceClient serviceClient)
        {
            _queueName = queueName;
            _serviceClient = serviceClient;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets and sets the property QueueName
        /// </summary>
        public string QueueName
        {
            get { return this._queueName; }
            set { this._queueName = value; }
        }

        /// <summary>
        /// Check to see if QueueName property is set
        /// </summary>
        public bool IsSetQueueName()
        {
            return this._queueName != null;
        }

        #endregion

        #region  GetAttributes

        /// <inheritdoc/>
        public GetQueueAttributesResponse GetAttributes()
        {
            var request = new GetQueueAttributesRequest();
            return GetAttributes(request);
        }

        /// <inheritdoc/>
        public GetQueueAttributesResponse GetAttributes(GetQueueAttributesRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new GetQueueAttributesRequestMarshaller();
            var unmarshaller = GetQueueAttributesResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<GetQueueAttributesRequest, GetQueueAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginGetAttributes(GetQueueAttributesRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new GetQueueAttributesRequestMarshaller();
            var unmarshaller = GetQueueAttributesResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<GetQueueAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public GetQueueAttributesResponse EndGetAttributes(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<GetQueueAttributesResponse>(asyncResult);
        }

        #endregion

        #region  SetAttributes

        /// <inheritdoc/>
        public SetQueueAttributesResponse SetAttributes(QueueAttributes attributes)
        {
            var request = new SetQueueAttributesRequest { Attributes = attributes };
            return SetAttributes(request);
        }

        /// <inheritdoc/>
        public SetQueueAttributesResponse SetAttributes(SetQueueAttributesRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SetQueueAttributesRequestMarshaller();
            var unmarshaller = SetQueueAttributesResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<SetQueueAttributesRequest, SetQueueAttributesResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSetAttributes(SetQueueAttributesRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SetQueueAttributesRequestMarshaller();
            var unmarshaller = SetQueueAttributesResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<SetQueueAttributesRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public SetQueueAttributesResponse EndSetAttributes(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<SetQueueAttributesResponse>(asyncResult);
        }

        #endregion

        #region  ChangeMessageVisibility

        /// <inheritdoc/>
        public ChangeMessageVisibilityResponse ChangeMessageVisibility(string receiptHandle, int visibilityTimeout)
        {
            var request = new ChangeMessageVisibilityRequest()
            {
                ReceiptHandle = receiptHandle,
                VisibilityTimeout = visibilityTimeout
            };
            return ChangeMessageVisibility(request);
        }

        /// <inheritdoc/>
        public ChangeMessageVisibilityResponse ChangeMessageVisibility(ChangeMessageVisibilityRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ChangeMessageVisibilityRequestMarshaller();
            var unmarshaller = ChangeMessageVisibilityResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<ChangeMessageVisibilityRequest, ChangeMessageVisibilityResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginChangeMessageVisibility(ChangeMessageVisibilityRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ChangeMessageVisibilityRequestMarshaller();
            var unmarshaller = ChangeMessageVisibilityResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<ChangeMessageVisibilityRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public ChangeMessageVisibilityResponse EndChangeMessageVisibility(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<ChangeMessageVisibilityResponse>(asyncResult);
        }

        #endregion

        #region DeleteMessage

        /// <inheritdoc/>
        public DeleteMessageResponse DeleteMessage(string receiptHandle)
        {
            var request = new DeleteMessageRequest {ReceiptHandle = receiptHandle};
            return DeleteMessage(request);
        }

        /// <inheritdoc/>
        public DeleteMessageResponse DeleteMessage(DeleteMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new DeleteMessageRequestMarshaller();
            var unmarshaller = DeleteMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<DeleteMessageRequest, DeleteMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public BatchDeleteMessageResponse BatchDeleteMessage(BatchDeleteMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchDeleteMessageRequestMarshaller();
            var unmarshaller = BatchDeleteMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<BatchDeleteMessageRequest, BatchDeleteMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginDeleteMessage(DeleteMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new DeleteMessageRequestMarshaller();
            var unmarshaller = DeleteMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<DeleteMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public DeleteMessageResponse EndDeleteMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<DeleteMessageResponse>(asyncResult);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginBatchDeleteMessage(BatchDeleteMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchDeleteMessageRequestMarshaller();
            var unmarshaller = BatchDeleteMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<BatchDeleteMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public BatchDeleteMessageResponse EndBatchDeleteMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<BatchDeleteMessageResponse>(asyncResult);
        }

        #endregion

        #region ReceiveMessage

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage()
        {
            var request = new ReceiveMessageRequest();
            return ReceiveMessage(request);
        }

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage(uint waitSeconds)
        {
            var request = new ReceiveMessageRequest() {WaitSeconds = waitSeconds};
            return ReceiveMessage(request);
        }

        /// <inheritdoc/>
        public ReceiveMessageResponse ReceiveMessage(ReceiveMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ReceiveMessageRequestMarshaller();
            var unmarshaller = ReceiveMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<ReceiveMessageRequest, ReceiveMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize)
        {
            var request = new BatchReceiveMessageRequest(batchSize);
            return BatchReceiveMessage(request);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize, uint waitSeconds)
        {
            var request = new BatchReceiveMessageRequest(batchSize, waitSeconds);
            return BatchReceiveMessage(request);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse BatchReceiveMessage(BatchReceiveMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchReceiveMessageRequestMarshaller();
            var unmarshaller = BatchReceiveMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<BatchReceiveMessageRequest, BatchReceiveMessageResponse>(request, marshaller, unmarshaller);
        }


        /// <inheritdoc/>
        public IAsyncResult BeginReceiveMessage(ReceiveMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new ReceiveMessageRequestMarshaller();
            var unmarshaller = ReceiveMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<ReceiveMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public ReceiveMessageResponse EndReceiveMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<ReceiveMessageResponse>(asyncResult);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginBatchReceiveMessage(BatchReceiveMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchReceiveMessageRequestMarshaller();
            var unmarshaller = BatchReceiveMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<BatchReceiveMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public BatchReceiveMessageResponse EndBatchReceiveMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<BatchReceiveMessageResponse>(asyncResult);
        }

        #endregion

        #region  PeekMessage

        /// <inheritdoc/>
        public PeekMessageResponse PeekMessage()
        {
            var request = new PeekMessageRequest();
            return PeekMessage(request);
        }

        /// <inheritdoc/>
        public PeekMessageResponse PeekMessage(PeekMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new PeekMessageRequestMarshaller();
            var unmarshaller = PeekMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<PeekMessageRequest, PeekMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public BatchPeekMessageResponse BatchPeekMessage(uint batchSize)
        {
            var request = new BatchPeekMessageRequest(batchSize);
            return BatchPeekMessage(request);
        }

        /// <inheritdoc/>
        public BatchPeekMessageResponse BatchPeekMessage(BatchPeekMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchPeekMessageRequestMarshaller();
            var unmarshaller = BatchPeekMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<BatchPeekMessageRequest, BatchPeekMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginPeekMessage(PeekMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new PeekMessageRequestMarshaller();
            var unmarshaller = PeekMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<PeekMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public PeekMessageResponse EndPeekMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<PeekMessageResponse>(asyncResult);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginBatchPeekMessage(BatchPeekMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchPeekMessageRequestMarshaller();
            var unmarshaller = BatchPeekMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<BatchPeekMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public BatchPeekMessageResponse EndBatchPeekMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<BatchPeekMessageResponse>(asyncResult);
        }

        #endregion

        #region SendMessage

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(string messageBody)
        {
            var request = new SendMessageRequest { MessageBody = messageBody };
            return SendMessage(request);
        }

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(string messageBody, uint delaySeconds, uint priority)
        {
            var request = new SendMessageRequest()
            {
                MessageBody = messageBody,
                DelaySeconds = delaySeconds,
                Priority = priority
            };
            return SendMessage(request);
        }

        /// <inheritdoc/>
        public SendMessageResponse SendMessage(SendMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SendMessageRequestMarshaller();
            var unmarshaller = SendMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<SendMessageRequest, SendMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public BatchSendMessageResponse BatchSendMessage(BatchSendMessageRequest request)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchSendMessageRequestMarshaller();
            var unmarshaller = BatchSendMessageResponseUnmarshaller.Instance;

            return _serviceClient.Invoke<BatchSendMessageRequest, BatchSendMessageResponse>(request, marshaller, unmarshaller);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginSendMessage(SendMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new SendMessageRequestMarshaller();
            var unmarshaller = SendMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<SendMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public SendMessageResponse EndSendMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<SendMessageResponse>(asyncResult);
        }

        /// <inheritdoc/>
        public IAsyncResult BeginBatchSendMessage(BatchSendMessageRequest request, AsyncCallback callback, object state)
        {
            request.QueueName = this.QueueName;

            var marshaller = new BatchSendMessageRequestMarshaller();
            var unmarshaller = BatchSendMessageResponseUnmarshaller.Instance;

            return _serviceClient.BeginInvoke<BatchSendMessageRequest>(request, marshaller, unmarshaller,
                callback, state);
        }

        /// <inheritdoc/>
        public BatchSendMessageResponse EndBatchSendMessage(IAsyncResult asyncResult)
        {
            return AliyunServiceClient.EndInvoke<BatchSendMessageResponse>(asyncResult);
        }

        #endregion
    }
}
