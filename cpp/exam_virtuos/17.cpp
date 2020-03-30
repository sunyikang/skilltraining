/*
    Error1:   the list in {"foo", "bar"}, is not a template.
        vector<string>&& sv = makeVector({"foo", "bar"});
    Solution:  
        auto alist = std::initializer_list<string>({"foo", "bar"});

    Error2: makeVector() hasn't use template way to init
    Solution:
        ... = makeVector<string>(alist);

    Error3: vector<std::string>&& sv definition is wrong
    Solution:
        auto sv = ...
*/

#include <string>
#include <vector>
#include <utility>
#include <iostream>
using namespace std;

template<typename T>
vector<T>&& makeVector(initializer_list<T> init_list)
{
    return vector<T>(init_list);
}

int main()
{
    auto alist = std::initializer_list<string>({"foo", "bar"});
    auto sv = makeVector<string>(alist);
    cout << sv.size() << "\n";
    return 0;
}
