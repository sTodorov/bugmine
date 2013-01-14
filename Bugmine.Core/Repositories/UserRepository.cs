using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Redmine.Parsers;
using Bugmine.Core.Repositories.Contracts;

namespace Bugmine.Core.Repositories
{
	public class UserRepository : BaseRepository, IUserRepository
	{
		public bool isUserValid(string apiKey)
		{
			var request = ConstructRedmineRequest(RedmineUrlManager.GetTicketsUrl(), apiKey);

			using (var response = request.GetResponse())
			{
				//will throw exception if user is not valid
				return true;
			}
		}


		public int GetUserID(string apiKey)
		{
			var request = ConstructRedmineRequest(RedmineUrlManager.GetCurrentUserUrl(), apiKey);
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
			{
				using (var reader = new StreamReader(response.GetResponseStream()))
				{
					string json = reader.ReadToEnd();

					var userInfo = Parser.ParseCurrentUserResult(json);

					return userInfo.user.id;
				}
			}
		}
	}
}
