using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aliyun.MNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aliyun.MNS.Model;

namespace Aliyun.MNS.Tests
{
    [TestClass()]
    public class TopicTests
    {
        private const string _accessKeyId = "<your access key id>";
        private const string _secretAccessKey = "<your secret access key>";
        private const string _endpoint = "<valid endpoint>";

        private IMNS client;

        [TestInitialize()]
        public void SetUp()
        {
            client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);
            client.CreateTopic("UTTopic");
            try
            {
                client.DeleteTopic("UTTopic2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        [TestMethod()]
        public void SetAttributesTest()
        {
            Topic topic = client.GetNativeTopic("UTTopic");

            var resp = topic.GetAttributes();
            var originalLoggingEnabled = resp.Attributes.LoggingEnabled;

            TopicAttributes qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(originalLoggingEnabled, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = false };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = true };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes();
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = false };
            topic.SetAttributes(qa);
            resp = topic.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);

            qa = new TopicAttributes() { LoggingEnabled = true };
            var req = new CreateTopicRequest() { TopicName = "UTTopic2", Attributes = qa };
            Topic topic2 = client.CreateTopic(req);
            resp = topic2.GetAttributes();
            Assert.AreEqual(true, resp.Attributes.LoggingEnabled);

            client.DeleteTopic("UTTopic2");

            qa = new TopicAttributes() { LoggingEnabled = false };
            req = new CreateTopicRequest() { TopicName = "UTTopic2", Attributes = qa };
            topic2 = client.CreateTopic(req);
            resp = topic2.GetAttributes();
            Assert.AreEqual(false, resp.Attributes.LoggingEnabled);
        }

        [TestCleanup()]
        public void CleanUp()
        {
            client.DeleteTopic("UTTopic");
            try
            {
                client.DeleteTopic("UTTopic2");
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}