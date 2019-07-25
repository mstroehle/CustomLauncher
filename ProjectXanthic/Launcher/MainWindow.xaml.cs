﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			debugTextBox.AppendText(this.Width + ":" + this.Height + '\n');

			for (int i = 0; i < 30; i++)
			{
				Button button = new Button();
				button.Width = 300;
				button.Height = 38;
				button.Content = "Button " + i;
				button.HorizontalAlignment = HorizontalAlignment.Left;
				
				StackPanelProgramList.Children.Add(button);
			}
		}
	}
}
