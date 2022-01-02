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
        byte[,] imageForFiltering;
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                ImageMatrix = ImageOperations.OpenImage(OpenedFilePath);
                imageForFiltering = ImageMatrix;
                ImageOperations.DisplayImage(ImageMatrix, pictureBox1);
            }
        }
        

        //start of code//////////////////////////////////////////////////////////////////////////////////////////////////////////
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

            if (FilterBox.Text.Equals("Alpha-Trim Filter")) filterType = 1;
            else if (FilterBox.Text.Equals("Bonus")) filterType = 3;
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
                ImageOperations.ImageFilter(imageForFiltering, w, 1, 2, 0);   //quick sort 
                timeAfterFiltering =System.Environment.TickCount;
                time_of_quick_sort[index] = Math.Abs(timeAfterFiltering - timeBeforeFiltering);

                index++;
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(imageForFiltering, w, 2, 2, 0);   //counting sort 
                timeAfterFiltering = System.Environment.TickCount;
                time_of_counting_sort[index++] = Math.Abs(timeAfterFiltering - timeBeforeFiltering);
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Median Filter using Counting sort & Quick sort", "Window Size", "Time in ms");
            
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
            double[] time_of_counting_sort = new double[N];              //counting sort 
            double[] window = new double[N];                          //window
            double[] time_of_bubble = new double[N];              // bubble sort
            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                window[index] = w;
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(imageForFiltering, w, 2, 1, T);           // counting sort 
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
                    ImageOperations.ImageFilter(imageForFiltering, w,5, 1, T);           // Bubble sort
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_bubble[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error");
                }
            }
            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha trim using Counting sort & Modified Bubble Sort", "window size", "time in ms");
            ZGF.add_curve("Counting Sort", window, time_of_counting_sort, Color.Red);           //for couting sort
            ZGF.add_curve("Modified Bubble Sort", window, time_of_bubble, Color.Blue);                            //for Heap
            ZGF.Show();
        }
        private void plotGraphBtn(object sender, EventArgs e)
        {
            MessageBox.Show("You press on Alpha Graph button", "Information");

            if (WmaxSize.Text.Length == 0)
            {
                MessageBox.Show("Please enter a Maximum window size for graph", "Error");
            }
            int trimValue= int.Parse(Trim_value.Text);
            int sortType1=2 , sortType2 =1;
            string sortName2 = "", sortName1 = "Counting sort";
            if (comboBox2.Text.Equals("Counting & Bubble sort")) { sortType2 = 5; sortName2 = "Modified Bubble Sort"; }
            else if (comboBox2.Text.Equals("Counting & Select the Kth")) {sortType2 = 3; sortName2 = "Select the Kth"; }
            else if (comboBox2.Text.Equals("Counting & Heap")) { sortType2 = 4; sortName2 = "Heap"; }
            else if(comboBox2.Text.Equals("Bubble Sort & Heap"))
            {
                sortName1 = "Bubble sort";
                sortType1 = 5;
                sortName2 = "Heap";
                sortType2 = 4;
                
            }
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
                ImageOperations.ImageFilter(imageForFiltering, w, sortType1, 1, trimValue);       //counting sort 
                timeAfterFiltering = System.Environment.TickCount;
                timeOfSort1[index] = (timeAfterFiltering - timeBeforeFiltering);

                index++;
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(imageForFiltering, w, sortType2, 1, trimValue);
                timeAfterFiltering = System.Environment.TickCount;
                timeOfSort2[index++] = (timeAfterFiltering - timeBeforeFiltering);
            }

            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Graph of Alpha Trim Filter using "+sortName1+" & " + sortName2, "Window size", "Time in milleSeconds"); ;

            ZGF.add_curve(sortName2, window_size, timeOfSort2, Color.Red);            //for second sort          
            ZGF.add_curve(sortName1, window_size, timeOfSort1, Color.Blue);           //for first sort
            ZGF.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void plotAllGraphsOfAlphaTrimFilter(object sender, EventArgs e)
        {
            int T = int.Parse(Trim_value.Text);

            int Wmax = int.Parse(WmaxSize.Text);
            int N = (Wmax - 3) / 2 + 1;
            double[] time_of_counting_sort = new double[N];     //counting sort 
            double[] window = new double[N];                    //window
            double[] time_of_bubble = new double[N];        
            double[] time_of_Heap = new double[N];
            double[] time_of_select_th_Kth_element = new double[N];        

            double timeBeforeFiltering, timeAfterFiltering;
            int index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                window[index] = w;
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(imageForFiltering, w, 2, 1, T);           // counting sort 
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_counting_sort[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            index = 0;
            for(int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(imageForFiltering, w, 4, 1, T);           //Heap
                timeAfterFiltering = System.Environment.TickCount;
                time_of_Heap[index++] = (timeAfterFiltering - timeBeforeFiltering);
            }

            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                timeBeforeFiltering = System.Environment.TickCount;
                ImageOperations.ImageFilter(imageForFiltering, w, 3, 1, T);           //select 
                timeAfterFiltering = System.Environment.TickCount;
                time_of_select_th_Kth_element[index++] = (timeAfterFiltering - timeBeforeFiltering);
            }
            index = 0;
            for (int w = 3; w <= Wmax; w += 2)
            {
                try
                {
                    timeBeforeFiltering = System.Environment.TickCount;
                    ImageOperations.ImageFilter(imageForFiltering, w, 5, 1, T);           // Bubble sort
                    timeAfterFiltering = System.Environment.TickCount;
                    time_of_bubble[index++] = (timeAfterFiltering - timeBeforeFiltering);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            //Create a graph and add two curves to it
            ZGraphForm ZGF = new ZGraphForm("Sample Graph of Alpha trim using Counting sort & Modified Bubble Sort", "window size", "time in ms");
            ZGF.add_curve("Counting Sort", window, time_of_counting_sort, Color.Red);           //for couting sort
            ZGF.add_curve("Modified Bubble Sort", window, time_of_bubble, Color.Blue);                            //for Heap
            ZGF.add_curve("Heap", window, time_of_Heap, Color.Black);                            
            ZGF.add_curve("Select the Kth", window, time_of_select_th_Kth_element, Color.Green);                            
            ZGF.Show();
        }
    }
}