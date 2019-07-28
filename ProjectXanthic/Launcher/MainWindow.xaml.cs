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
using System.IO;
using System.ComponentModel;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		List<ProgramData> programDataList;
		string ProgramDataFilePath;

        public MainWindow()
        {
            InitializeComponent();

			programDataList = new List<ProgramData>();
			ProgramDataFilePath = "ProgramData.txt";

			ReadInData();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ProgramEntryDataWindow popupWindow = new ProgramEntryDataWindow();
			popupWindow.Ref = this;
			popupWindow.Show();
		}

		private void ChangeDisplay(object obj, RoutedEventArgs e)
		{
			Button clickedButton = (Button)obj;

			/*
			 * Parse button name to get the index of its data
			 * Button naming convention is Button_1, Button_2 ect
			 */

			string[] split = clickedButton.Name.Split('_');
			int index = Int32.Parse(split[1]);

			debugTextBox.AppendText("\nindex: " + programDataList[index].ProgramName);

			ProgramLaunchButton.ApplicationPath = programDataList[index].ProgramPath;

			Background.DisplayImage.Source = new BitmapImage(new Uri(programDataList[index].BackgroundImagePath, UriKind.Relative));
		}

		private void ReadInData()
		{
			if (!File.Exists(ProgramDataFilePath))
			{
				FileStream fileStream = new FileStream(ProgramDataFilePath, FileMode.Create, FileAccess.ReadWrite);

				debugTextBox.AppendText("Creating program data file\n");
				fileStream.Close();

				return;
			}

			// Check if the file contents are zero to prevent the program from crashing if it is zero
			if (new FileInfo(ProgramDataFilePath).Length == 0) return;

			string[] fileData = File.ReadAllLines(ProgramDataFilePath);

			int i = 0;
			foreach(string line in fileData)
			{
				string[] split = line.Split(',');

				ProgramData data = new ProgramData(split[0], split[1], split[2]);
				programDataList.Add(data);

				Button button = new Button();
				button.Name = "Button_" + i;
				button.Content = split[1];

				button.Width = 300;
				button.Height = 89.88;
				button.HorizontalAlignment = HorizontalAlignment.Left;

				button.Click += new RoutedEventHandler(ChangeDisplay);

				StackPanelProgramList.Children.Add(button);

				i++;
			}
		}

		private void Topaz_Closing(object sender, CancelEventArgs e)
		{
			StreamWriter sw = new StreamWriter(ProgramDataFilePath);

			foreach(ProgramData pd in programDataList)
			{
				string dataToWrite = pd.ProgramPath + ',' + pd.ProgramName + ',' + pd.BackgroundImagePath;
				sw.WriteLine(dataToWrite);
			}

			sw.Close();
		}

		public void CreateNewButton(ProgramData data)
		{
			programDataList.Add(data);

			Button button = new Button();
			button.Name = "Button_" + (programDataList.Count - 1);
			button.Content = data.ProgramName;

			button.Width = 300;
			button.Height = 89.88;
			button.HorizontalAlignment = HorizontalAlignment.Left;

			button.Click += new RoutedEventHandler(ChangeDisplay);

			StackPanelProgramList.Children.Add(button);
		}
	}
}
