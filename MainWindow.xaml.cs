using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WindowsInput;

namespace KiepAlphabetScroller
{
    public partial class MainWindow : Window
    {
        private static string[] alphabet = { " ", ".", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
		private static string[] alphabetOptimized = { " ", ".", "E", "A", "I", "O", "U", "Y", "Q", "X", "F", "C", "Z", "J", "W", "P", "B", "M", "K", "H", "V", "G", "L", "S", "D", "R", "T", "N" };
		
		
        InputSimulator inputSimulator = new InputSimulator();

        public MainWindow()
        {
            InitializeComponent();

            this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;


            foreach (string letter in alphabet)
            {
                Label letterLabel = new Label();
                letterLabel.Content = letter;
                MyCarouselControl.Children.Add(letterLabel);
            }

            MyCarouselControl.Width = System.Windows.SystemParameters.PrimaryScreenWidth * 1.5;
            MyCarouselControl.ReInitialize();
        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Label selected = MyCarouselControl.CurrentlySelected as Label;
            if (selected != null)
            {
                string selectedText = selected.Content.ToString();
                Console.WriteLine(selectedText);
                inputSimulator.Keyboard.TextEntry(selectedText);
            }

            // Enable for single letter application
            //System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Label selected = MyCarouselControl.CurrentlySelected as Label;
            if (selected != null)
            {
                selected.Foreground = Brushes.Black;
            }

            if (e.Delta < 0)
            {
                MyCarouselControl.RotateToPreviousElement();
            }
            else
            {
                MyCarouselControl.RotateToNextElement();
            }

            selected = MyCarouselControl.CurrentlySelected as Label;
            if (selected != null)
            {
                selected.Foreground = Brushes.Red;
            }
        }
    }
}
