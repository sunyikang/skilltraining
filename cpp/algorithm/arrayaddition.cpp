#include <iostream>
#include <set>
#include <stdio.h>
#include <map>
#include <cstring>
#include <cctype>
#include <unordered_set>
using namespace std;

static void AddToHashSet(unordered_set<int>* hashset, int value)
{
    unordered_set<int>::iterator it;
    for(it = hashset->begin(); it != hashset->end(); it++)
    {
        int newvalue = *it + value;
        if(hashset->find(newvalue) == hashset->end())
        {
            hashset->insert(newvalue);
        }
    }
}

static string ArrayAddition(int arr[], int length)
{
    std::set<int> set;

    // 1. sort
    for(int i = 0; i < length; i++)
    {
        set.insert(arr[i]);
    }
    int lastnum = *set.rbegin();
    set.erase(*set.rbegin());

    // 2. hashset
    unordered_set<int> hashset;
    hashset.insert(0);

    // 3. add to hashset
    std::set<int>::iterator it;
    for(it = set.begin(); it != set.end(); it++)
    {
        int value = *it;
        AddToHashSet(&hashset, value);

        if(hashset.find(lastnum) != hashset.end())
        {
            return "true";
        }
    }

    return "false";
}

#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    int arr[] = {1,2,3, 100};
    cout << ArrayAddition(arr, sizeof(arr)/sizeof(*arr));
    cout << "\n";
    return 0;
}
#endif

