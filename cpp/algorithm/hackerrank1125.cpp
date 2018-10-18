#include <map>
#include <set>
#include <list>
#include <cmath>
#include <ctime>
#include <deque>
#include <queue>
#include <stack>
#include <bitset>
#include <cstdio>
#include <vector>
#include <cstdlib>
#include <numeric>
#include <sstream>
#include <iostream>
#include <algorithm>
using namespace std;

void printSort(const vector<int>& ar)
{
    for(int i = 0 ; i < (int)ar.size(); i ++)
        cout << ar[i] << " ";
    cout << "\n";
}

void insertionSort2(vector<int> ar) {

    if(ar.size() <= 1) return;

    int left = 0;

    for(int i = 1; i < (int) ar.size(); i++)
    {
        left = i - 1;

        if(ar[left] > ar[i])
        {
            int tempvalue = ar[i];
            int j = i;

            while(j != 0 && ar[j - 1] > tempvalue)
            {
                ar[j] = ar[j-1];
                j--;
            }

            ar[j] = tempvalue;

            i++;
        }
        printSort(ar);
    }
}

void insertionSort(vector<int> ar) {

    if(ar.size() <= 1) return;

    int left = 0;

    for(int i = (int)ar.size() - 1; i >= 1; i--)
    {
        left = i - 1;

        if(ar[left] > ar[i])
        {
            int tempvalue = ar[i];
            int j = i;

            while(j != 0 && ar[j - 1] > tempvalue)
            {
                ar[j] = ar[j-1];                
                j--;
                printSort(ar);
            }

            ar[j] = tempvalue;
            printSort(ar);

            i++;
        }
    }
}

void mergeTwoArray(int* left, int leftsize, int* right, int rightsize)
{
    int m = 0;
    int n = 0;

    while(m < leftsize && n < rightsize)
    {
        if(left[m] <= right[n])
        {
            m ++;
        }
        else
        {
            int tmp = left[m];
            left[m] = right[n];
            right[n] = tmp;
            n++;
        }
    }
}

int* mergeSort(int* arr, int size)
{
    if(size <= 1) return arr;

    int slow = 0;
    for(int i = 1; i < size; i+= 2)
    {
        slow ++;
    }

    mergeSort(arr, slow);
    mergeSort(&arr[slow], size - slow);

    mergeTwoArray(arr, slow, &arr[slow], size - slow);
    return arr;
}

void quickSort(vector <int>&  ar) {

    if(ar.size() <= 1)
        return;

    vector<int> left;
    vector<int> equal;
    vector<int> right;

    equal.push_back(ar[0]);
    for(int i = 1; i < (int)ar.size(); i++)
    {
        if(ar[i] < ar[0])
        {
            left.push_back(ar[i]);
        }
        else if(ar[i] > ar[0])
        {
            right.push_back(ar[i]);
        }
        else
        {
            equal.push_back(ar[i]);
        }
    }

    quickSort(left);
    quickSort(right);

    ar.clear();
    ar.insert(ar.end(), left.begin(), left.end());
    ar.insert(ar.end(), equal.begin(), equal.end());
    ar.insert(ar.end(), right.begin(), right.end());

    printSort(ar);
}

/*
 * space optimised 
 */
void swap(vector<int>& arr, int left, int right)
{
    if(left == right) return;
}

//void quickSort2(vector<int>& arr, int start, int end = )
//{
//    int bigstart = -1;
//    int pivot = (int)arr.size() - 1;
    
//    for(int i = 0; i < pivot; i ++)
//    {
//        if(arr[i] < arr[pivot])
//        {
//            bigstart++;
//            swap(arr, bigstart, i);
//        }
//        else if(arr[i] > pivot)
//        {
//            // do nothing
//        }
//        else
//        {
//            // let's consider there is no duplicate value in arr
//        }
//    }
    
//    quickSort2();
//}

//#define VALID_MAIN
#ifdef VALID_MAIN
int main(void) {

    {
        vector<int> arr = {5, 8, 1, 3, 7, 9, 2};
        quickSort(arr);
    }

//    {
//        int ar[] = {4,3,2,1};
//        mergeSort(ar, 4);

//        for(int i = 0 ; i < 4; i ++)
//            cout << ar[i] << " ";
//        cout << "\n";
//    }

//    {
//        int ar[] = {4,7,1};
//        mergeSort(ar, 3);

//        for(int i = 0 ; i < 3; i ++)
//            cout << ar[i] << " ";
//        cout << "\n";
//    }

//    {
//        vector<int> arr = {1, 4, 3, 5, 6, 2};
//        insertionSort2(arr);
//    }

//    {
//        vector<int> arr = {2, 4, 6, 8, 3};
//        insertionSort(arr);
//    }

//    {
//        vector<int> arr = {};
//        insertionSort(arr);
//    }

//    {
//        vector<int> arr = {2};
//        insertionSort(arr);
//    }

//    {
//        vector<int> arr = {4,3,2,1};
//        insertionSort(arr);
//    }

    return 0;
}
#endif
