using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Repositories.Contracts;

namespace Bugmine.Core.Repositories
{
	public class UserRepository : BaseRepository, IUserRepository
	{
		public bool isUserValid(string apiKey)
		{
			var request = ConstructWebRequest("users.xml");

			using (var response = request.GetResponse())
			{
				//will throw exception if user is not valid
				return true;
			}
		}
	}
}
