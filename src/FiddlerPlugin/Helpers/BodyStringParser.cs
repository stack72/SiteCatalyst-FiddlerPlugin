using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

namespace FiddlerPlugin.Helpers
{
	public class BodyStringParser : ValueParser
	{
		public override void ParseValues(string input)
		{
			try
			{
				Values = ParseBodyString(input);
			}
			catch (Exception)
			{
				Values = null;
			}
		}

		public NameValueCollection ParseBodyString(string body)
		{
			Encoding encoding = Encoding.UTF8;
			NameValueCollection values = new NameValueCollection();
			if (!string.IsNullOrEmpty(body))
			{
				string[] paramPairs = body.Split('&');
				foreach (string pair in paramPairs)
				{
					string key;
					string value;
					int index = pair.IndexOf("=", StringComparison.InvariantCulture);
					if (index < 0)
					{
						key = HttpUtility.UrlDecode(pair.Trim(), encoding);
						value = string.Empty;
					}
					else
					{
						key = HttpUtility.UrlDecode(pair.Substring(0, index), encoding);
						value = HttpUtility.UrlDecode(pair.Substring(index + 1), encoding);
					}

					if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
					{
						values.Add(key, value);
					}
				}
			}
			return values;
		}
	}
}
