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

class BankCustomer
{
    private: 
        string name;
        long money;
    
    public:
        BankCustomer(string name)
        {}

        BankCustomer(const BankCustomer &bc)
        {
            name = bc.name;
            money = bc.money;
        }

        BankCustomer operator=(const BankCustomer& bc)
        {
            name = bc.name;
            money = bc.money;
        }

        bool operator==(const BankCustomer& bc)
        {
            return name == bc.name && money == bc.money;
        }

        BankCustomer operator+(const BankCustomer& bc)
        {
            money += bc.money;
        }
};
