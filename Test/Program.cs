using System;
using System.Collections.Generic;
using Lampon.Tools.EmailHelper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Email email = new Email();
            email.FromMail = "notice@joinhead.com";
            email.ToMail = new List<string> { "670205545@qq.com", "xucl@joinhead.com.cn" };
            email.Body = "hello";
            email.Host = "smtp.joinhead.com";
            email.PassWord = "Ntc8199";
            email.Subject = "测试邮件";
            email.Send();
            Console.WriteLine("Hello World!");
        }
    }
}
