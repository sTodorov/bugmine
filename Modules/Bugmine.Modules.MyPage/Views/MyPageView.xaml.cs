using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bugmine.Modules.MyPage.ViewModels;

namespace Bugmine.Modules.MyPage.Views
{
	/// <summary>
	/// Interaction logic for MyPageView.xaml
	/// </summary>
	public partial class MyPageView : UserControl
	{
		MyPageViewModel _model;

		public MyPageView(MyPageViewModel model)
		{
			InitializeComponent();
			_model = model;
			DataContext = model;
		}

		private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e)
		{
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_model.SortByCommand.Execute(((ComboBox)sender).SelectedValue);
		}
	}
}
