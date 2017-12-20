#阿里云短信发送

.net standard 2.0
添加async/await支持

示例：

<p>
            
            string regionId = "cn-hangzhou";
            string accessKeyId = "xxxxxxxx";
            string accessKeySecret = "xxxxxxxxxxxxxxxxxxxxxxxx";
            string signName = "xxxxxxxxxx";
            string phoneNumbers = "15xxxxxxxxx";
            string templateCode = "SMS_XXXXX";
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
</p>
