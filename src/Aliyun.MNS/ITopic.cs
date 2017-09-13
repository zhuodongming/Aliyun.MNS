using Aliyun.MNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS
{
    /// <summary>
    /// Interface for accessing MNS topic
    /// </summary>
    public partial interface ITopic
    {
        #region  GetAttributes

        /// <summary>
        /// Gets topic attributes.
        /// </summary>
        /// 
        /// <returns>The response returned by the MNS GetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        GetTopicAttributesResponse GetAttributes();

        /// <summary>
        /// Gets topic attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetTopicAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS GetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        GetTopicAttributesResponse GetAttributes(GetTopicAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS GetTopicAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetTopicAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginGetAttributes(GetTopicAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS GetTopicAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginGetAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS GetTopicAttributes service.</returns>
        GetTopicAttributesResponse EndGetAttributes(IAsyncResult asyncResult);

        #endregion

        #region  SetAttributes

        /// <summary>
        /// Sets topic attributes.
        /// </summary>
        /// 
        /// <param name="attributes">The topic attributes to be set.</param>
        /// 
        /// <returns>The response returned by the MNS SetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided does not exist.
        /// </exception>
        /// <exception cref="InvalidArgumentException">
        /// The value of Element should be between MIN and MAX seconds/bytes.
        /// </exception>
        SetTopicAttributesResponse SetAttributes(TopicAttributes attributes);

        /// <summary>
        /// Sets topic attributes.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetTopicAttributes service.</param>
        /// 
        /// <returns>The response returned by the MNS SetTopicAttributes service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        SetTopicAttributesResponse SetAttributes(SetTopicAttributesRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS SetTopicAttributes service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetTopicAttributes service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSetAttributes(SetTopicAttributesRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS SetTopicAttributes service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSetAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS SetTopicAttributes service.</returns>
        SetTopicAttributesResponse EndSetAttributes(IAsyncResult asyncResult);

        #endregion

        #region  Subscribe

        /// <summary>
        /// Subscribe to topic.
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="endpoint">The endpoint for receiving notify messages.</param>
        /// 
        /// <returns>The response returned by the MNS Subscribe service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameLengthError">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionAlreadyExist">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="EndpointInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        SubscribeResponse Subscribe(string subscriptionName, string endpoint);

        /// <summary>
        /// Subscribe to topic.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Subscribe service.</param>
        /// 
        /// <returns>The response returned by the MNS Subscribe service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameLengthError">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionNameInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="SubscriptionAlreadyExist">
        /// The topic name you provided is not exist.
        /// </exception>
        /// <exception cref="EndpointInvalid">
        /// The topic name you provided is not exist.
        /// </exception>
        SubscribeResponse Subscribe(SubscribeRequest renquest);

        /// <summary>
        /// Begins an asynchronous request to MNS Subscribe service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Subscribe service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSubscribe(SubscribeRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS Subscribe service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSubscribe.</param>
        /// 
        /// <returns>The response returned by the MNS Subscribe service.</returns>
        SubscribeResponse EndSubscribe(IAsyncResult asyncResult);

        #endregion

        #region  Unsubscribe

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// 
        /// <returns>The response returned by the MNS Unsubscribe service.</returns>
        UnsubscribeResponse Unsubscribe(string subscriptionName);

        /// <summary>
        /// Unsubscribe
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Unsubscribe service.</param>
        /// 
        /// <returns>The response returned by the MNS Unsubscribe service.</returns>
        UnsubscribeResponse Unsubscribe(UnsubscribeRequest renquest);

        /// <summary>
        /// Begins an asynchronous request to MNS Unsubscribe service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS Unsubscribe service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginUnsubscribe(UnsubscribeRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS Unsubscribe service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginUnsubscribe.</param>
        /// 
        /// <returns>The response returned by the MNS Unsubscribe service.</returns>
        UnsubscribeResponse EndUnsubscribe(IAsyncResult asyncResult);

        #endregion

        #region  GetSubscriptionAttribute

        /// <summary>
        /// GetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// 
        /// <returns>The response returned by the MNS GetSubscriptionAttribute service.</returns>
        /// <exception cref="SubscriptionNotExist">
        /// The subscription name you provided is not exist.
        /// </exception>
        GetSubscriptionAttributeResponse GetSubscriptionAttribute(string subscriptionName);

        /// <summary>
        /// GetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetSubscriptionAttribute service.</param>
        /// 
        /// <returns>The response returned by the MNS GetSubscriptionAttribute service.</returns>
        GetSubscriptionAttributeResponse GetSubscriptionAttribute(GetSubscriptionAttributeRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS GetSubscriptionAttribute service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS GetSubscriptionAttribute service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginGetSubscriptionAttribute(GetSubscriptionAttributeRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS GetSubscriptionAttribute service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginGetSubscriptionAttribute.</param>
        /// 
        /// <returns>The response returned by the MNS GetSubscriptionAttribute service.</returns>
        GetSubscriptionAttributeResponse EndGetSubscriptionAttribute(IAsyncResult asyncResult);

        #endregion

        #region  SetSubscriptionAttribute

        /// <summary>
        /// SetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="subscriptionName">The subscription name.</param>
        /// <param name="subscriptionName">The SubscriptionAttributes.</param>
        /// 
        /// <returns>The response returned by the MNS SetSubscriptionAttribute service.</returns>
        /// <exception cref="SubscriptionNotExist">
        /// The subscription name you provided is not exist.
        /// </exception>
        SetSubscriptionAttributeResponse SetSubscriptionAttribute(string subscriptionName, SubscriptionAttributes attributes);

        /// <summary>
        /// SetSubscriptionAttribute
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetSubscriptionAttribute service.</param>
        /// 
        /// <returns>The response returned by the MNS SetSubscriptionAttribute service.</returns>
        SetSubscriptionAttributeResponse SetSubscriptionAttribute(SetSubscriptionAttributeRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS SetSubscriptionAttribute service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS SetSubscriptionAttribute service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginSetSubscriptionAttribute(SetSubscriptionAttributeRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS SetSubscriptionAttribute service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginSetSubscriptionAttribute.</param>
        /// 
        /// <returns>The response returned by the MNS SetSubscriptionAttribute service.</returns>
        SetSubscriptionAttributeResponse EndSetSubscriptionAttribute(IAsyncResult asyncResult);

        #endregion

        #region  ListSubscription

        /// <summary>
        /// Returns a list of subscriptions with specified prefix.
        /// </summary>
        /// <param name="subscriptionNamePrefix">A string to use for filtering the list results.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix);

        /// <summary>
        /// Returns a list of subscriptions with specified prefix.
        /// </summary>
        /// <param name="subscriptionNamePrefix">A string to use for filtering the list results.</param>
        /// <param name="marker">A string to use for marking the start point of next paging request.</param>
        /// <param name="maxReturns">A string to use for limiting the max returns in the single request.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(string subscriptionNamePrefix, string marker, uint maxReturns);

        /// <summary>
        /// Returns a list of your subscriptions with specified request object.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListSubscription service.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse ListSubscription(ListSubscriptionRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS ListSubscription service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS ListSubscription service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginListSubscription(ListSubscriptionRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS ListSubscription service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginListSubscription.</param>
        /// 
        /// <returns>The response returned by the MNS ListSubscription service.</returns>
        ListSubscriptionResponse EndListSubscription(IAsyncResult asyncResult);

        #endregion

        #region  PublishMessage

        /// <summary>
        /// Delivers a message to the specified topic.
        /// </summary>
        /// 
        /// <param name="messageBody">The message to send.</param>
        /// 
        /// <returns>The response returned by the MNS PublishMessage service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        PublishMessageResponse PublishMessage(string messageBody);

        /// <summary>
        /// Publish a message to this topic.
        /// </summary>
        /// <param name="request">The request object to be sent to MNS PublishMessage service.</param>
        /// 
        /// <returns>The response returned by the MNS PublishMessage service.</returns>
        /// <exception cref="TopicNotExistException">
        /// The topic name you provided is not exist.
        /// </exception>
        PublishMessageResponse PublishMessage(PublishMessageRequest request);

        /// <summary>
        /// Begins an asynchronous request to MNS PublishMessage service.
        /// </summary>
        /// 
        /// <param name="request">The request object to be sent to MNS PublishMessage service.</param>
        /// <param name="callback">The AsyncCallback delegate.</param>
        /// <param name="state">The state object for this request.</param>
        /// 
        /// <returns>An IAsyncResult that references the asynchronous request for a response.</returns>
        IAsyncResult BeginPublishMessage(PublishMessageRequest request, AsyncCallback callback, object state);

        /// <summary>
        /// Ends an asynchronous request for MNS PublishMessage service.
        /// </summary>
        /// 
        /// <param name="asyncResult">The IAsyncResult returned by the call to BeginPublishMessage.</param>
        /// 
        /// <returns>The response returned by the MNS PublishMessage service.</returns>
        PublishMessageResponse EndPublishMessage(IAsyncResult asyncResult);

        #endregion

        #region
        /// <summary>
        /// Generate Queue Endpoint, for subscription with a queue endpoint
        /// </summary>
        /// 
        /// <param name="queueName">The queue to receive topic messages.</param>
        /// 
        /// <returns>The queue endpoint.</returns>
        string GenerateQueueEndpoint(string queueName);

        /// <summary>
        /// Generate Mail Endpoint, for subscription with a mail endpoint
        /// </summary>
        /// 
        /// <param name="mailAddress">The mailAddress to receive topic messages.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateMailEndpoint(string mailAddress);

        /// <summary>
        /// Generate anonymous Sms Endpoint, for subscription with a sms endpoint
        /// </summary>
        /// 
        /// <param name="phone">The phone to receive sms.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateSmsEndpoint(string phone);

        /// <summary>
        /// Generate anonymous Sms Endpoint, for subscription with a sms endpoint
        /// </summary>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateSmsEndpoint();

        /// <summary>
        /// Generate anonymous BatchSms Endpoint, for subscription with a BatchSms endpoint
        /// </summary>
        /// 
        /// <param name="mailAddress">The mailAddress to receive topic messages.</param>
        /// 
        /// <returns>The Mail endpoint.</returns>
        string GenerateBatchSmsEndpoint();
        #endregion
    }
}
