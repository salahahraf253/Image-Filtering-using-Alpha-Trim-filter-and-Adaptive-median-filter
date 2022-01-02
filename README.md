# Image Filter using Alpha trim & Adaptive median filter

## Order Statistics Filters
**In image processing, filter is usually necessary to perform a high degree of noise reduction in an image before performing higher-level processing steps. The order statistics** **filter is a non-linear digital filter technique, often used to remove speckle  (salt and pepper) noise from images. We target two common filters in this project:**
<p>The main idea of both filters is to sort the pixel values in a neighborhood region with certain window size and then chose/calculate the single value from them and places it in the center of the window in a new image, see figure 1. This process is repeated for all pixels in the original image.</p>
<img src="https://github.com/salahahraf253/Image-Filtering-using-Alpha-Trim-filter-and-Adaptive-median-filter/blob/main/Samples/Examples%20for%20Output%20Images/adaptive_medain_filter_windowSize%207.png" alt="Italian Trulli">
---
**1.	Alpha-trim filter**
---
**2.	Adaptive median filter**
---

## **First:** <mark>Alpha-trim filter</mark>.
<p>The idea is to calculate the average of some neighboring pixels' values after trimming out (excluding) the smallest T pixels and largest T pixels. This can be done by repeating the following steps for each pixel in the image:
1.	Store the values of the neighboring pixels in an array. The array is called the window, and it should be odd sized.
2.	Sort the values in the window in ascending order.
3.	Exclude the first T values (smallest) and the last T values (largest) from the array.
4.	Calculate the average of the remaining values as the new pixel value and place it in the center of the window in the new image, see figure 1.
This filter is usually used to remove both salt & pepper noise and random noise. See figure 2</p>
