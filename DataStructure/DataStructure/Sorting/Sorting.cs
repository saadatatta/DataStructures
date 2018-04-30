using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Sorting
{
    int[] unsortedArray;

    public Sorting(int[] unsortedArray)
    {
        this.unsortedArray = unsortedArray;
    }

    public void SelectionSort()
    {
        for(int i = 0; i < unsortedArray.Length; i++)
        {
            int minIndex = i;

            for(int j= i + 1; j < unsortedArray.Length; j++)
            {
                if (unsortedArray[j] < unsortedArray[minIndex])
                {
                    minIndex = j;
                }
            }

            if(minIndex != i)
            {
                int temp = unsortedArray[minIndex];
                unsortedArray[minIndex] = unsortedArray[i];
                unsortedArray[i] = temp;
            }
        }
    }

    public void InsertionSort()
    {
        int smallest = unsortedArray[0];

        for(int i = 1; i < unsortedArray.Length; i++)
        {
            if(unsortedArray[i] < smallest)
            {
                int j = i;

                while (j>0 && unsortedArray[j] < unsortedArray[j-1])
                {
                    int temp = unsortedArray[j-1];
                    unsortedArray[j - 1] = unsortedArray[j];
                    unsortedArray[j] = temp;
                    j = j - 1;
                }
            }
        }
    }

    public void BubbleSort()
    {
        for(int i = 0; i < unsortedArray.Length ; i++)
        {
            for(int j = i+1; j < unsortedArray.Length; j++)
            {
                if (unsortedArray[j] < unsortedArray[i])
                {
                    int temp = unsortedArray[j];
                    unsortedArray[j] = unsortedArray[i];
                    unsortedArray[i] = temp;
                }
            }
        }
    }

    public void QuickSort(int low,int high)
    {
        if(low < high)
        {
            int pivot = Partition(low,high);

            QuickSort(low, pivot - 1);
            QuickSort(pivot + 1, high);
        }
    }

    private int Partition(int low,int high)
    {
        int pivot = unsortedArray[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if(unsortedArray[j] <= pivot)
            {
                i++;
                //Swap the elements
                int tempValue = unsortedArray[j];
                unsortedArray[j] = unsortedArray[i];
                unsortedArray[i] = tempValue;
            }
        }

        //swap the pivot
        //int temp = unsortedArray[high];
        unsortedArray[high] = unsortedArray[i + 1];
        unsortedArray[i + 1] = pivot;

        return i+1;
    }

    public void MergeSort(int left,int right)
    {
        if(left < right)
        {
            int mid = (left + right) / 2;
            MergeSort(left, mid);
            MergeSort(mid + 1, right);
            Merge(left, mid, right);
        }
    }

    private void Merge(int left,int middle,int right)
    {
        //Lengths of two arrays
        int size1 = middle - left + 1;
        int size2 = right - middle;

        //Create two temp array
        int[] leftArray = new int[size1];
        int[] rightArray = new int[size2];

        //Copy data to temp arrays
        for(int a = 0; a < leftArray.Length; a++)
        {
            leftArray[a] = unsortedArray[left + a];
        }
        for(int  b= 0; b < rightArray.Length; b++)
        {
            rightArray[b] = unsortedArray[middle + 1 + b];
        }

        //Merge the temp array
        int i = 0, j = 0;
        int k = left;

        while(i<size1 && j < size2)
        {
            if(leftArray[i] <= rightArray[j])
            {
                unsortedArray[k] = leftArray[i];
                i++;
            }
            else
            {
                unsortedArray[k] = rightArray[j];
                j++;
            }
            k++;
        }

        //Add any element in left array, if present.
        while (i < size1)
        {
            unsortedArray[k] = leftArray[i];
            i++;
            k++;
        }
        //Add any element in right array, if present.
        while (j < size2)
        {
            unsortedArray[k] = rightArray[j];
            j++;
            k++;
        }

    }

    public void HeapSort()
    {
        int arrayLength = unsortedArray.Length;
        
        for(int i = (arrayLength / 2) - 1; i >= 0; i--) // This loop creates max heap.
        {
            Heapify(arrayLength,i); //SortUp
        }

        for(int i = arrayLength - 1; i >= 0; i--)
        {
            int temp = unsortedArray[0];
            unsortedArray[0] = unsortedArray[i];
            unsortedArray[i] = temp;

            Heapify(i, 0); // SortDown; This recursively put values in ascending order.
        }

    }

    private void Heapify(int arrayLength,int index)
    {
        int maxIndex = index;
        int leftItemIndex = 2 * index + 1;
        int rightItemIndex = 2 * index + 2;

        if(leftItemIndex < arrayLength && unsortedArray[leftItemIndex] > unsortedArray[maxIndex])
        {
            maxIndex = leftItemIndex;
        }
        if (rightItemIndex < arrayLength && unsortedArray[rightItemIndex] > unsortedArray[maxIndex])
        {
            maxIndex = rightItemIndex;
        }

        if(maxIndex != index)
        {
            int temp = unsortedArray[index];
            unsortedArray[index] = unsortedArray[maxIndex];
            unsortedArray[maxIndex] = temp;

            Heapify(arrayLength, maxIndex);
        }
    }

    public void CountingSort()
    {
        int elementsCount = unsortedArray.Length;
        int[] countArray = new int[10];
        int[] outputArray = new int[elementsCount];

        //Store the count of elements.
        for (int i = 0; i < elementsCount; i++)
            countArray[unsortedArray[i]]++;

        //To each element add the sum of previous index count.
        for(int i = 1; i < countArray.Length; i++)
        {
            countArray[i] += countArray[i - 1];
        }

        // Assign value to valid index and decrease count in countArray.
        for(int i = 0; i < elementsCount; i++)
        {
            outputArray[countArray[unsortedArray[i]]-1] = unsortedArray[i];
            countArray[unsortedArray[i]]--;
        }

        //Assign values to original array.
        for(int i = 0; i < outputArray.Length; i++)
        {
            unsortedArray[i] = outputArray[i];
        }
    }

    public void RadixSort()
    {
        int maxValue = MaxValue();

        for(int exp=1;maxValue / exp > 0; exp *= 10)
        {
            RadixCountingSort(exp);
        }
    }

    private void RadixCountingSort(int exp)
    {
        int elementsCount = unsortedArray.Length;
        int[] countArray = new int[10];
        int[] outputArray = new int[elementsCount];

        //Store the count of radix values.
        for (int i = 0; i < elementsCount; i++)
            countArray[(unsortedArray[i]/exp)%10]++;

        //To each element add the sum of previous index count.
        for (int i = 1; i < countArray.Length; i++)
        {
            countArray[i] += countArray[i - 1];
        }

        // Assign value to valid index and decrease count in countArray.
        for (int i = elementsCount-1; i >=0; i--)
        {
            outputArray[countArray[(unsortedArray[i]/exp) % 10] - 1] = unsortedArray[i];
            countArray[(unsortedArray[i]/exp)%10]--;
        }

        //Assign values to original array.
        for (int i = 0; i < outputArray.Length; i++)
        {
            unsortedArray[i] = outputArray[i];
        }
    }

    private int MaxValue()
    {
        int maxValue = unsortedArray[0];

        for(int i = 1; i < unsortedArray.Length; i++)
        {
            if(unsortedArray[i] > maxValue)
            {
                maxValue = unsortedArray[i];
            }
        }

        return maxValue;
    }

    public void ShellSort()
    {
        int n = unsortedArray.Length;

        for(int gap = n / 2; gap > 0; gap /= 2)
        {
            for(int i = gap; i < n; i++)
            {
                int temp = unsortedArray[i];

                int j;
                for(j=i;j>=gap && unsortedArray[j - gap] > temp;j-=gap)
                {
                    unsortedArray[j] = unsortedArray[j - gap];
                }

                unsortedArray[j] = temp;
            }
        }
    }

    public void Print()
    {
        Console.WriteLine("------------------------------------\n");

        foreach (int element in unsortedArray)
        {
            Console.Write(element + "\t");
        }
    }
}
