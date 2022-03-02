using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ImageFilters
{
    internal abstract class sorting
    {

        //Quick Sort 
        private static int partition(byte[] arr, int low, int high)
        {
            byte pivot = arr[high];   //pivot
            byte temp;
            //int i = low;
            int i = low - 1;
            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
            temp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp;
            return i + 1;
        }
        public static byte[] Quick_Sort(byte[] arr, int low, int high)
        {
            //Best Case : O( nlog(n) ) 
            //Worst Case : O(n^2)
            if (low < high)
            {
                int pi = partition(arr, low, high);    //get index of pivot at right place           
                Quick_Sort(arr, low, pi - 1);          //sort elements before index of pivot
                Quick_Sort(arr, pi + 1, high);         //sort elements after index of pivot
            }
            return arr;
        }

        //counting sort
        public static byte[] Counting_Sort(byte[] windowOfPixels, int ArrayLength )
        {
            //time complexity : O(n + k)
            //where n is the length of the array & k is the range of numbers

            byte[] count = new byte[260];
            int z = 0;

            for (int i = 0; i < ArrayLength; i++)
            {
                count[windowOfPixels[i]]++;
            }

            for (int i = 0; i <= 255; i++)
            {
                while (count[i]-- > 0)
                {
                    windowOfPixels[z] = (byte)i;
                    z++;
                }
            }
            return windowOfPixels;
        }

        //selecting the Kth elements
        private static int randomizedPartition(byte[] arr, int low, int high)
        {
            Random rnd = new Random();
            int i = rnd.Next(low, high + 1);    //generate random number of range >=low && <=high
            //swap arr[r] & arr[i];
            byte temp = arr[high];
            arr[high] = arr[i];
            arr[i] = temp;
            return partition(arr, low, high);
        }

        private static byte randomizedSelect(byte[] arr, int low, int high, int theKthElement)
        {
            if (low == high) return arr[low];
            int q = randomizedPartition(arr, low, high);
            int k = q - low + 1;
            if (theKthElement == k)//pivot value is the answer
            {
                return arr[q];
            }
            else if (theKthElement < k)
            {
                return randomizedSelect(arr, low, q - 1, theKthElement);
            }
            else
            {
                return randomizedSelect(arr, q + 1, high, theKthElement - k);
            }
        }       //O(n^2)

        public static int calcSumOfPixels(byte[] windowOfPixels ,int start,int end)       //O(n)
        {
            int sumOfPixels = 0;
            int windosPixelSize = windowOfPixels.Length;
            for (int i = start; i < end; i++)
            {
                sumOfPixels += windowOfPixels[i];
                //Console.Write(windowOfPixels[i]+" ");
            }
            //Console.WriteLine("Sum : "+sumOfPixels);
            return sumOfPixels;
        }       
        public static int excludeTrimPixelsUsingRandomizedSelection(byte[] windowOfPixels, int trimValue)       //O(n^2)
        {
            //Note :  select K is 1-based

            int lastPixel = windowOfPixels.Length;
            int sumOfPixels = calcSumOfPixels(windowOfPixels,0,windowOfPixels.Length);  //O(n)

            for (int firstPixel = 1; firstPixel <= trimValue; firstPixel++, lastPixel--)        
            {
                sumOfPixels -= randomizedSelect(windowOfPixels, 0, windowOfPixels.Length - 1, firstPixel);
                sumOfPixels -= randomizedSelect(windowOfPixels, 0, windowOfPixels.Length - 1, lastPixel);
            }
            return sumOfPixels;
        }
        public static int modifiedBubbleSort(byte[] windowOfPixels, int trimValue)       
        {

            int sumOfPixels = calcSumOfPixels(windowOfPixels,0,windowOfPixels.Length);  //O(n)
            sumOfPixels-= selectTheKthLargestUsingBubbleSort(windowOfPixels, trimValue);
            sumOfPixels-= selectTheKthSmallestUsingBubbleSort(windowOfPixels, trimValue);
            return sumOfPixels;
        }
        public static int selectTheKthLargestUsingBubbleSort(byte[] windowOfPixels, int trimvalue)
        {
            //Modified Bubble Sort 
            int sum = 0;
            byte temp,mn;
            for (int i = 0; i < trimvalue; i++)
            {
                mn=windowOfPixels[i];
                for (int j = 0; j < windowOfPixels.Length - i - 1; j++)
                {
                    if (windowOfPixels[j + 1] < windowOfPixels[j])
                    {
                        temp = windowOfPixels[j];
                        windowOfPixels[j] = windowOfPixels[j + 1];
                        windowOfPixels[j + 1] = temp;
                    }
                    //if(windowOfPixels[j] < mn)mn= windowOfPixels[j];
                }
                sum += (windowOfPixels[windowOfPixels.Length - i - 1]);
            }
            return sum;
        }

        public static int selectTheKthSmallestUsingBubbleSort(byte[] windowOfPixels, int trimvalue)
        {
            //Modified Bubble Sort 
            int sum = 0;
            byte temp;
            for (int i = 0; i < trimvalue; i++)
            {
                for (int j = 0; j < windowOfPixels.Length - i - 1; j++)
                {
                    if (windowOfPixels[j + 1] > windowOfPixels[j])
                    {
                        temp = windowOfPixels[j];
                        windowOfPixels[j] = windowOfPixels[j + 1];
                        windowOfPixels[j + 1] = temp;
                    }
                }
                sum += windowOfPixels[windowOfPixels.Length - i - 1];
            }
            return sum;
        }

        public static int HEAP(byte[]windowOfPixels,int trimValue)      //Heap
        {
            int sumOfPixels = 0;
            MinHeap minHeap=new MinHeap(windowOfPixels.Length);
            MaxHeap maxHeap = new MaxHeap(windowOfPixels.Length);
            for(int i = 0; i < windowOfPixels.Length; i++)
            {
                sumOfPixels+=windowOfPixels[i];
                minHeap.Add(windowOfPixels[i]);
                maxHeap.Add(windowOfPixels[i]);
            }
            for(int i=0;i < trimValue; i++)
            {
                sumOfPixels -= minHeap.Pop();
                sumOfPixels -= maxHeap.Pop();
            }
            return sumOfPixels;
        }

    }
}
 