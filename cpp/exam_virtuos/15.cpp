#include <thread>
#include <iostream>

int maxCount = 5;
int counter = 1;

void even()
{
}

void odd()
{
}

int main()
{
    std::thread thread1(even);
    std::thread thread2(odd);
    thread1.join();
    thread2.join();
}
