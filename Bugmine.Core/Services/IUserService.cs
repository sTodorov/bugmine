using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Services
{
	public interface IUserService
	{
		bool CheckAndLoginIfValid(string apiKey, int userID);
	}
}
