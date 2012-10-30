using System;
using System.Collections.Generic;
using System.Text;
using Fiddler;
using FiddlerPlugin.Models;
using System.Linq;
using System.Linq.Expressions;

namespace FiddlerPlugin.Helpers
{
	public class SiteCatalystSessionParser
	{
		private QueryStringParser _queryParser = new QueryStringParser();
		private BodyStringParser _bodyParser = new BodyStringParser();

		public SiteCatalystRequest ParseRequest(Session session)
		{
			SiteCatalystRequest request = new SiteCatalystRequest();

			request.Id = session.id;
			request.FiddlerHost = Environment.MachineName.ToLower();
			request.Host = (session.host ?? string.Empty).ToLower();
			request.ResponseServer = session.oResponse["server"] ?? string.Empty;

			if (IsValidSiteCatalystRequest(request))
			{
				request.RawUrl = session.fullUrl;
				request.RawBody = Encoding.UTF8.GetString(session.responseBodyBytes);

				ParseQueryString(request, session.fullUrl);
				ParseBody(request, session);

				return request;
			}

			return null;
		}

		public void ParseQueryString(SiteCatalystRequest request, string url)
		{
			_queryParser.ParseValues(url);
			SetSharedRequestValues(request, _queryParser);
		}

		public void ParseBody(SiteCatalystRequest request, Session session)
		{
			if (session.oRequest.headers.HTTPMethod == "POST" &&
				session.responseBodyBytes != null &&
				session.responseBodyBytes.Length > 0)
			{
				_bodyParser.ParseValues(Encoding.UTF8.GetString(session.responseBodyBytes));
				SetSharedRequestValues(request, _bodyParser);
			}
		}

		private void SetSharedRequestValues(SiteCatalystRequest request, ValueParser parser)
		{
			if (parser.Values != null && parser.Values.Count > 0)
			{
				request.RequestingUrl = _queryParser.GetValueIfExists("g");
				request.ReferringUrl = _queryParser.GetValueIfExists("r");

				request.Channel = _queryParser.GetValueIfExists("ch");
				request.PageName = _queryParser.GetValueIfExists("pageName");
				request.Account = _queryParser.GetValueIfExists("account");
				request.Events = _queryParser.GetValueIfExists("events");

				DateTime time = DateTime.MinValue;
				DateTime.TryParse(_queryParser.GetValueIfExists("t"), out time);
				request.Time = time;

				SetSiteCatalystRequestValues(parser, request.Props, "c", "prop");
				SetSiteCatalystRequestValues(parser, request.Props, "v", "eVar");
			}
		}

		private void SetSiteCatalystRequestValues(ValueParser parser, SortedList<string, SiteCatalystRequestValue> values, string prefix, string newPrefix)
		{
			if (values == null)
			{
				values = new SortedList<string, SiteCatalystRequestValue>();
			}

			List<string> keys = parser.Values.Keys
					.Cast<string>()
					.Where(m => IsSiteCatalystField(m, prefix))
					.Distinct()
					.ToList();

			foreach (string key in keys)
			{
				string value = parser.Values.Get(key) ?? string.Empty;
				int varNumber = GetValueFromKey(key, prefix);
				string name = string.Format("{0}{1}", newPrefix, varNumber);
				if (varNumber > 0 && !string.IsNullOrEmpty(value) && !values.ContainsKey(name))
				{
					values.Add(name, new SiteCatalystRequestValue()
					           	{
					           		Name = name,
									Value = value
					           	});
				}
			}
		}

		private bool IsSiteCatalystField(string key, string prefix)
		{
			return GetValueFromKey(key, prefix) > 0;
		}

		private int GetValueFromKey(string key, string prefix)
		{
			int value = -1;
	
			if (key.StartsWith(prefix))
			{
				string clean = key.Substring(prefix.Length);
				int.TryParse(clean, out value);
			}

			return value;
		}

		private bool IsValidSiteCatalystRequest(SiteCatalystRequest request)
		{
			string host = (request.Host ?? string.Empty).ToLowerInvariant();
			string server = (request.ResponseServer ?? string.Empty).ToLowerInvariant();

			return (!IsFilteredHost(host) && server.Contains("omniture") );
		}

		private bool IsFilteredHost(string host)
		{
			return host.Contains("omniture.com") ||
				   host.Contains("adobetag.com") ||
				   host.Contains("omnituremarketing.");
		}
	}
}
