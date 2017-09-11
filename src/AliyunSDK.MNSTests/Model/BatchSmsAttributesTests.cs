using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aliyun.MNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model.Tests
{
    [TestClass()]
    public class BatchSmsAttributesTests
    {
        [TestMethod()]
        public void ToJsonTest()
        {
            BatchSmsAttributes batchSmsAttributes = new BatchSmsAttributes();
            batchSmsAttributes.FreeSignName = "111";
            batchSmsAttributes.TemplateCode = "222";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("name", "3\"555\"33");
            batchSmsAttributes.AddReceiver("444", param);

            Assert.AreEqual(
                "{\"FreeSignName\":\"111\",\"SmsParams\":\"{\\\"444\\\":{\\\"name\\\":\\\"3\\\\\\\"555\\\\\\\"33\\\"}}\",\"TemplateCode\":\"222\",\"Type\":\"multiContent\"}",
                batchSmsAttributes.ToJson());
        }
    }
}