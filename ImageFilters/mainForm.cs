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
    public partial class mainForm : Form
    {
        public mainForm()
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
            //MessageBox.Show("You press apply", "Information");
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



        private void Form1_Load(object sender, EventArgs e)
        {

        }
      
    }
}
