using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aliyun.MNS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aliyun.MNS.Model.Tests
{
    [TestClass()]
    public class SmsAttributesTests
    {
        [TestMethod()]
        public void ToJsonTest()
        {
            SmsAttributes smsAttributes = new SmsAttributes();
            smsAttributes.FreeSignName = "陈舟锋";
            smsAttributes.TemplateCode = "SMS_15535414";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("name", "CSharpSingle");
            smsAttributes.Receiver = "13735576932";
            smsAttributes.SmsParams = param;

            Assert.AreEqual("{\"FreeSignName\":\"陈舟锋\",\"Receiver\":\"13735576932\",\"SmsParams\":\"{\\\"name\\\": \\\"CSharpSingle\\\"}\",\"TemplateCode\":\"SMS_15535414\"}",
                smsAttributes.ToJson());
        }
    }
}