/* hello.cpp */

#include <iostream>
#include <vector>
#include <unordered_set>
using namespace std;

vector<string> unique_names(const vector<string>& names1, const vector<string>& names2)
{
    unordered_set<string> nameset;
    for(auto name : names1)
    {
        nameset.insert(name);
    }
    for(auto name : names2)
    {
        nameset.insert(name);
    }
    vector<string> namevector(nameset.begin(), nameset.end());
    return namevector;
}

#ifndef RunTests
int main()
{
    vector<string> names1 = {"Ava", "Emma", "Olivia"};
    vector<string> names2 = {"Olivia", "Sophia", "Emma"};
    
    vector<string> result = unique_names(names1, names2);
    for(auto element : result)
    {
        cout << element << ' '; // should print Ava Emma Olivia Sophia
    }
}
#endif