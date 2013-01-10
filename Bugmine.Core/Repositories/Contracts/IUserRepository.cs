using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Repositories.Contracts
{
	public interface IUserRepository
	{
		bool isUserValid(string apiKey);

    int GetUserID(string apiKey);
  }
}
