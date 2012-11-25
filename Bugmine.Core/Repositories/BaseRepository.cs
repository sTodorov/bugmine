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
		protected string ApiKey { get; private set; }
		private Uri baseUri;

		public BaseRepository()
			: this(null)
		{ }

		public BaseRepository(string apiKey)
		{
			ApiKey = apiKey;
			baseUri = new Uri(ConfigurationManager.AppSettings["Redmine.BaseRedmineUrl"]);
		}

		protected HttpWebRequest ConstructWebRequest(string relativeUrl)
		{
			var request = (HttpWebRequest)WebRequest.Create(new Uri(baseUri, relativeUrl));
			request.Headers.Add("X-Redmine-API-Key", ApiKey);

			return request;
		}
	}
}
