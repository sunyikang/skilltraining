#include <mutex>
#include <thread>
#include <iostream>
using namespace std;

int maxCount = 5;
int counter = 1;
mutex m; // Mutex to protect this counter

void even()
{
    while (counter < maxCount)
    {
        if (counter % 2 == 1)
        {
            lock_guard<mutex> locker (m);
            cout << "Even: " << counter << "\n";
            counter++;
        }
    }
}

void odd()
{
    while (counter <= maxCount)
    {
        if (counter % 2 == 1)
        {
            lock_guard<mutex> locker (m);
            cout << "Odd: " << counter << "\n";
            counter++;
        }
    }
}

int main()
{
    std::thread thread1(even);
    std::thread thread2(odd);
    thread1.join();
    thread2.join();
}
