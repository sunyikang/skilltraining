#include <iostream>
#include <set>
#include <stdio.h>
#include <map>
#include <cstring>
#include <cctype>
using namespace std;

static int GetRepeatNum(string str)
{
    int maxnum = 0;
    map<char, int> map;

    for(char* c = &str[0]; *c; c++)
    {
        if(map.find(*c) != map.end())
        {
            map[*c] ++;
            if(map[*c] > maxnum)
            {
                maxnum = map[*c];
            }
        }
        else
        {
            map.insert(pair<char,int>(*c, 1));
        }
    }

    return maxnum;
}

static string LetterCountI(string str)
{
    map<string, int> map;

    // 1. str array
    int left = 0;
    int right = 0;
    int length = (int)(str.length());
    for(int i = 0; i < length; i++)
    {
        char c = str[i];
        if(c == ' ' || i == length - 1)
        {
            string sub = str.substr(left, right - left + 1);
            int num = GetRepeatNum(sub);
            map.insert(pair<string, int>(sub, num));
            //cout << sub << "   " << num << "\n";
            left = right + 1;
            right++;
        }
        else
        {
            right++;
        }
    }

    // 2. max
    string maxstr = "";
    int maxnum = -1;
    for(std::map<string, int>::iterator it = map.begin(); it != map.end(); ++it)
    {
        if(it->second > maxnum)
        {
            maxnum = it->second;
            maxstr = it->first;
        }
    }

    if(maxnum <= 1)
    {
        return "-1";
    }
    else
    {
        return maxstr;
    }
}

int Consecutive(int arr[], int length)
{
    std::set<int> sortnums;

    for(int i = 0; i < length; i++)
    {
        sortnums.insert(arr[i]);
    }

    cout << (int)(*sortnums.rbegin()) << " " << (int)(*sortnums.begin()) << " " << length << "\n";
    return (int)(*sortnums.rbegin()) - (int)(*sortnums.begin()) - length + 1;
}

int solution(int arr[], int length)
{
    if(length == 0)
    {
        return -1;
    }

    long left = 0;
    long right = 0;

    for(int i = 1; i < length; i++)
    {
        right += arr[i];
    }

    if(left == right)
    {
        return 0;
    }

    for(int p = 1; p < length; p++)
    {
        left += arr[p-1];
        right -= arr[p];

        if(left == right)
        {
            return p;
        }
    }

    return -1;
}



//#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    bool runFinished = false;
    if(runFinished)
    {
        int A[] = {2, 10, -4};
        cout << Consecutive(A,sizeof(A)/sizeof(*A)) << "\n";
        cout << LetterCountI("abcd efg i xxx") << "\n";
        cout << LetterCountI("abcd efg i x") << "\n";
    }

    int arr[] = {-1, 5, 2, -3};
    cout << solution(arr, sizeof(arr)/sizeof(*arr));

    return 0;
}
#endif




