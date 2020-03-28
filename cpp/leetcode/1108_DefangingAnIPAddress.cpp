/*
Requirement:

    https://leetcode.com/problems/defanging-an-ip-address/

    Given a valid (IPv4) IP address, return a defanged version of that IP address.

    A defanged IP address replaces every period "." with "[.]".

    

    Example 1:

    Input: address = "1.1.1.1"
    Output: "1[.]1[.]1[.]1"
    Example 2:

    Input: address = "255.100.50.0"
    Output: "255[.]100[.]50[.]0"
    

    Constraints:

    The given address is a valid IPv4 address.
*/

/*
Solution:
    
    Regenerate the string and replace the . by [.]
*/

#include <iostream>
#include <string>
using namespace std;

class Solution {
public:
    string defangIPaddr(string address) {
        string result = "";
        for (char const &c : address) {
            string str;
            if (c == '.') {
                str = "[.]";
            }
            else {
                str = c;
            }
            result += str;
        }
        return result;
    }
};


int main() {
    auto solution = Solution();

    string address = solution.defangIPaddr("1.1.1.1");
    cout << address << "\n";
}
