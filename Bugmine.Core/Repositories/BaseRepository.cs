using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Repositories
{
	public class BaseRepository
	{
		private Uri baseUri;

		public BaseRepository()
		{
			baseUri = new Uri(ConfigurationManager.AppSettings["Redmine.BaseRedmineUrl"]);
		}

		protected HttpWebRequest ConstructWebRequest(string relativeUrl, string apiKey)
		{
			var request = (HttpWebRequest)WebRequest.Create(new Uri(baseUri, relativeUrl));
			request.Headers.Add("X-Redmine-API-Key", apiKey);

			return request;
		}
	}
}
