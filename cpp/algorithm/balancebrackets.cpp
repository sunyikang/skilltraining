#include <iostream>
#include <set>
#include <stack>
#include <list>
#include <stdio.h>
#include <vector>
#include <map>
#include <cstring>
#include <cctype>
using namespace std;





int solution4(string &S, int K) {

    // 1. convert to -1 2 2 2 4 8 -1 2 -1 -1 -1 -1 -1 -1 -1
    int stackvalue = 0;
    vector<int> valuelist;
    stack<int> frontbracketstack;
    for(int i = 0; i < S.length(); i++)
    {
        char c = S[i];
        if(frontbracketstack.size() == 0)
        {
            if(c == '(')
            {
                frontbracketstack.push('(');
            }
            else
            {
                valuelist.push_back(-1);
            }
        }
        else
        {
            if(c == '(')
            {
                frontbracketstack.push('(');
            }
            else
            {
                frontbracketstack.pop();
                stackvalue += 2;
                valuelist.push_back(stackvalue);
                stackvalue = 0;
            }
        }
    }

    valuelist.push_back(-frontbracketstack.size());

    for (int i = 0; i < valuelist.size(); i++)
    {
        cout << valuelist[i];
        cout << " / ";
    }
    cout << "\n";

    // 2. convert to -1 18 -1 2 -7
    vector<int> shorterlist;
    bool positive = valuelist[0]> 0;
    int value = 0;
    for(int i = 0; i < valuelist.size(); i++)
    {
        if(positive)
        {
            if(valuelist[i] > 0)
            {
                value += valuelist[i];
            }
            else
            {
                shorterlist.push_back(value);
                positive = false;
                value = valuelist[i];
            }
        }
        else
        {
            if(valuelist[i] < 0)
            {
                value += valuelist[i];
            }
            else
            {
                shorterlist.push_back(value);
                positive = true;
                value = valuelist[i];
            }
        }

        if(i == valuelist.size() - 1)
        {
            shorterlist.push_back(valuelist[i]);
        }
    }

    for (int i = 0; i < shorterlist.size(); i++)
    {
        cout << shorterlist[i];
        cout << " / ";
    }
    cout << "\n";

    // 3. compute the possible combination for max value
}

//#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    string str = ")()()((()))(((()))))()))))(((()";
    solution4(str, 10);
    return 0;
}
#endif
