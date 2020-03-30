/*
Question:
    What is wrong with the following code. What is the name of this problem? Give another
    scenario where this occurs.

Answer:
    1) t1 ask for t2's locked wrapper; t2 asked for t1's locked wrapper; 
       but both locked wrapper point to the same locked value, which is 
       defined in main(), so they compete and dead.
    2) Dead lock.  
    3) A need x, y; B need x and y; A have x and wait for y; B has y and wait for x.
*/

#include <iostream>
#include <thread>
using namespace std;

void fun(std::thread *t, bool &locked)
{
    while (locked)
    {
    }
    t->join();
}

int main()
{
    std::thread t1;
    std::thread t2;
    bool locked = true;
    t1 = std::thread(fun, &t2, std::ref(locked));
    t2 = std::thread(fun, &t1, std::ref(locked));
    locked = false;
    return 0;
}
