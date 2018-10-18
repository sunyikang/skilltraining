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


class LFUCache {
private:
    // 1. mapkv has a hashtable<key, value>
    unordered_map<int, int> mapkv;
    int capacity = 0;

    // 2. mapfreq has a hashtable<frequence, hashset<key>>
    unordered_map<int, unordered_set<int>> mapfreq;

public:
    LFUCache(int capacity) {
        // init mapkv
        mapkv.reserve(capacity);
        this->capacity = capacity;

        // init mapfreq
    }

    int get(int key) {

        cout << "get key " << key << "\n";

        // if mapkv doesn't have key, return -1;
        if(mapkv.size() == 0) return -1;

        unordered_map<int, int>::iterator keyvaluepair = mapkv.find(key);
        if(keyvaluepair == mapkv.end()) { cout << "cannot find " << key << "\n\n\n";  return -1; }

        // else
        // 1) check frequence from small to big, get the hashset<key>, and check whether
        //    there is the key inside (must has)
        // 2) remove key from this hashset, and get its frequence and key
        int frequence = -1;
        for( auto &it : mapfreq )
        {
            unordered_set<int>& item = it.second;
            unordered_set<int>::const_iterator got = item.find(key);

            if(got != item.end())
            {
                frequence = it.first;
                item.erase(got);

                cout << "remove " << key << " from mapfreq\n";
                break;
            }
        }

        // 3) check whethere there is an item in mapfreq with (frequence + 1),
        //    if yes, add key in, else, create a items firstly and add key in.
        unordered_map<int, unordered_set<int>>::iterator got = mapfreq.find(frequence + 1);
        if(got == mapfreq.end())
        {
            // create new
            unordered_set<int> newset;
            newset.insert(key);
            pair<int,unordered_set<int>> pair(frequence + 1, newset);
            mapfreq.insert(pair);

            cout << "add " << key << " to frequence " << frequence + 1 << " in mapfreq\n";
        }
        else
        {
            // add key in
            unordered_set<int>& oldset = got->second;
            oldset.insert(key);

            cout << "add " << key << " to frequence " << got->first << " in mapfreq\n";
        }

        print();

        // 4) return key's value
        cout << "get key " << key << " value " << mapkv[key] << "\n";
        return mapkv[key];
    }

    void set(int key, int value) {

        cout << "set key " << key << " value " << value << "\n";

        if(value < 0 || this->capacity <=0) return;

        // check whether the key already exists in mapkv, if yes, do nothing, else continue
        unordered_map<int, int>::const_iterator got = mapkv.find(key);
        if(got != mapkv.end() && this->get(key) != value)
        {
            mapkv[key] = value;
            return;
        }

        // if mapkv size = capacity, remove less frequence used key
        // 1) find the smallest frequence, get hashset<key>, pop table.begin() and get the old key
        // 2) remove old key from mapkv
        if((int)mapkv.size() == this->capacity)
        {
            // delete smallest frequency used item from mapfreq
            int oldkey = -1;
            for(int i = 0; i < (int)mapfreq.size(); i++)
            {
                unordered_set<int>& oneset = mapfreq[i];
                if(oneset.size() != 0)
                {
                    unordered_set<int>::iterator lastSetItem;
                    for (std::unordered_set<int>::iterator iter = oneset.begin(); iter != oneset.end(); iter++)
                        lastSetItem = iter;

                    oldkey = *(lastSetItem);
                    oneset.erase(lastSetItem);

                    cout << "remove " << oldkey << " from mapfreq\n";
                    break;
                }
            }

            // delete smallest frequency used item from mapkv
            unordered_map<int,int>::iterator deletingit = mapkv.find(oldkey);
            if(deletingit == mapkv.end())
            {
                cout << "something wrong";
            }
            else
            {
                mapkv.erase(deletingit);

                cout << "remove " << oldkey << " from mapkv\n";
            }
        }

        // add key value to mapkv
        pair<int, int> item(key, value);
        mapkv.insert(item);

        // add frequence (0) and key to mapfreq
        unordered_map<int, unordered_set<int>>::iterator freqOne = mapfreq.find(0);
        if(freqOne == mapfreq.end())
        {
            unordered_set<int> newset;
            newset.insert(key);
            pair<int, unordered_set<int>> freqitem(0, newset);
            mapfreq.insert(freqitem);

            cout << "add new " << key << " to mapkv\n";
        }
        else
        {
            unordered_set<int>& oldset = freqOne->second;
            oldset.insert(key);

            cout << "add old " << key << " to mapkv\n";
        }

        print();
    }

