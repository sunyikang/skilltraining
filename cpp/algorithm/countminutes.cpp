#include <iostream>
#include <stdio.h>
using namespace std;


static int ComputeMin(string str)
{
    int indexam = str.find("am");
    bool isam = (indexam > 0);

    int indexmid = str.find(":");
    string h = str.substr(0, indexmid);
    string m = str.substr(indexmid + 1, str.length() - indexmid - 1);

    int hours = (h == "12") ? 0 : stoi(h);
    int minutes = stoi(m);

    int pmvalue = isam ? 0 : 12 * 60;
    int total = hours * 60 + minutes + pmvalue;

    return total;
}

static string CountMinutes(string str)
{
    // 1. divide
    int index = str.find("-");
    string leftstr = str.substr(0, index);
    string rightstr = str.substr(index + 1, str.length() - index -1);

    // 2. calculate str 12:30pm
    int leftvalue = ComputeMin(leftstr);
    int rightvalue = ComputeMin(rightstr);

    int result = rightvalue - leftvalue;
    result += (result < 0) ? 24 * 60 : 0;

    return to_string(result);
}


//#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    string str = "12:30pm-12:00am";
    cout << CountMinutes(str) << "\n";

    str = "1:23am-1:08am";
    cout << CountMinutes(str) << "\n";
    return 0;
}
#endif

