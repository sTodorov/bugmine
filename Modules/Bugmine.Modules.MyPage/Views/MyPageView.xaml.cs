using System;
using System.Collections.Generic;
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
		public MyPageView(MyPageViewModel model)
		{
			InitializeComponent();
			DataContext = model;
		}
	}
}
