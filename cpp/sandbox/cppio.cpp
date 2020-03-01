/* 
    Run `./cppio.out 2> logs` to redirect cerr and clog into logs.txt file.
*/

#include <iostream>
using namespace std;

int main()
{
    cout << "Please enter your name: ";
    string name;
    cin >> name;
    cout << "Hello, " << name;
    cerr << "Error";
    clog << "\nLog";
    cout << "\n";
    return 0;
}
