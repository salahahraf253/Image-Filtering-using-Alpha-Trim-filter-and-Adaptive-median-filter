using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageFilters
{
    public class Adaptive_medain_filter
    {

        public static byte applyFilterOfMedain(byte[,] ImageMatrix, int x, int y, int maxWindowSize, int sortType)
        {
            byte newPixel=0;

            for (int windowSize = 3; windowSize <= maxWindowSize; windowSize += 2)      //O(n/2)
            {
                byte[] windowOfPixels = ImageOperations.constructWindowOfPixels(ImageMatrix, x, y, windowSize );
                int windowPixelSize =windowOfPixels.Length;
                byte[] sortedPixels = new byte[windowPixelSize ];
                if (sortType == 1)
                {
                    windowOfPixels = sorting.Quick_Sort(windowOfPixels, 0, windowPixelSize  - 1); //sort the window using quick sort           O(n^2)
                }
                else if (sortType == 2)
                {
                    windowOfPixels = sorting.Counting_Sort(windowOfPixels, windowPixelSize ); //sort the window using counting sort             O(n+k)
                }

                for (int i = 0; i < windowPixelSize ; i++)
                {
                    sortedPixels[i] = windowOfPixels[i];
                }
                byte Zmin = sortedPixels[0]; 
                byte Zmax = sortedPixels[windowPixelSize  - 1];
                byte Zmid = sortedPixels[windowPixelSize  / 2];
                //if (windowPixelSize % 2 == 1)
                //{
                //   Zmid = sortedPixels[windowPixelSize / 2];
                //}
                //else
                //{
                //   Zmid = Convert.ToByte((sortedPixels[windowPixelSize / 2] + sortedPixels[windowPixelSize / 2 - 1]) / 2);
                //}

                byte A1 = (byte)(Zmid - Zmin);
                byte A2 = (byte)(Zmax - Zmid);
                if (A1 > 0 && A2 > 0)
                {
                    byte Zxy = ImageMatrix[y, x];
                    byte B1 = (byte)(Zxy - Zmin);
                    byte B2 = (byte)(Zmax - Zxy);
                    if (B1 > 0 && B2 > 0)
                    {
                        newPixel = Zxy;     //leave the center pixel as it is 
                    }
                    else
                    {
                        newPixel = Zmid;    //replace the center pixel with the medain value
                    }
                    break;
                }
                else
                {
                    if (windowSize + 2 <= maxWindowSize) continue; //call again with windowSize +2 
                    else
                    {
                        newPixel = Zmid;
                        break;
                    }
                }
            }
            return newPixel;
        } 

    }
}
