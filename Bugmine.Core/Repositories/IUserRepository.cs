using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.Core.Repositories
{
	public interface IUserRepository
	{
		bool ValidateUser(string username, string password);
	}
}
