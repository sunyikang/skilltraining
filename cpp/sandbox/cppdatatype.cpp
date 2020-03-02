// C++ program to sizes of data types 
#include<iostream> 
using namespace std; 
  
void different_datatype()
{
    // 1 byte
    cout << "Size of bool : " << sizeof(bool)  
      << " byte" << endl; 
    cout << "Size of char : " << sizeof(char)  
      << " byte" << endl; 

    // 2 bytes
    cout << "Size of short : " << sizeof(short)  
      << " bytes" << endl; 
    cout << "Size of short int : " << sizeof(short int)  
      << " bytes" << endl;

    // 4 bytes
    cout << "Size of int : " << sizeof(int) 
      << " bytes" << endl; 
    cout << "Size of float : " << sizeof(float)  
       << " bytes" <<endl; 
    cout << "Size of wchar_t : " << sizeof(wchar_t)  
       << " bytes" <<endl; 

    // 8 bytes
    cout << "Size of long : " << sizeof(long)  
       << " bytes" << endl; 
    cout << "Size of long long : " << sizeof(long long)  
       << " bytes" << endl; 
    cout << "Size of long int : " << sizeof(long int)  
       << " bytes" << endl; 
    cout << "Size of signed long int : " << sizeof(signed long int) 
       << " bytes" << endl; 
    cout << "Size of unsigned long int : " << sizeof(unsigned long int)  
       << " bytes" << endl; 
    cout << "Size of double : " << sizeof(double)  
       << " bytes" << endl; 

    // 16 bytes
    cout << "Size of long double : " << sizeof(long double)  
       << " bytes" << endl; 
}

void uninitialized_datatype() 
{ 
    // The following primitive data type variables will not 
    // be initialized with any default values 
    char ch; 
    float f; 
    int i; 
    double d; 
    long l; 
  
    cout << ch << endl; 
    cout << f << endl; 
    cout << i << endl; 
    cout << d << endl; 
    cout << l << endl; 
} 

void auto_storage_class()
{
    auto c = 'char';
    auto i = 1;

    cout << "\nc value: " << c << "\n";
    cout << "i value: " << i << "\n";
}

int main() 
{ 
    different_datatype();

    uninitialized_datatype();

    auto_storage_class();
    
    return 0; 
}
