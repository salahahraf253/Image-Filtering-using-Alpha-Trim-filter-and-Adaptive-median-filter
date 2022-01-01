using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZGraphTools;


namespace ImageFilters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static  byte[,] ImageMatrix;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
                // Console.WriteLine("Iamge is uploaded!");
            }
        }
        
        private void applyFilterButton(object sender, EventArgs e) //apply button 
        {
            MessageBox.Show("You press apply", "Information");
            if (window_size.Text.Length == 0)
            {
                MessageBox.Show("Please Enter The Max window size ","Error");
            }
            int w = int.Parse(window_size.Text);
            int filterType=2; 
            //1 for alpha trim 
            //2 for adaptive median 
            //3 for bonus
            int sortType;
            // 1 for quick sort
            //2 for counting sort
            //3 for select the Kth
            //4 Min & Max Heap
            //5 Modified Bubble Sort

            if ( FilterBox.Text.Equals("Alpha-Trim Filter")) filterType = 1;
            else filterType = 2;
            if (SortAlgoCombo.Text.Length==0)
            {
                MessageBox.Show("Please Select a sorting algorithm!", "Error");
            }
            if (SortAlgoCombo.Text.Equals("Quick_Sort")) sortType = 1;
            else if (SortAlgoCombo.Text.Equals("counting_Sort")) sortType = 2;
            else if (SortAlgoCombo.Text.Equals("Min & Max Heap")) sortType = 4;
            else sortType = 3;
            if (Trim_value.Text.Length == 0 && filterType==1)
            {
                MessageBox.Show("Please Enter the Trim Value","Error");
            }

            if (filterType == 2 && sortType == 3)
            {
                MessageBox.Show("Wrong choose the selecting Kth sorting doesn't work with Adaptive medain filter","Error");
            }
            try
            {
                int K = int.Parse(Trim_value.Text); //for trim value 
                if (FilterBox.Text.Equals("Adaptive median filter "))
                {
                    K = 0;
                }

                if (w*w - 2* int.Parse(Trim_value.Text)<=0 )//validate the Trim value is valid
                {
                    MessageBox.Show("Please Trim value in range from 1 : " + ( (w*w)/2-1),"Error");
                    
                }
                byte[,] imageAfterFiltering = ImageOperations.ImageFilter(ImageMatrix, w, sortType, filterType , K); //new image 
                //display image after processing 
                // Console.WriteLine("Before");
                // Console.WriteLine("After");
                ImageOperations.DisplayImage(imageAfterFiltering, pictureBox2);
                
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"In Apply Filter");
                throw;
            }
        }


        private void displayMedainGraph(object sender, EventArgs e)        //display median graph
        {
            MessageBox.Show("You press on Median Graph button", "Information");

            if (WmaxSize.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Maximum window size for graph", "Error");
            }

            int Wmax = int.Parse(WmaxSize.Text);
            int N = (Wmax - 3) / 2 + 1;
            double[] time_of_quick_sort = new double[N];
            double[] window_size = new double[N];
            double[] time_of_counting_sort = new double[N];
            //time_of_quick_sort[0] = 0; window_size[0] = 0; time_of_counting_sort[0] = 0;

            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;

            for (int w = 3; w <= Wmax; w += 2)
            {
                window_size[index] = w;
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(ImageMatrix, w, 1, 2, 0);//quick sort 
                timeAfterFiltering =System.Environment.TickCount;
                time_of_quick_sort[index] = (timeAfterFiltering - timeBeforeFiltering);

                index++;
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(ImageMatrix, w, 2, 2, 0);//counting sort 
                timeAfterFiltering = System.Environment.TickCount;
                time_of_counting_sort[index++] = (timeAfterFiltering - timeBeforeFiltering);
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Median Filter using Counting sort & Quick sort", "N", "f(N)");
            
            ZGF.add_curve("Quick sort ", window_size, time_of_quick_sort,Color.Red);            //for quick sort          
            ZGF.add_curve("Counting sort ", window_size, time_of_counting_sort, Color.Blue);    //for counting sort
            ZGF.Show();
        }


        private void displayAlpaTrimGraph(object sender, EventArgs e)     //alpha trim graph 
        {
            MessageBox.Show("You press on Alpha Trim Graph button", "Information");
            if (WmaxSize.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Maximum window size for graph", "Error");
            }
            if (Trim_value.Text.Length == 0)
            {
                MessageBox.Show("Please Enter the Trim Value", "Error");
            }
            int T = int.Parse(Trim_value.Text);

            int Wmax = int.Parse(WmaxSize.Text);
            int N = (Wmax - 3) / 2 + 1;
            double[] time_of_counting_sort = new double[N];     //counting sort 
            double[] window = new double[N];                    //window
            double[] time_of_select_Kth = new double[N];        //select the Kth element 
            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                window[index] = w;
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(ImageMatrix, w, 2, 1, T);// counting sort 
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_counting_sort[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(ImageMatrix, w, 3, 1, T);// select the Kth 
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_select_Kth[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
            }
            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha trim using Counting sort & Select the Kth element", "window size", "time in ms");
            ZGF.add_curve("Counting Sort", window, time_of_counting_sort, Color.Red);           //for quick sort 
            ZGF.add_curve("Select the Kth element", window, time_of_select_Kth, Color.Blue);    //for counting sort
            ZGF.Show();
        }


        private void applyHeapVsSelectGraph(object sender, EventArgs e) // Heap vs Select the Kth 
        {
            int T = int.Parse(Trim_value.Text);

            int Wmax = int.Parse(WmaxSize.Text);
            int N = (Wmax - 3) / 2 + 1;
            double[] time_of_heap = new double[N];     //counting sort 
            double[] window = new double[N];                    //window
            double[] time_of_select_Kth = new double[N];        //select the Kth element 
            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                window[index] = w;
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(ImageMatrix, w, 4, 1, T);       // Heap
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_heap[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(ImageMatrix, w, 2, 1, T);       // select the Kth 
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_select_Kth[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            //Create a graph and add two curves to it
            //ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha trim using Heap & Select the Kth element", "N", "f(N)");
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha trim using Heap & Counting", "N", "f(N)");
            ZGF.add_curve("Min & Max Heap", window, time_of_heap, Color.Red);           //for quick sort 
            //ZGF.add_curve("Select the Kth element", window, time_of_select_Kth, Color.Blue);    //for counting sort
            ZGF.add_curve("Counting", window, time_of_select_Kth, Color.Blue);    //for counting sort
            ZGF.Show();
        }

        private void plotGraphBtn(object sender, EventArgs e)
        {
            MessageBox.Show("You press on Median Graph button", "Information");

            if (WmaxSize.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Maximum window size for graph", "Error");
            }
            int trimValue= int.Parse(Trim_value.Text);
            int sortType1=2 , sortType2 =1;
            string sortName = "";
            if (comboBox2.Text.Equals("Counting & Bubble sort")) { sortType2 = 5; sortName = "Modified Bubble Sort"; }
            else if (comboBox2.Text.Equals("Counting & Select the Kth")) {sortType2 = 3; sortName = "Select the Kth"; }
            else if (comboBox2.Text.Equals("Counting & Heap")) { sortType2 = 4; sortName = "Heap"; }

            int Wmax = int.Parse(WmaxSize.Text);
            int N = (Wmax - 3) / 2 + 1;
            double[] timeOfSort1 = new double[N];
            double[] window_size = new double[N];
            double[] timeOfSort2 = new double[N];
            //time_of_quick_sort[0] = 0; window_size[0] = 0; time_of_counting_sort[0] = 0;

            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;

            for (int w = 3; w <= Wmax; w += 2)
            {
                window_size[index] = w;
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(ImageMatrix, w, sortType1, 1, trimValue);       //counting sort 
                timeAfterFiltering = System.Environment.TickCount;
                timeOfSort1[index] = (timeAfterFiltering - timeBeforeFiltering);

                index++;
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(ImageMatrix, w, sortType2, 1, trimValue);
                timeAfterFiltering = System.Environment.TickCount;
                timeOfSort2[index++] = (timeAfterFiltering - timeBeforeFiltering);
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha Trim Filter using Counting sort & " + sortName, "N", "f(N)"); ;

            ZGF.add_curve(sortName, window_size, timeOfSort2, Color.Red);            //for second sort          
            ZGF.add_curve("Counting sort ", window_size, timeOfSort1, Color.Blue);    //for counting sort
            ZGF.Show();
        }
    }
}