    void print()
    {
        // mapkv key : value
        cout << "mapkv:  ";
        for(auto it : mapkv)
        {
            cout << "[" << it.first << " : " << it.second << "]  ";
        }
        cout << "\n";

        // mapfreq freq : key1, key2 ...
        cout << "mapfreq:  \n";
        for(auto it : mapfreq)
        {
            cout << it.first << " : [";
            unordered_set<int> oneset = it.second;
            for(auto it : oneset)
            {
                cout << it << ",";
            }
            cout << "]\n";
        }
        cout << "\n\n";
    }
};


/*
 * how to get duplicate value from array
 */

vector<int> getDupliate(const vector<int>& array)
{
    vector<int> result;
    int length = (int)array.size();
    vector<bool> state(length);

    for(auto index : array)
    {
        // if meet false, change to true
        // if meet true, means meet duplicate value

        if(!state[index-1])
            state[index-1] = true;
        else
            result.push_back(index);
    }

    return result;
}

const std::vector<int>& get_ints()
{
   std::vector<int> i{ 0, 1, 2, 3 };
   return i;
}

std::vector<int>& get_ints2() // notice it's missing the const!
{
   static std::vector<int> i{ 0, 1, 2, 3 };
   return i;
}

//#define VALID_MAIN
#ifdef VALID_MAIN
int main(void)
{
    {
        vector<int> array;
        array.push_back(4);
        array.push_back(2);
        array.push_back(2);
        array.push_back(4);
        array.push_back(5);
        vector<int> result = getDupliate(array);

        for(auto it : result)
        {
            cout << it << " ";
        }
    }

//    {
////        ["LFUCache","set","set","set","set","get","get"]
////        [[2],[2,1],[1,1],[2,3],[4,1],[1],[2]]

//        LFUCache* cache = new LFUCache( 2 /* capacity */ );

//        cache->set(2, 1);
//        cache->set(1, 1);
//        cache->set(2, 3);
//        cache->set(4, 1);
//        cache->get(1);
//        cache->get(2);
//    }

//    return 0;

//    {
//        LFUCache* cache = new LFUCache( 0 /* capacity */ );

//        cache->set(0, 0);
//        cache->get(0);       //
//    }

//    {
//        LFUCache* cache = new LFUCache( 2 /* capacity */ );

//        cache->set(3, 1);
//        cache->set(2, 1);    // returns 1
//        cache->set(2, 2);    // evicts key 2
//        cache->set(4, 4);    // evicts key 1->
//        cache->get(2);       //
//    }

//    {
//        LFUCache* cache = new LFUCache( 2 /* capacity */ );

//        cache->set(1, 1);
//        cache->set(2, 2);
//        cache->get(1);       // returns 1
//        cache->set(3, 3);    // evicts key 2
//        cache->get(2);       // returns -1 (not found)
//        cache->get(3);       // returns 3->
//        cache->set(4, 4);    // evicts key 1->
//        cache->get(1);       // returns -1 (not found)
//        cache->get(3);       // returns 3
//        cache->get(4);       // returns 4
//    }

//    {
//        vector<int> cities;
//        cities.push_back(200);
//        cities.push_back(300);
//        cities.push_back(500);
//        cities.push_back(400);
//        cout << getMaxPopulation(cities, 11);
//    }

//    {
//        int citynum = 0;
//        cin >> citynum;
//        int vacnum = 0;
//        cin >> vacnum;

//        vector<int> cities;
//        for(int i = 0; i < citynum; i++)
//        {
//            int citypopulation = 0;
//            cin >> citypopulation;
//            cities.push_back(citypopulation);
//        }

//        cout << getMaxPopulation(cities, vacnum);
//    }


//    {
//        vector < string > pairs;
//        pairs.push_back("1 2");
//        pairs.push_back("1 4");
//        int result = minimalCost(4, pairs);
//        cout << result << "\n";
//    }

}
#endif
