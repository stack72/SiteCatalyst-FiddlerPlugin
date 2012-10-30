using System;
using System.Collections.Generic;
using Fiddler;

namespace FiddlerPlugin.Models
{
	public class SiteCatalystRequest
	{
		public int Id { get; set; }
		public string FiddlerHost { get; set; }
		public string Host { get; set; }
		public string ResponseServer { get; set; }

		public string RawUrl { get; set; }
		public string RawBody { get; set; }

		public string RequestingUrl { get; set; }
		public string ReferringUrl { get; set; }

		public string Channel { get; set; }
		public string PageName { get; set; }
		public string Account { get; set; }
		public string Events { get; set; }

		public DateTime Time { get; set; }

		public SortedList<string, SiteCatalystRequestValue> Props { get; set; }
		public SortedList<string, SiteCatalystRequestValue> eVars { get; set; }
	}
}