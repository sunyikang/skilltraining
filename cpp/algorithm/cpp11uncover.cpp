#include <map>
#include <unordered_map>
#include <unordered_set>
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


#define VALID_MAIN
#ifdef VALID_MAIN


int Uppercase = 0; //modified by the lambda

void myfunction (char c)
{
    if (isupper(c))
        Uppercase++;
}

int main(void)
{
    {
    }

    {
    char s[]="Hello World!";
//       for_each(s, s+sizeof(s), [&Uppercase] (char c) {
//        if (isupper(c))
//         Uppercase++;
//        });

     for_each(s, s+sizeof(s), myfunction);
     cout<< Uppercase<<" uppercase letters in: "<< s<<endl;
    }
}
#endif
