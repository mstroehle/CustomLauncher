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

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		List<ProgramData> programDataList;

        public MainWindow()
        {
            InitializeComponent();

			programDataList = new List<ProgramData>();

			for (int i = 0; i < 20; i++)
			{
				ProgramData programData = new ProgramData("path " + i, "name " + i, "Img/DOTD.jpg");
				programDataList.Add(programData);
			}
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			for (int i = 0; i < 20; i++)
			{
				Button button = new Button();
				button.Content = "Button " + i;

				button.Width = 300;
				button.Height = 89.88;
				button.HorizontalAlignment = HorizontalAlignment.Left;

				button.Name = "Button_" + i;
				button.Click += new RoutedEventHandler(ChangeDisplay);

				StackPanelProgramList.Children.Add(button);
			}
		}

		private void Click_Test(object sender, RoutedEventArgs e)
		{
			debugTextBox.AppendText("Clicked\n");

			Background.DisplayImage.Source = new BitmapImage(new Uri("Img/DOTD.jpg", UriKind.Relative));
		}

		private void ChangeDisplay(object obj, RoutedEventArgs e)
		{
			var foo = (Button)obj;

			string[] split = foo.Name.Split('_');
			int index = Int32.Parse(split[1]);

			debugTextBox.AppendText("\nindex: " + programDataList[index].ProgramName);

			Background.DisplayImage.Source = new BitmapImage(new Uri(programDataList[index].BackgroundImagePath, UriKind.Relative));
		}
	}
}
