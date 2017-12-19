using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20170525;
using System;
using System.Threading.Tasks;

namespace AliyunSmsDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string regionId = "cn-hangzhou";
            string accessKeyId = "xxxxxxxx";
            string accessKeySecret = "xxxxxxxxxxxxxxxxxxxxxxxx";
            string signName = "xxxxxxxxxx";
            string phoneNumbers = "15xxxxxxxxx";
            string templateCode = "SMS_73985016";
            string templateParam = "{\"code\":\"123456\"}";


            IClientProfile clientProfile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            DefaultProfile.AddEndpoint(regionId, regionId, "Dysmsapi", "dysmsapi.aliyuncs.com");

            IAsyncAcsClient acsClient = new DefaultAcsClient(clientProfile);

            var request = new SendSmsRequest
            {
                SignName = signName,
                TemplateCode = templateCode,
                PhoneNumbers = phoneNumbers,
                TemplateParam = templateParam
            };

            try
            {
                var response = await acsClient.GetAcsResponseAsync(request);

                Console.WriteLine(response.Code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
