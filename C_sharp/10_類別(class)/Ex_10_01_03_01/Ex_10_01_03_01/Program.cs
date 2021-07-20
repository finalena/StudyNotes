using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_10_01_03_01
{
	class Program
	{
		static void Main(string[] args)
		{
			string smtp = "mail.hinet.net";
			string account = "allen";
			string password = "123";

			var helper = new EmailHelper(smtp, account, password);
			helper.Send("allen@gmail.com", "simon@yahoo.com.tw", "信件主旨", "信件內容..");
			helper.Send("allen@gmail.com", "tom@yahoo.com.tw", "商品出貨通知", "您好, 訂購的商品已寄出...");

		}
	}

	public class EmailHelper
	{
		private readonly string _smtpServer;
		private readonly string _account;
		private readonly string _password;

		public EmailHelper(string smtpServer, string account, string password)
		{
			_smtpServer = smtpServer;
			_account = account;
			_password = password;
		}

		
		public void Send(string from, string to, string subject, string body)
		{
			// 先利用 smtpServer, account, password 資訊,登入 email server 
			// 在這裡寄出 Email, 
		}
	}
}
