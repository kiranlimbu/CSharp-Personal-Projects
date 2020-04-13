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
using System.Threading;
using System.Windows.Media.Animation;

namespace VisualAlgorithm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // initialize array storage
        int[] arr = new int[] { };

        // initialize Btn
        Button[] button;

        public MainWindow()
        {
            InitializeComponent();

            intInput.Visibility = Visibility.Hidden;
            stepCount.Visibility = Visibility.Hidden;
            loopCount.Visibility = Visibility.Hidden;
        }

        private void GenerateCard()
        {
            // create random number
            Random rnd = new Random();
            int rndNum = rnd.Next(3, 8);

            // array storage
            arr = new int[rndNum];

            button = new Button[rndNum];


            // get the starting position for the card
            // display panel width - card.width * #ofcard + gap between cards
            double left = (800 - (100 * rndNum + 10 + 10 * rndNum)) / 2;

            // place cards dynamically
            for (int i = 0; i < rndNum; i++)
            {
                button[i] = new Button();

                button[i].FontSize = 16;
                button[i].FontWeight = FontWeights.Bold;

                // generate random number, assign to card, store in array
                int cardNum = rnd.Next(1, 100);
                button[i].Content = cardNum.ToString();
                arr[i] = cardNum;

                button[i].BorderThickness = new Thickness(0);
                button[i].Background = Brushes.White;
                button[i].Width = 100;
                button[i].Height = 150;
                button[i].Margin = new Thickness(left, 0, 0, 0);

                // btn is a child of display panel
                display.Children.Add(button[i]);
                left = 10;
            }
        }

        private void rndBtn_Click(object sender, RoutedEventArgs e)
        {
            // clear display panel
            display.Children.Clear();

            if (arr.Length > 0)
            {
                Array.Clear(arr, 0, arr.Length);
            }

            // call generate card method
            GenerateCard();

        }

        private void manualBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (intInput.Visibility == Visibility.Hidden)
            {
                intInput.Visibility = Visibility.Visible;
            }
            else
            {
                intInput.Visibility = Visibility.Hidden;
            }
        }

        private void bblBtn_Click(object sender, RoutedEventArgs e)
        {
            selBtn.IsEnabled = false;
            bblBtn.IsEnabled = false;
            BubbleSort(arr, button);
            
        }

        private void selBtn_Click(object sender, RoutedEventArgs e)
        {
            bblBtn.IsEnabled = false;
            selBtn.IsEnabled = false;
            SelectionSort(arr, button);
        }

        private void mrgBtn_Click(object sender, RoutedEventArgs e)
        {
            //bblBtn.IsEnabled = false;
            //selBtn.IsEnabled = false;
            //mrgBtn.IsEnabled = false;
            MergeSort(arr, button);
        }
        public async Task BubbleSort(int[] arr, Button[] button)
        {
            int i, j;
            // loop count
            int loopcnt = 0;
            loopCount.Visibility = Visibility.Visible;
            loopCount.Content = "Loop: " + loopcnt;

            // step count
            int stepcnt = 0;
            stepCount.Visibility = Visibility.Visible;
            stepCount.Content = "Steps: " + stepcnt;

            for (i = 0; i < arr.Length; i++)
            {

                for (j = 0; j < arr.Length - 1; j++)
                {
                    // animation begin
                    SolidColorBrush brush = new SolidColorBrush(Colors.White);
                    button[j].Background = brush;
                    button[j + 1].Background = brush;
                    ColorAnimation anima = new ColorAnimation(Colors.White, Colors.Orange, new Duration(TimeSpan.FromSeconds(0.5)));
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, anima);
                    // animation end
                    await Task.Delay(1000);

                    if (arr[j] > arr[j + 1]) // if current is bigger then next
                    {
                        // animation begin
                        button[j].Background = brush;
                        button[j + 1].Background = brush;
                        brush.BeginAnimation(SolidColorBrush.ColorProperty, anima);
                        // animation end
                        await Task.Delay(1000);
                       
                        (button[j].Content, button[j + 1].Content) = (button[j + 1].Content, button[j].Content); // shifts button
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); // shifts array

                        button[j].Background = Brushes.White;
                        button[j + 1].Background = Brushes.White;

                        // update step count
                        stepcnt++;
                        stepCount.Content = "Steps: " + stepcnt;
                    }

                    button[j].Background = Brushes.White;
                    button[j + 1].Background = Brushes.White;                    
                }
                // update loop count
                loopcnt++;
                loopCount.Content = "Loop: " + loopcnt;
            }

            // enable all buttons
            selBtn.IsEnabled = true;
            bblBtn.IsEnabled = true;
        }

        public async Task SelectionSort(int[] lst, Button[] button)
        {
            // loop count
            int loopcnt = 0;
            loopCount.Visibility = Visibility.Visible;
            loopCount.Content = "Loop: " + loopcnt;

            // step count
            int stepcnt = 0;
            stepCount.Visibility = Visibility.Visible;
            stepCount.Content = "Steps: " + stepcnt;

            int n = lst.Length;
            int i, j, small, temp;
            Button smallBtn = new Button();
            Button tempBtn = new Button();

            for (i = 0; i < n; i++)
            {
                small = lst[i];
                smallBtn = button[i];

                for (j = i + 1; j < n; j++)
                {
                    // animation begin
                    SolidColorBrush brush = new SolidColorBrush(Colors.White);
                    button[j].Background = brush;
                    smallBtn.Background = brush;
                    ColorAnimation anima = new ColorAnimation(Colors.White, Colors.Orange, new Duration(TimeSpan.FromSeconds(0.5)));
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, anima);
                    // animation end
                    await Task.Delay(1000);

                    if (small > lst[j])
                    {
                        // animation begin
                        button[j].Background = brush;
                        smallBtn.Background = brush;
                        brush.BeginAnimation(SolidColorBrush.ColorProperty, anima);
                        // animation end
                        await Task.Delay(1000);

                        (smallBtn.Content, tempBtn.Content) = (button[j].Content, button[i].Content);
                        (button[i].Content, button[j].Content) = (smallBtn.Content, tempBtn.Content);

                        small = lst[j];
                        temp = lst[i];
                        lst[i] = small;
                        lst[j] = temp;

                        button[j].Background = Brushes.White;
                        smallBtn.Background = Brushes.White;
                    }

                    button[j].Background = Brushes.White;
                    smallBtn.Background = Brushes.White;
                }
            }
            bblBtn.IsEnabled = true;
            selBtn.IsEnabled = true;
        }

        static void MergeSort(int[] arr, Button[] button)
        {
            int[] tmp = new int[arr.Length];
            MergeSortHelper(arr, 0, arr.Length - 1, tmp, button);
        }

        static async Task MergeSortHelper(int[] arr, int firstIdx, int lastIdx, int[] tmp, Button[] button)
        {
            if (firstIdx < lastIdx)//only divide if you have at least two elements
            {
                //divide and conquer
                int midIdx = (firstIdx + lastIdx) / 2;
                await MergeSortHelper(arr, firstIdx, midIdx, tmp, button);//recursively sort the first half
                await MergeSortHelper(arr, midIdx + 1, lastIdx, tmp, button);//recursively sort the first half
                await Merge(arr, firstIdx, midIdx, lastIdx, tmp, button);
            }

        }

        static async Task Merge(int[] arr, int firstIdx, int midIdx, int lastIdx, int[] tmp, Button[] button)
        {
            int i = firstIdx;
            int j = midIdx + 1;
            int k = firstIdx;

            while (i <= midIdx && j <= lastIdx)
            {
                if (arr[i] <= arr[j])
                {
                    tmp[k] = arr[i];
                    k++;
                    i++;
                }
                else
                {
                    tmp[k] = arr[j];
                    k++;
                    j++;
                }
            }
            //copy leftovers
            while (i <= midIdx)
            {
                tmp[k] = arr[i];
                k++;
                i++;
            }
            while (j <= lastIdx)
            {
                tmp[k] = arr[j];
                k++;
                j++;

            }

            for (k = firstIdx; k <= lastIdx; k++) //push elements from tmp back into arr
            {
                // animation begin
                SolidColorBrush brush = new SolidColorBrush(Colors.White);
                button[k].Background = brush;

                int temp = Array.IndexOf(arr, tmp[k]);
                button[temp].Background = brush;

                int tempK = arr[k];
                button[k].Content = tmp[k];
                arr[temp] = tempK;

                ColorAnimation anima = new ColorAnimation(Colors.White, Colors.Orange, new Duration(TimeSpan.FromSeconds(0.5)));
                brush.BeginAnimation(SolidColorBrush.ColorProperty, anima);
                // animation end
                await Task.Delay(1000);

                arr[k] = tmp[k];
                button[k].Background = Brushes.White;
                button[temp].Background = Brushes.White;
            }



        }
    }
}
