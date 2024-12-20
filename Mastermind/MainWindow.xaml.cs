﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Mastermind
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

        int atempts = 0;
        int correctNumberOne;
        int correctNumberTwo;
        int correctNumberThree;
        int correctNumberFour;
        int actualNumberOne;
        int actualNumberTwo;
        int actualNumberThree;
        int actualNumberFour;

        private void mastermindCode_Loaded(object sender, RoutedEventArgs e)
        {
            mastermindCode.Title = $"Poging:";
            StringBuilder colorCode = new StringBuilder();
            Random color = new Random();
            for (int i = 1; i <= 4; i++)
            {
                int colorNumber = color.Next(1, 7);
                if(i == 1)
                {
                    correctNumberOne = colorNumber;
                }
                if(i == 2)
                {
                    correctNumberTwo = colorNumber;
                }
                if(i == 3)
                {
                    correctNumberThree = colorNumber;
                }
                if(i == 4)
                {
                    correctNumberFour = colorNumber;
                }
                switch (colorNumber)
                {
                    case 1:
                        colorCode.Append("Wit, ");
                        break;
                    case 2:
                        colorCode.Append("Rood, ");
                        break;
                    case 3:
                        colorCode.Append("Orangje, ");
                        break;
                    case 4:
                        colorCode.Append("Geel, ");
                        break;
                    case 5:
                        colorCode.Append("Groen, ");
                        break;
                    case 6:
                        colorCode.Append("Blauw, ");
                        break;
                }
            }
            colorCode.Length -= 2;
            correctCodeTextBox.Text = colorCode.ToString();
        }


        SolidColorBrush white = new SolidColorBrush(Colors.White);
        SolidColorBrush transparent = new SolidColorBrush(Colors.Transparent);
        SolidColorBrush red = new SolidColorBrush(Colors.Red);
        SolidColorBrush orange = new SolidColorBrush(Colors.Orange);
        SolidColorBrush yellow = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush green = new SolidColorBrush(Colors.Green);
        SolidColorBrush blue = new SolidColorBrush(Colors.Blue);
        SolidColorBrush darkRed = new SolidColorBrush(Colors.DarkRed);
        SolidColorBrush wheat = new SolidColorBrush(Colors.Wheat);

        private void ComboBox_Selection(object sender, SelectionChangedEventArgs e)
        {
            if (sender == firstComboBox && firstComboBox.SelectedItem != null)
            {
                switch (firstComboBox.SelectedIndex)
                {
                    case 0:
                        firstColor.Background = white;
                        actualNumberOne = 1;
                        break;
                    case 1:
                        firstColor.Background = red;
                        actualNumberOne = 2;
                        break;
                    case 2:
                        firstColor.Background = orange;
                        actualNumberOne = 3;
                        break;
                    case 3:
                        firstColor.Background = yellow;
                        actualNumberOne = 4;
                        break;
                    case 4:
                        firstColor.Background = green;
                        actualNumberOne = 5;
                        break;
                    case 5:
                        firstColor.Background = blue;
                        actualNumberOne = 6;
                        break;
                }
            }
            if (sender == secondComboBox)
            {
                switch (secondComboBox.SelectedIndex)
                {
                    case 0:
                        secondColor.Background = white;
                        actualNumberTwo = 1;
                        break;
                    case 1:
                        secondColor.Background = red;
                        actualNumberTwo = 2;
                        break;
                    case 2:
                        secondColor.Background = orange;
                        actualNumberTwo = 3;
                        break;
                    case 3:
                        secondColor.Background = yellow;
                        actualNumberTwo = 4;
                        break;
                    case 4:
                        secondColor.Background = green;
                        actualNumberTwo = 5;
                        break;
                    case 5:
                        secondColor.Background = blue;
                        actualNumberTwo = 6;
                        break;
                }
            }
            if (sender == thirdComboBox)
            {
                switch (thirdComboBox.SelectedIndex)
                {
                    case 0:
                        thirdColor.Background = white;
                        actualNumberThree = 1;
                        break;
                    case 1:
                        thirdColor.Background = red;
                        actualNumberThree = 2;
                        break;
                    case 2:
                        thirdColor.Background = orange;
                        actualNumberThree = 3;
                        break;
                    case 3:
                        thirdColor.Background = yellow;
                        actualNumberThree = 4;
                        break;
                    case 4:
                        thirdColor.Background = green;
                        actualNumberThree = 5;
                        break;
                    case 5:
                        thirdColor.Background = blue;
                        actualNumberThree = 6;
                        break;
                }
            }
            if (sender == fourthComboBox)
            {
                switch (fourthComboBox.SelectedIndex)
                {
                    case 0:
                        fourthColor.Background = white;
                        actualNumberFour = 1;
                        break;
                    case 1:
                        fourthColor.Background = red;
                        actualNumberFour = 2;
                        break;
                    case 2:
                        fourthColor.Background = orange;
                        actualNumberFour = 3;
                        break;
                    case 3:
                        fourthColor.Background = yellow;
                        actualNumberFour = 4;
                        break;
                    case 4:
                        fourthColor.Background = green;
                        actualNumberFour = 5;
                        break;
                    case 5:
                        fourthColor.Background = blue;
                        actualNumberFour = 6;
                        break;
                }


            }
        }

        DateTime startTime = DateTime.Now;
        DispatcherTimer timer = new DispatcherTimer();
        //Deze methode start de countdown met een interval van 1
        private void Start_Countdown()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            //aanmaken van de Timer_Tick methode
            timer.Tick += Timer_Tick;
            timer.Start();

            startTime = DateTime.Now;
        }

        //De timer tickt iedere seconden en na 10 seconder voert die de methode Stop_Countdown uit
        private void Timer_Tick(object? sender, EventArgs e)
        {
            TimeSpan interval = DateTime.Now - startTime;

            timerTextBox.Text = interval.ToString("ss");
            string tien = "10";
            if (interval.ToString("ss") == tien)
            {
                Stop_Countdown();
            }
        }
        
        //Deze methode stops de countdown en laat de speler weten dat hij zijn beurt verloren heeft
        private void Stop_Countdown()
        {
            MessageBox.Show("Beurt verloren");
            timer.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Start_Countdown();
            atempts ++;
            mastermindCode.Title = $"Poging: {atempts.ToString()}";
            string correntCode = $"{correctNumberOne}{correctNumberTwo}{correctNumberThree}{correctNumberFour}";
            string actualCode = $"{actualNumberOne}{actualNumberTwo}{actualNumberThree}{actualNumberFour}";
            if (correctNumberOne == actualNumberOne)
            {
                firstColor.BorderBrush = darkRed;
            }
            else if (correntCode.Contains($"{actualNumberOne}"))
            {
                firstColor.BorderBrush = wheat;
            }
            else
            {
                firstColor.BorderBrush = transparent;
            }
            if (correctNumberTwo == actualNumberTwo)
            {
                secondColor.BorderBrush = darkRed;
            }
            else if (correntCode.Contains($"{actualNumberTwo}"))
            {
                secondColor.BorderBrush = wheat;
            }
            else
            {
                secondColor.BorderBrush = transparent;
            }
            if (correctNumberThree == actualNumberThree)
            {
                thirdColor.BorderBrush = darkRed;
            }
            else if (correntCode.Contains($"{actualNumberThree}"))
            {
                thirdColor.BorderBrush = wheat;
            }
            else
            {
                thirdColor.BorderBrush = transparent;
            }
            if (correctNumberFour == actualNumberFour)
            {
                fourthColor.BorderBrush = darkRed;
            }
            else if (correntCode.Contains($"{actualNumberFour}"))
            {
                fourthColor.BorderBrush = wheat;
            }
            else
            {
                fourthColor.BorderBrush = transparent;
            }
            
        }

        //Maakt debug vissible of invissible
        private void Toggle_Debug()
        {
            if (correctCodeTextBox.Visibility == Visibility.Visible)
            {
                correctCodeTextBox.Visibility = Visibility.Hidden;
            }
            else
            {
                correctCodeTextBox.Visibility = Visibility.Visible;
            }
        }

        private void mastermindCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F12)
            {
                Toggle_Debug();
            }
        }
    }
}