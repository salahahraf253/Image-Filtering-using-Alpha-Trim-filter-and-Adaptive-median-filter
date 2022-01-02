using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Security.Policy;
using System.Xml.Schema;

namespace ImageFilters
{
    public class Alpha_Trim_Filter
    {
        public static byte appplyFilterofAlphaTrim(byte[,] ImageMatrix, int x, int y, int windowSize, int sortType, int trimValue)     //O(n^2)
        {
            byte[] windowPixels = ImageOperations.constructWindowOfPixels(ImageMatrix, x, y, windowSize);   //O(n)
            int windowPixelSize = windowPixels.Length;
            int  sumOfPixels=0;
            byte avgargeOfPixels=0;

            if(windowPixelSize > (trimValue * 2))       //check the window size >= trim value * 2
            {
                byte[] sortedPixels = new byte[windowPixelSize];
                if (sortType == 1)      //Quick sort
                {
                    windowPixels=sorting.Quick_Sort(windowPixels,0,windowPixels.Length-1);
                    sumOfPixels = sorting.calcSumOfPixels(windowPixels, trimValue, windowPixels.Length-trimValue);
                }
                if (sortType == 2) //counting sort
                {
                    windowPixels = sorting.Counting_Sort(windowPixels, windowPixelSize);        //O(n)    
                    sumOfPixels = sorting.calcSumOfPixels(windowPixels, trimValue, windowPixels.Length - trimValue);

                }
                else if (sortType == 3) //Select the Kth element
                {
                    sumOfPixels=sorting.excludeTrimPixelsUsingRandomizedSelection(windowPixels, trimValue);         //O(n^2) 
                }
                else if (sortType == 4) // using Max & Min Heap
                {
                    sumOfPixels = sorting.HEAP(windowPixels, trimValue);
                }
                else if (sortType == 5) //using Modified Bubble Sort 
                {
                    sumOfPixels=sorting.modifiedBubbleSort(windowPixels, trimValue);
                }
                try
                {
                    avgargeOfPixels = Convert.ToByte(sumOfPixels / (windowPixelSize - (2 * trimValue)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (windowPixelSize == (trimValue * 2))
            {
                avgargeOfPixels = 0;
            }
            else
            {
                //Avg = Sum / ArrayLength;
                avgargeOfPixels = ImageMatrix[y,x];
            }
            return avgargeOfPixels;
        }
    }
}

