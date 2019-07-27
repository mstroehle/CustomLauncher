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
using System.Diagnostics;

namespace Launcher
{
	/// <summary>
	/// Interaction logic for LaunchButton.xaml
	/// </summary>
	public partial class LaunchButton : UserControl
	{
		public string ApplicationPath { get; set; }

		public LaunchButton()
		{
			InitializeComponent();
		}

		public void LaunchApplication(object sender, RoutedEventArgs e)
		{
			Process.Start(ApplicationPath);
		}
	}
}
