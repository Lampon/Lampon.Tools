using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Lampon.Tools.EmailHelper
{

    public class Email
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        public void Send()
        {
            MailMessage mMailMessage = new MailMessage();
            SmtpClient mSmtpClient = new SmtpClient();
            foreach (var item in ToMail)
            {
                mMailMessage.To.Add(item);
            }
            mMailMessage.From = new MailAddress(FromMail);
            mMailMessage.Subject = Subject;
            mMailMessage.Body = Body;
            mMailMessage.IsBodyHtml = true;
            mMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mSmtpClient.Host = Host;
            if (AttachmentList != null && AttachmentList.Count != 0)
            {
                foreach (var attachment in AttachmentList)
                {
                    mMailMessage.Attachments.Add(attachment);
                }
            }
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential(FromMail, PassWord);
            mSmtpClient.Credentials = nc.GetCredential(mSmtpClient.Host, mSmtpClient.Port, "NTLM");
            mSmtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            mSmtpClient.Send(mMailMessage);
        }
        /// <summary>
        /// 发件箱账号
        /// </summary>
        public string FromMail { get; set; }
        /// <summary>
        /// 发件箱密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 收件箱地址
        /// </summary>
        public List<string> ToMail { get; set; }
        /// <summary>
        /// 发件箱的邮件服务器地址
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public List<Attachment> AttachmentList { get; set; }
    }
}