using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bugmine.Core.Configuration;
using Bugmine.Core.Repositories.Contracts;

namespace Bugmine.Core.Services
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepository;

		public UserService(IUserRepository userRepo)
		{
			_userRepository = userRepo;
		}

		public bool IsApiKeyValid(string apiKey)
		{
			apiKey.ThrowIfNullOrEmpty();

			var isValid = _userRepository.isUserValid(apiKey);

			if (isValid)
			{
				var appData = ApplicationData.Current;
				appData.SetApiKey(apiKey);

				return true;
			}
			return false;
		}
	}
}
