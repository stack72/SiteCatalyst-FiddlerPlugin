using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace FiddlerPlugin.Helpers
{
	public class QueryStringParser : ValueParser
	{
		public override void ParseValues(string input)
		{
			try
			{
				Values = HttpUtility.ParseQueryString(new Uri(input).Query) ?? new NameValueCollection();

				string account = ParseAccountFromUrl(input);
				if (!string.IsNullOrEmpty(account))
				{
					Values.Add("account", account);
				}
			}
			catch (Exception)
			{
				Values = null;
			}
		}

		public static string ParseAccountFromUrl(string requestUrl)
		{
			Uri url = new Uri(requestUrl);

			if (!string.IsNullOrEmpty(url.LocalPath) && url.LocalPath.Contains('/'))
			{
				string[] segments = url.LocalPath.Split('/');

				// Check for the javascript api account.
				// Sample Url: "/b/ss/otcom/1/H.22.1/s196623837016"
				if (segments.Length > 4 && segments[1] == "b" && segments[2] == "ss")
				{
					return segments[3];
				}
			}

			return "";
		}
	}
}
