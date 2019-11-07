using System;

namespace Algorithms
{
    class MainClass
    {
        static void bubbleSort(int[] arr)
        {
            /*
             *  + Scan the list, exchange adjacent elements if they are not in relative order; this bubble
             *      the highest value to the top
             *      
             *  + Scan the list again, bubbling up the second highest value
             *  
             *  + Repeat until all elements have not been placed in their proper order
             */

            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < (n - i - 1); j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        //swap values
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }


        static void selectionSort(int[] arr)
        {
            /*
             *  + Assume the first element in the array be the smallest 
             *      (or largest based on sort direction) value in the array
             *  
             *  + Loop through the rest of the elements and if there is an
             *      element that is smaller than the smallest value assign that
             *      element as the smallest value.
             *      
             *  + At the end of the loop exchange the positions of the smallest
             *      value with the first element
             *      
             *  + Now we have the smallest element right at the top
             *  
             *  + Repeat the same process continuing from the second element until
             *      you reach the last element
             */

            int n = arr.Length;

            //One by one move boundary of unsorted subarray
            for(int i = 0; i < n-1; i++)
            {
                // Find the minimum element in unsorted array
                int min_index = i;
                for(int j = i+1; j < n; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        min_index = j; 
                    }

                    // Swap the found min element with the first element
                    int temp = arr[min_index];
                    arr[min_index] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        static void insertionSort(int[] arr)
        {
            /*
             *  This sorting method must be used when we want to insert an 
             *      element into a sorted array.
             *  
             *  + Coniser a sub-array of length 1 containing the first element. Since there
             *      is only one element it is already sorted.
             *  
             *  + Next insert the second item into the sorted array created above, shifting
             *      the first element if needed.
             *  
             *  + Similarly insert the third item into the sorted array, shifting the 
             *      other elements if necessary.
             *     
             *  + Continue this process until all values have been inserted in the place
             */

            int n = arr.Length;
            for(int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                //Move elements of arr[0....i-1]
                //  that are greater than key, to one
                //  position ahead of their current position
                while(j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j -= 1;
                }
                arr[j + 1] = key;
            }
        }


        // Divide and Conquer Paradigm:
        //  1) Divide the problem into sub-problems
        //  2) Solve each sub-problem seperately
        //  3) Combine the solutions of the original problem


        /* This function takes last element as pivot, places the pivot element at its correct
            position in sorted array, and places all smaller (smaller than pivot) to left of pivot 
            and all greater elemets to right of pivot/. */
        static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            //index of smaller element
            int i = (low - 1);
            for(int j = low; j < high; j++)
            {
                // If current element is smaller than the pivot
                if(arr[j] < pivot)
                {
                    i++;

                    //swap
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            //Swap arr[i+1] and arr[high] (or pivot)
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        static void quickSort(int[] arr, int low, int high)
        {
            /*
             * Divid and Conquer
             * 
             * Simple View:
             *  + From the array select an element and let us call it the pivot.
             *  + Arrange elements such that all elements less than the pivot are to its
             *      left forming sub-array 1 and all greater are to its right forming sub-array 2.
             *  + Continue the same process for the sub-array 1 and sub-array 2.
             *  
             *  Choosing a Pivot:
             *  + first element:
             *      - BAD if input is sorted or in reverse sorted order
             *      - BAD if input is nearly sorted
             *      - Variation: particular element (e.g. middle element)
             *   + random element:
             *      - even a malicious agent cannot arrange a bad input
             *   + median of three elements
             *      - choosing the median of the left, right, and center elements
             *      
             *  Method:
             *  1) Let a be an array of size n which needs to be sorted
             *  2) min = 0, max = n-1
             *  3) if min >= max stop
             *  4) select a first element as pivot element
             *  5) Move the pivot to the rightmost position
             *  6) Starting from the left, find an element >= pivot. Call the position i.
             *  7) Starting from the right, find an element <= pivot. Call the position j.
             *  8) Swap arr[i] and arr[j]
             *  9) Continue 6 to 8 as long as i >= j
             *  10) When i >= j, restore the pivot => swap arr[i] and a[max]
             *  11) Split the list into two: (min, i-1) and (i+1, max) and sort them seperately - apply steps 3 to 11
             */

            if(low < high)
            {
                // pivot is partitioning index, arr[pi] is now at right place
                int pivot = partition(arr, low, high);

                // Recursively sort elements before partition and after partition
                quickSort(arr, low, pivot - 1);
                quickSort(arr, pivot + 1, high);
            }

        }

        void merge(int[] arr, int left, int right, int middle)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int i = 0;
            int j = 0;

            //temp store arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            for(i = 0; i < n1; i++)
                L[i] = arr[left + 1];


            for (j = 0; j < n2; j++)
                R[j] = arr[middle + 1 + j];

            i = 0;
            j = 0;
            int k = left;

            while((i < n1) && (j < n2))
            {
                if(L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            //Copy remaining elements in L to array if exists
            while(i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            //Copy remaining elements in R to array if exists
            while(j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }



        void mergeSort(int[] arr, int left, int right)
        {
            // Another Divide and Conquer

            /*
             * Mothod:
             *  + Splitting Phase:
             *      - Split the array into two equal(or nearly equal) parts.
             *      - Conitnue splitting until each part contains only one element
             *  + Merging Phase:
             *      - Merge the two parts containing one element into one sorted list.
             *      - Continue merging parts until finally there is only one list.
             */

            if( left < right)
            {
                int middle = (left + (right - 1)) / 2;

                //Sort first and second halves
                mergeSort(arr, left, middle);
                mergeSort(arr, middle + 1, right);

                merge(arr, left, right, middle);
            }
        }



        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
            Console.Write("Unsorted Array: ");
            printArray(arr);
            Console.WriteLine();

            int n = arr.Length;

            bubbleSort(arr);
            //selectionSort(arr);

            //insertionSort(arr);

            //quickSort(arr, 0, n);

            Console.Write("Sorted Array: ");
            printArray(arr);
        }
    }
}
