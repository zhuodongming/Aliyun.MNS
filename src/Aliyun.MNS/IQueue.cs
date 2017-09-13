/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;
using System.Collections.Generic;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS queue
    /// </summary>
    public partial interface IQueue
    {
        #region  GetAttributes

        /// <summary>
        /// Gets queue attributes.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        GetQueueAttributesResponse GetAttributes();

        /// <summary>
        /// Gets queue attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetQueueAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS GetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        GetQueueAttributesResponse GetAttributes(GetQueueAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS GetQueueAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetQueueAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginGetAttributes(GetQueueAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS GetQueueAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginGetAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS GetQueueAttributes service.</returns>
        GetQueueAttributesResponse EndGetAttributes(IAsyncResult asyncResult);

        #endregion

        #region  SetAttributes

        /// <summary>
        /// Sets queue attributes.
        /// </summary>
        /// 
        /// <param name="attributes">The queue attributes to be set.</param>
        /// 
        /// <returns>The response returned by the MNS SetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided does not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should be between MIN and MAX seconds/bytes.
        /// </exception>
        SetQueueAttributesResponse SetAttributes(QueueAttributes attributes);

        /// <summary>
        /// Sets queue attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetQueueAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetQueueAttributes service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SetQueueAttributesResponse SetAttributes(SetQueueAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS SetQueueAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetQueueAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSetAttributes(SetQueueAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS SetQueueAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSetAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS SetQueueAttributes service.</returns>
        SetQueueAttributesResponse EndSetAttributes(IAsyncResult asyncResult);

        #endregion

        #region  ChangeMessageVisibility

        /// <summary>
        /// Changes the visibility timeout of a specified message of the queue to a new value.
        /// </summary>
        /// 
        /// <param name="receiptHandle">The receipt handle associated with the message whose visibility timeout should be changed. </param>
        /// <param name="visibilityTimeout">The new value for the message's visibility timeout.</param>
        /// 
        /// <returns>The response returned by the MNS ChangeMessageVisibility service.</returns>
        ChangeMessageVisibilityResponse ChangeMessageVisibility(string receiptHandle, int visibilityTimeout);

        /// <summary>
        /// Changes the visibility timeout of a specified message of the queue to a new value.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ChangeMessageVisibility service.</param>
        /// 
        /// <returns>The response returned by the MNS ChangeMessageVisibility service.</returns>
        ChangeMessageVisibilityResponse ChangeMessageVisibility(ChangeMessageVisibilityRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS ChangeMessageVisibility service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ChangeMessageVisibility service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginChangeMessageVisibility(ChangeMessageVisibilityRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS ChangeMessageVisibility service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginChangeMessageVisibility.</param>
        /// 
        /// <returns>The response returned by the MNS ChangeMessageVisibility service.</returns>
        ChangeMessageVisibilityResponse EndChangeMessageVisibility(IAsyncResult asyncResult);

        #endregion
        
        #region  DeleteMessage

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="receiptHandle">The receipt handle associated with the message to delete.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between Low and High seconds/bytes.
        /// </exception>
        DeleteMessageResponse DeleteMessage(string receiptHandle);

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="request">The request object to be sent to MNS DeleteMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between Low and High seconds/bytes.
        /// </exception>
        DeleteMessageResponse DeleteMessage(DeleteMessageRequest request);

        /// <summary>
        /// Deletes the specified message from the specified queue. 
        /// </summary>
        /// <param name="request">The request object to be sent to MNS BatchDeleteMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS BatchDeleteMessage service.</returns>
        /// <exception cref="ReceiptHandleErrorException">
        /// The receipt handle you provide is not valid.
        /// </exception>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should between MIN and MAX seconds/bytes.
        /// </exception>
        /// <exception cref="BatchDeleteFailException">
        /// Some messages are not deleted.
        /// </exception>
        BatchDeleteMessageResponse BatchDeleteMessage(BatchDeleteMessageRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS DeleteMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginDeleteMessage(DeleteMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS DeleteMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginDeleteMessage.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteMessage service.</returns>
        DeleteMessageResponse EndDeleteMessage(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous request to MNS BatchDeleteMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS BatchDeleteMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginBatchDeleteMessage(BatchDeleteMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS BatchDeleteMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginBatchDeleteMessage.</param>
        /// 
        /// <returns>The response returned by the MNS BatchDeleteMessage service.</returns>
        BatchDeleteMessageResponse EndBatchDeleteMessage(IAsyncResult asyncResult);

        #endregion

        #region  ReceiveMessage

        /// <summary>
        /// Retrieves one message from this queue.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// 
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage();

        /// <summary>
        /// Retrieves one message.
        /// </summary>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage(uint waitSeconds);

        /// <summary>
        /// Retrieves one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS ReceiveMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        ReceiveMessageResponse ReceiveMessage(ReceiveMessageRequest request);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(uint batchSize, uint waitSeconds);

        /// <summary>
        /// batch retrieves messages.
        /// </summary>
        /// <param name="batchSize">the most count limit of retrieved messages</param>
        /// <param name="waitSeconds">Wait polling time for this request.</param>
        ///  
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="MessageNotExistException">
        /// no messages exist.
        /// </exception>
        BatchReceiveMessageResponse BatchReceiveMessage(BatchReceiveMessageRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS ReceiveMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ReceiveMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginReceiveMessage(ReceiveMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS ReceiveMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginReceiveMessage.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        ReceiveMessageResponse EndReceiveMessage(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous request to MNS BatchReceiveMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS BatchReceiveMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginBatchReceiveMessage(BatchReceiveMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS BatchReceiveMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginBatchReceiveMessage.</param>
        /// 
        /// <returns>The response returned by the MNS BatchReceiveMessage service.</returns>
        BatchReceiveMessageResponse EndBatchReceiveMessage(IAsyncResult asyncResult);

        #endregion

        #region  PeekMessage

        /// <summary>
        /// Peeks one message.
        /// </summary>
        /// 
        /// <returns>The response from the PeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        PeekMessageResponse PeekMessage();

        /// <summary>
        /// Peeks one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS BatchPeekMessage service.</param>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        PeekMessageResponse PeekMessage(PeekMessageRequest request);

        /// <summary>
        /// Peeks one message.
        /// </summary>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        BatchPeekMessageResponse BatchPeekMessage(uint batchSize);

        /// <summary>
        /// Peeks one message.
        /// </summary>
        ///  <param name="request">The request object to be sent to MNS BatchPeekMessage service.</param>
        /// 
        /// <returns>The response from the BatchPeekMessage service method, as returned by MNS.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        BatchPeekMessageResponse BatchPeekMessage(BatchPeekMessageRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS PeekMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS PeekMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginPeekMessage(PeekMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS PeekMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginPeekMessage.</param>
        /// 
        /// <returns>The response returned by the MNS PeekMessage service.</returns>
        PeekMessageResponse EndPeekMessage(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous request to MNS BatchPeekMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS BatchPeekMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginBatchPeekMessage(BatchPeekMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS BatchPeekMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginBatchPeekMessage.</param>
        /// 
        /// <returns>The response returned by the MNS BatchPeekMessage service.</returns>
        BatchPeekMessageResponse EndBatchPeekMessage(IAsyncResult asyncResult);

        #endregion

        #region  SendMessage

        /// <summary>
        /// Delivers a message to the specified queue.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// </exception>
        SendMessageResponse SendMessage(string messageBody);

        /// <summary>
        /// Send a message to this queue.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// <param name="delaySeconds">The message delay seconds.</param>
        /// <param name="priority">The message priority level.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SendMessageResponse SendMessage(string messageBody, uint delaySeconds, uint priority);

        /// <summary>
        /// Send a message to this queue.
        /// </summary>
        /// <param name="request">The request object to be sent to MNS SendMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        SendMessageResponse SendMessage(SendMessageRequest request);

        /// <summary>
        /// Batch send messages to this queue.
        /// </summary>
        /// <param name="request">The request objects to be sent to MNS SendMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS ReceiveMessage service.</returns>
        /// <exception cref="QueueNotExistException">
        /// The queue name you provided is not exist.
        /// </exception>
        /// <exception cref="BatchSendFailException">
        /// some messages are not sent.
        /// </exception>
        BatchSendMessageResponse BatchSendMessage(BatchSendMessageRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS SendMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SendMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSendMessage(SendMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS SendMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSendMessage.</param>
        /// 
        /// <returns>The response returned by the MNS SendMessage service.</returns>
        SendMessageResponse EndSendMessage(IAsyncResult asyncResult);

        /// <summary>
        /// Begins an asynchronous request to MNS BatchSendMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS BatchSendMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginBatchSendMessage(BatchSendMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS BatchSendMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginBatchSendMessage.</param>
        /// 
        /// <returns>The response returned by the MNS BatchSendMessage service.</returns>
        BatchSendMessageResponse EndBatchSendMessage(IAsyncResult asyncResult);

        #endregion
    }
}
