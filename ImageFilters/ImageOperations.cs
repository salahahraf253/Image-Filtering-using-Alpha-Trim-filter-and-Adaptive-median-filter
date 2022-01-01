using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ImageFilters
{
    public class ImageOperations
    {

        public static byte[,] OpenImage(string ImagePath)
        {
            Bitmap original_bm = new Bitmap(ImagePath);
            int Height = original_bm.Height;
            int Width = original_bm.Width;

            byte[,] Buffer = new byte[Height, Width];

            unsafe
            {
                BitmapData bmd = original_bm.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, original_bm.PixelFormat);
                int x, y;
                int nWidth = 0;
                bool Format32 = false;
                bool Format24 = false;
                bool Format8 = false;

                if (original_bm.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    Format24 = true;
                    nWidth = Width * 3;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format32bppArgb || original_bm.PixelFormat == PixelFormat.Format32bppRgb || original_bm.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    Format32 = true;
                    nWidth = Width * 4;
                }
                else if (original_bm.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Format8 = true;
                    nWidth = Width;
                }
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (y = 0; y < Height; y++)
                {
                    for (x = 0; x < Width; x++)
                    {
                        if (Format8)
                        {
                            Buffer[y, x] = p[0];
                            p++;
                        }
                        else
                        {
                            Buffer[y, x] = (byte)((int)(p[0] + p[1] + p[2]) / 3);
                            if (Format24) p += 3;
                            else if (Format32) p += 4;
                        }
                    }
                    p += nOffset;
                }
                original_bm.UnlockBits(bmd);
            }

            return Buffer;
        }

        public static int GetHeight(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(0);
        }
        public static int GetWidth(byte[,] ImageMatrix)
        {
            return ImageMatrix.GetLength(1);
        }
        public static void DisplayImage(byte[,] ImageMatrix, PictureBox PicBox)
        {
            // Create Image:
            //==============
            int Height = ImageMatrix.GetLength(0);
            int Width = ImageMatrix.GetLength(1);

            Bitmap ImageBMP = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            unsafe
            {
                BitmapData bmd = ImageBMP.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, ImageBMP.PixelFormat);
                int nWidth = 0;
                nWidth = Width * 3;
                int nOffset = bmd.Stride - nWidth;
                byte* p = (byte*)bmd.Scan0;
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        p[0] = p[1] = p[2] = ImageMatrix[i, j];
                        p += 3;
                    }

                    p += nOffset;
                }
                ImageBMP.UnlockBits(bmd);
            }
            PicBox.Image = ImageBMP;
        }

        private static int Height;
        private static int Width;


        public static byte[,] ImageFilter(byte[,] ImageMatrix, int Max_Size, int sortType,int filterType ,int K){
            try
            {
                Height = GetHeight(ImageMatrix);
                Width = GetWidth(ImageMatrix);
                byte[,] new_image = ImageMatrix;

                
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        if (filterType == 1) //user choose alpha trim filter
                        {
                            new_image[y, x] = Alpha_Trim_Filter.appplyFilterofAlphaTrim(ImageMatrix, x, y, Max_Size, sortType, K);
                        }
                        else if(filterType==2)
                        {
                            //user chooses adaptive medain filter
                            new_image[y, x] = Adaptive_medain_filter.applyFilterOfMedain(ImageMatrix, x, y, Max_Size, sortType);
                        }
                    }
                }


                return new_image;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }


        public static bool isValidIndex(int yPos, int xPos)     //O(1)
        {
            return (xPos >= 0 && yPos >= 0 && xPos < Width && yPos < Height);
        }


        public static byte [] constructWindowOfPixels(byte[,] ImageMatrix,int x, int y, int windowSize) //O(n^2)
        {
            int[] arrX = new int[windowSize * windowSize];
            int[] arrY = new int[windowSize * windowSize];
            int Index = 0;

            for (int y_intercept = -(windowSize / 2); y_intercept <= (windowSize / 2); y_intercept++)
            {
                for (int x_intercept = -(windowSize / 2); x_intercept <= (windowSize / 2); x_intercept++)
                {
                    arrX[Index] = x_intercept;
                    arrY[Index++] = y_intercept;
                }
            }
            int windowPixelSize=0;
            byte[] windowPixels = constructWindow(ImageMatrix, arrX, arrY, windowSize, y, x, ref windowPixelSize);

            return constructWindowOfNeighbourPixels(windowPixels, windowPixelSize);
        }
        private static byte[] constructWindow(byte[,] ImageMatrix, int[] arrX,int[] arrY,int windowSize,int y,int x,ref int windowPixelSize )   //O(n)
        {
            byte[] windowPixels = new byte[windowSize * windowSize];
            int yPos, xPos;
            windowSize = windowSize * windowSize;
            for (int i = 0; i < windowSize; i++)
            {
                yPos = y + arrY[i];
                xPos = x +  arrX[i];
                if (isValidIndex(yPos, xPos))
                {
                    windowPixels[windowPixelSize++] = ImageMatrix[yPos, xPos];
                }
            }
            return windowPixels; //return window (invalid neighbour is zero)
        }
        private static byte [] constructWindowOfNeighbourPixels(byte[] windowOfPixels , int pixelsSize)     //O(n)
        {
            byte[] validWindowPixels = new byte[pixelsSize];
            for(int i=0;i< pixelsSize; i++)
            {
                validWindowPixels[i] = (byte)(windowOfPixels[i]);
            } 
            return validWindowPixels; //return valid neighbour only 
        }
    }
}
