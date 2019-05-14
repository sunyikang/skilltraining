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

bool hasValue(const vector<int>& v, int x)
{
    if(std::find(v.begin(), v.end(), x) != v.end())
        return true;
    return false;
}

int minimalCost(int n, vector < string > pairs) {

    if(n == 0) return 0;

    vector<vector<int>> map;

    for(int i = 0; i < n; i ++)
    {
        vector<int> v;
        v.push_back(i + 1);
        map.push_back(v);
    }

    for(int i = 0; i < (int)pairs.size(); i++)
    {
        string str = pairs[i];

        int index = str.find(" ");
        string left = str.substr(0, index);
        string right = str.substr(index + 1, str.length() - index - 1);

        std::string::size_type sz;   // alias of size_t
        int x = std::stoi (left,&sz);
        int y = std::stoi (right,&sz);

        vector<int>* leftV = NULL;
        vector<int>* rightV = NULL;
        for(std::vector<vector<int>>::iterator it = map.begin(); it != map.end(); ++it)
        {
            vector<int>* v = &(*it);
            if(hasValue(*v, x))
            {
                leftV = v;
            }

            if(hasValue(*v, y))
            {
                rightV = v;
            }
        }

        if(leftV != NULL && rightV != NULL && leftV != rightV)
        {
            for(std::vector<int>::iterator it = rightV->begin(); it != rightV->end(); ++it)
            {
                /* std::cout << *it; ... */
                int value = *it;
                leftV->push_back(value);
            }
            rightV->clear();
        }
    }

    int result = 0;
    for(std::vector<vector<int>>::iterator it = map.begin(); it != map.end(); ++it)
    {
        vector<int> v = *it;
        if((int)v.size() != 0)
        {
            result += ceil(sqrt(v.size()));
        }
    }

    return result;
}

/*
 int main() {
    ofstream fout(getenv("OUTPUT_PATH"));
    int res;
    int _n;
    cin >> _n;
    cin.ignore (std::numeric_limits<std::streamsize>::max(), '\n');


    int _pairs_size = 0;
    cin >> _pairs_size;
    cin.ignore (std::numeric_limits<std::streamsize>::max(), '\n');
    vector<string> _pairs;
    string _pairs_item;
    for(int _pairs_i=0; _pairs_i<_pairs_size; _pairs_i++) {
        getline(cin, _pairs_item);
        _pairs.push_back(_pairs_item);
    }

    res = minimalCost(_n, _pairs);
    fout << res << endl;

    fout.close();
    return 0;
}
 */

int getMaxPopulation(vector<int> cities, int vac)
{
    int length = (int)cities.size();

    int sum = 0;
    for(int i = 0; i < length; i ++)
    {
        sum += cities[i];
    }

    int distributedVacNum = 0;
    vector<int> vaclist;
    vector<float> maxlist;
    float div = sum / vac;

    cout << "div : " << div << " " << "\n";

    for(int i = 0; i < length; i++)
    {
        int vacNum = floor(cities[i] / div);
        vaclist.push_back(vacNum);
        float pop = (float)cities[i] / (float)vacNum;
        maxlist.push_back(pop);
        distributedVacNum += vacNum;

        cout << "city id: " << vacNum << "\t  average pop per vac : " << pop << "\t  vac num:" << vacNum << "\n";
    }

    sort(maxlist.rbegin(), maxlist.rend());

    int left = vac - distributedVacNum;

    return maxlist[left];
}

string RevertString(input)
{
    return input;
}

int main(void)
{
    string input = "I_Love_You";
    string result = RevertString(input);
    cout << result
}
#endif
