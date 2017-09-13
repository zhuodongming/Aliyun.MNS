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
    public class MNSClientTests
    {
        private const string _accessKeyId = "<your access key id>";
        private const string _secretAccessKey = "<your secret access key>";
        private const string _endpoint = "<valid endpoint>";

        [TestMethod()]
        public void SetAccountAttributesTest()
        {
            IMNS client = new Aliyun.MNS.MNSClient(_accessKeyId, _secretAccessKey, _endpoint);

            var resp = client.GetAccountAttributes();
            var originalLoggingBucket = resp.Attributes.LoggingBucket;

            AccountAttributes aa1 = new AccountAttributes();
            client.SetAccountAttributes(aa1);
            resp = client.GetAccountAttributes();
            Assert.AreEqual(originalLoggingBucket, resp.Attributes.LoggingBucket);

            AccountAttributes aa2 = new AccountAttributes() { LoggingBucket = "Test" };
            client.SetAccountAttributes(aa2);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa3 = new AccountAttributes();
            client.SetAccountAttributes(aa3);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa4 = new AccountAttributes() { LoggingBucket = "Test" };
            client.SetAccountAttributes(aa4);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("Test", resp.Attributes.LoggingBucket);

            AccountAttributes aa5 = new AccountAttributes() { LoggingBucket = "" };
            client.SetAccountAttributes(aa5);
            resp = client.GetAccountAttributes();
            Assert.AreEqual("", resp.Attributes.LoggingBucket);
        }
    }
}