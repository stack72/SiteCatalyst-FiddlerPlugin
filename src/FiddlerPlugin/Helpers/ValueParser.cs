using System;
using System.Collections.Specialized;

namespace FiddlerPlugin.Helpers
{
	public abstract class ValueParser
	{
		public NameValueCollection Values;

		public ValueParser()
		{
		}

		public ValueParser(string input)
		{
			ParseValues(input);
		}


		public string GetValueIfExists(string key)
		{
			string value = null;
			if (Values != null && Values.HasKeys())
			{
				value = Values.Get(key);
			}
			return value;
		}

		public abstract void ParseValues(string input);
	}
}