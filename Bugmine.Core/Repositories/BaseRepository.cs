using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Redmine;

namespace Bugmine.Core.Repositories
{
	public class BaseRepository
	{
		private Uri baseUri;
		protected RedmineUrlManager RedmineUrlManager;

		public BaseRepository()
		{
			RedmineUrlManager = new RedmineUrlManager();
		}

		protected HttpWebRequest ConstructRedmineRequest(Uri redmineUri, string apiKey)
		{
			var request = (HttpWebRequest)WebRequest.Create(redmineUri);
			request.Headers.Add("X-Redmine-API-Key", apiKey);

			return request;
		}
	}
}
