using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bugmine.Core.Redmine
{
	public class RedmineUrlManager
	{
		private Uri _baseUrl;
		private const string issuesJsonUrl = "issues.json";
		private const string issuesUrl = "issues";


		public RedmineUrlManager()
		{
			_baseUrl = new Uri(ConfigurationManager.AppSettings["Redmine.BaseRedmineUrl"]);
		}

		public Uri GetTicketsUrl(object @params = null)
		{
			Uri uri = null;
			string relativeUrl = issuesJsonUrl;

			if (@params != null)
				relativeUrl = relativeUrl + "?" + ConstructQueryString(@params);

			Uri.TryCreate(_baseUrl, relativeUrl, out uri);

			return uri;
		}

		public Uri GetRedmineTicketUrl(int ticketID)
		{
			return new Uri(_baseUrl, string.Format("{0}/{1}", issuesUrl, ticketID));
		}

		private string ConstructQueryString(object @params)
		{
			var type = @params.GetType();
			var props = type.GetProperties();
			var pairs = props.Select(x => x.Name + "=" + x.GetValue(@params, null)).ToArray();
			return string.Join("&", pairs);
		}
	}
}
