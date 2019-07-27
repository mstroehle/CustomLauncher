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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace Launcher
{
	/// <summary>
	/// Interaction logic for ProgramEntryDataWindow.xaml
	/// </summary>
	public partial class ProgramEntryDataWindow : Window
	{
		public MainWindow Ref { get; set; }

		public ProgramEntryDataWindow()
		{
			InitializeComponent();
		}

		private void SearchForFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == true)
			{
				ProgramPathTextBox.AppendText(ofd.FileName);
				ProgramNameTextBox.AppendText(System.IO.Path.GetFileName(ofd.FileName));
			}
		}

		private void SearchForImage_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			if (ofd.ShowDialog() == true)
			{
				ImageBackgroundTextBox.AppendText(ofd.FileName);
			}
		}

		private void Cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void Continue_Click(object sender, RoutedEventArgs e)
		{
			string path = ProgramPathTextBox.Text;
			string name = ProgramNameTextBox.Text;
			string imagePath = ImageBackgroundTextBox.Text;

			Ref.CreateNewButton(new ProgramData(path, name, imagePath));

			this.Close();
		}
	}
}
