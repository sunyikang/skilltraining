#include <iostream>
#include <string>
#include <ctype.h>

using namespace std;

class TextInput
{
protected:
    string value;

public:
    virtual void add(char c) 
    {
        value += c;
    }

    string getValue() { return value; }
};

class NumericInput : public TextInput
{
    virtual void add(char c)
    {
        if(isdigit(c))
        {
            value += c;
        }
    }
};

#ifndef RunTests
int main()
{
    TextInput* input = new NumericInput();
    input->add('1');
    input->add('a');
    input->add('0');
    cout << input->getValue();
}
#endif