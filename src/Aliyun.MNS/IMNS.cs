/*
 * Copyright (C) Alibaba Cloud Computing
 * All rights reserved.
 */

using System;
using Aliyun.MNS.Model;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS.
    /// </summary>
    public partial interface IMNS : IDisposable
    {
        #region  CreateQueue

        /// <summary>
        /// Creates a new queue with specified queue name.
        /// </summary>
        /// 
        /// <param name="queueName">The name for the queue to be created.</param>
        /// 
        /// <returns>A native queue object used to manipulate the newly queue.</returns>
        Queue CreateQueue(string queueName);

        /// <summary>
        /// Creates a new queue with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateQueue service.</param>
        /// 
        /// <returns>A native queue object used to manipulate the newly queue.</returns>
        /// <exception cref="QueueAlreadyExistException">
        /// A queue already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing queue.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The queue attributes specified in the request object whose values differ from those of the existing queue.
        /// </exception>
        Queue CreateQueue(CreateQueueRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS CreateQueue service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateQueue service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginCreateQueue(CreateQueueRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS CreateQueue service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginCreateQueue.</param>
        /// 
        /// <returns>Returns a native queue object.</returns>
        Queue EndCreateQueue(IAsyncResult asyncResult);

        #endregion

        #region GetNativeQueue

        /// <summary>
        /// Get a native queue object with the specified queueName.
        /// </summary>
        /// 
        /// <param name="queueName">The name of native queue object to be created</param>
        /// 
        /// <returns>A native queue object</returns>
        Queue GetNativeQueue(string queueName);

        #endregion

        #region  DeleteQueue

        /// <summary>
        /// Deletes the queue specified by the <b>queue name</b>.
        /// </summary>
        /// 
        /// <param name="queueName">The queue name to be deleted.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteQueue service.</returns>
        DeleteQueueResponse DeleteQueue(string queueName);

        /// <summary>
        /// Deletes the queue with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteQueue service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteQueue service.</returns>
        DeleteQueueResponse DeleteQueue(DeleteQueueRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS DeleteQueue service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteQueue service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginDeleteQueue(DeleteQueueRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS DeleteQueue service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginDeleteQueue.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteQueue service..</returns>
        DeleteQueueResponse EndDeleteQueue(IAsyncResult asyncResult);

        #endregion

        #region  ListQueue

        /// <summary>
        /// Returns a list of your queues with specified prefix.
        /// </summary>
        /// <param name="queueNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(string queueNamePrefix);

        /// <summary>
        /// Returns a list of your queues with specified conditions.
        /// </summary>
        /// <param name="queueNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(string queueNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your queues with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListQueue service.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse ListQueue(ListQueueRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS ListQueue service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListQueue service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginListQueue(ListQueueRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS ListQueue service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginListQueue.</param>
        /// 
        /// <returns>The response returned by the MNS ListQueue service.</returns>
        ListQueueResponse EndListQueue(IAsyncResult asyncResult);

        #endregion

        #region CreateTopic
        /// <summary>
        /// Creates a new topic with specified topic name.
        /// </summary>
        /// 
        /// <param name="topicName">The name for the topic to be created.</param>
        /// 
        /// <returns>A native topic object used to manipulate the newly queue.</returns>
        /// <exception cref="TopicAlreadyExistException">
        /// A topic already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing topic.
        /// </exception>
        /// <exception cref="TopicNameLengthErrorException">
        /// the length of topic name is not suitable
        /// </exception>
        /// <exception cref="TopicNameInvalidException">
        /// the topic name contains invalid characters.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// the argument provided is invalid
        /// </exception>
        Topic CreateTopic(string topicName);

        /// <summary>
        /// Creates a new topic with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateTopic service.</param>
        /// 
        /// <returns>A native topic object used to manipulate the newly topic.</returns>
        /// <exception cref="TopicAlreadyExistException">
        /// A topic already exists with the specified name. MNS returns this error only if the request
        /// includes attributes whose values differ from those of the existing topic.
        /// </exception>
        /// <exception cref="TopicNameLengthErrorException">
        /// the length of topic name is not suitable
        /// </exception>
        /// <exception cref="TopicNameInvalidException">
        /// the topic name contains invalid characters.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// the argument provided is invalid
        /// </exception>
        Topic CreateTopic(CreateTopicRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS CreateTopic service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS CreateTopic service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginCreateTopic(CreateTopicRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS CreateTopic service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginCreateTopic.</param>
        /// 
        /// <returns>Returns a native queue object.</returns>
        Topic EndCreateTopic(IAsyncResult asyncResult);

        #endregion

        #region GetNativeTopic

        /// <summary>
        /// Get a native topic object with the specified topicName.
        /// </summary>
        /// 
        /// <param name="topicName">The name of native topic object to be created</param>
        /// 
        /// <returns>A native topic object</returns>
        Topic GetNativeTopic(string topicName);

        #endregion

        #region  DeleteTopic

        /// <summary>
        /// Deletes the topic specified by the <b>topic name</b>.
        /// </summary>
        /// 
        /// <param name="topicName">The topic name to be deleted.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteTopic service.</returns>
        DeleteTopicResponse DeleteTopic(string queueName);

        /// <summary>
        /// Deletes the topic with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteTopic service.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteTopic service.</returns>
        DeleteTopicResponse DeleteTopic(DeleteTopicRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS DeleteTopic service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS DeleteTopic service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginDeleteTopic(DeleteTopicRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS DeleteTopic service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginDeleteTopic.</param>
        /// 
        /// <returns>The response returned by the MNS DeleteTopic service..</returns>
        DeleteTopicResponse EndDeleteTopic(IAsyncResult asyncResult);

        #endregion

        #region  ListTopic

        /// <summary>
        /// Returns a list of your topics with specified prefix.
        /// </summary>
        /// <param name="topicNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(string topicNamePrefix);

        /// <summary>
        /// Returns a list of your topics with specified conditions.
        /// </summary>
        /// <param name="topicNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(string topicNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your topics with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListTopic service.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse ListTopic(ListTopicRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS ListTopic service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListTopic service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginListTopic(ListTopicRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS ListTopic service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginListTopic.</param>
        /// 
        /// <returns>The response returned by the MNS ListTopic service.</returns>
        ListTopicResponse EndListTopic(IAsyncResult asyncResult);

        #endregion

        #region SetAccountAttributes

        /// <summary>
        /// set account attributes
        /// </summary>
        /// <param name="AccountAttributes">account attributes</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        SetAccountAttributesResponse SetAccountAttributes(AccountAttributes attributes);

        /// <summary>
        /// set account attributes
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetAccountAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        SetAccountAttributesResponse SetAccountAttributes(SetAccountAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS SetAccountAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetAccountAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSetAccountAttributes(SetAccountAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS SetAccountAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSetAccountAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        SetAccountAttributesResponse EndSetAccountAttributes(IAsyncResult asyncResult);

        #endregion

        #region GetAccountAttributes

        /// <summary>
        /// get account attributes
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetAccountAttributes service.</returns>
        GetAccountAttributesResponse GetAccountAttributes();

        /// <summary>
        /// get account attributes
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetAccountAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetAccountAttributes service.</returns>
        GetAccountAttributesResponse GetAccountAttributes(GetAccountAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS GetAccountAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetAccountAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginGetAccountAttributes(GetAccountAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS GetAccountAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginGetAccountAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS GetAccountAttributes service.</returns>
        GetAccountAttributesResponse EndGetAccountAttributes(IAsyncResult asyncResult);

        #endregion
    }
}
