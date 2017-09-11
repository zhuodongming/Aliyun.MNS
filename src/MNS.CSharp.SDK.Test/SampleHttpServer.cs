using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aliyun.MNS.PerfTest
{
    class SampleHttpServer
    {
        static async Task<bool> CheckSignature(HttpListenerRequest request)
        {
            String dateStr = request.Headers.Get("Date");
            if (dateStr == null)
            {
                return false;
            }
            var date = DateTimeOffset.Parse(dateStr).UtcDateTime;
            if ((date > DateTime.UtcNow && (date - DateTime.UtcNow).TotalMinutes > 15)
                || (date < DateTime.UtcNow && (DateTime.UtcNow - date).TotalMinutes > 15))
            {
                return false;
            }
            // now get SignStr
            Console.WriteLine(request.Headers);

            StringBuilder sb = new StringBuilder();
            sb.Append(request.HttpMethod.ToUpper());
            sb.Append("\n");
            sb.Append(request.Headers.Get("Content-md5"));
            sb.Append("\n");
            sb.Append(request.Headers.Get("Content-Type"));
            sb.Append("\n");
            sb.Append(request.Headers.Get("Date"));
            sb.Append("\n");
            
            SortedList<String, String> list = new SortedList<String, String>();
            foreach (String key in request.Headers.AllKeys)
            {
                if (key.StartsWith("x-mns-"))
                {
                    list.Add(key, request.Headers.Get(key));
                }
            }
            for (int i = 0; i < list.Count; ++i)
            {
                sb.Append(list.Keys[i]);
                sb.Append(":");
                sb.Append(list.Values[i]);
                sb.Append("\n");
            }
            sb.Append(request.RawUrl);

            String signStr = sb.ToString();
            Console.WriteLine(signStr);

            // now get cert
            String certUrl = request.Headers.Get("x-mns-signing-cert-url");
            byte[] certUrlBytes = Convert.FromBase64String(certUrl);
            certUrl = Encoding.UTF8.GetString(certUrlBytes);

            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(certUrl))
            using (HttpContent content = response.Content)
            {
                byte[] certBytes = await content.ReadAsByteArrayAsync();
                X509Certificate2 certificate = new X509Certificate2(certBytes);
                var cert2 = DotNetUtilities.FromX509Certificate(certificate);

                var signer = SignerUtilities.GetSigner("SHA1withRSA");
                signer.Init(false, cert2.GetPublicKey());

                String sigStr = request.Headers.Get("Authorization");
                sigStr = sigStr.Trim(' ', '\r', '\n');
                Console.WriteLine(sigStr);
                byte[] sigBytes = Convert.FromBase64String(sigStr);
                byte[] msgBytes = Encoding.UTF8.GetBytes(signStr);
                signer.BlockUpdate(msgBytes, 0, msgBytes.Length);
                return signer.VerifySignature(sigBytes);
            }
        }

        static void Main(string[] args)
        {
            HttpListener httpListener = new HttpListener();

            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            httpListener.Prefixes.Add("http://+:8080/"); // change this ip to your own machine ip
            httpListener.Start();

            new Thread(new ThreadStart(delegate
            {
                while (true)
                {
                    HttpListenerContext httpListenerContext = httpListener.GetContext();
                    httpListenerContext.Response.StatusCode = 200;

                    Task<bool> task = CheckSignature(httpListenerContext.Request);
                    task.Wait();
                    if (task.Result != true)
                    {
                        Console.WriteLine("Signature Mismatch!");
                        httpListenerContext.Response.StatusCode = 403;
                        httpListenerContext.Response.Close();
                        continue;
                    }

                    System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(httpListenerContext.Request.InputStream);
                    while (true)
                    {
                        try
                        {
                            if (!reader.Read())
                                break;
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        switch (reader.NodeType)
                        {
                            case System.Xml.XmlNodeType.Element:
                                switch (reader.LocalName)
                                {
                                    case "TopicOwner":
                                        reader.Read();
                                        Console.WriteLine("TopicOwner is " + reader.Value);
                                        break;
                                    case "TopicName":
                                        reader.Read();
                                        Console.WriteLine("TopicName is " + reader.Value);
                                        break;
                                    case "Subscriber":
                                        reader.Read();
                                        Console.WriteLine("Subscriber is " + reader.Value);
                                        break;
                                    case "SubscriptionName":
                                        reader.Read();
                                        Console.WriteLine("SubscriptionName is " + reader.Value);
                                        break;
                                    case "MessageId":
                                        reader.Read();
                                        Console.WriteLine("MessageId is " + reader.Value);
                                        break;
                                    case "MessageMD5":
                                        reader.Read();
                                        Console.WriteLine("MessageMD5 is " + reader.Value);
                                        break;
                                    case "Message":
                                        reader.Read();
                                        Console.WriteLine("Message is " + reader.Value);
                                        break;
                                    case "PublishTime":
                                        reader.Read();
                                        Console.WriteLine("PublishTime is " + reader.Value);
                                        break;
                                }
                                break;
                        }
                    }
                    reader.Close();

                    

                    httpListenerContext.Response.Close();
                }
            })).Start();

            Console.Read();
        }
    }
}
