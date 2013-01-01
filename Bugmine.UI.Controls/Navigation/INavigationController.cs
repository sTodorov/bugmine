using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugmine.UI.Controls.Navigation
{
	public interface INavigationController
	{
		/// <summary>
		/// Navigates to the main view
		/// </summary>
		void NavigateToMainView();

		/// <summary>
		/// Navigates to the login view
		/// </summary>
		void NavigateToLoginView();
	}
}
