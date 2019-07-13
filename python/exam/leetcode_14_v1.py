
'''
14. Longest Common Prefix

Write a function to find the longest common prefix string amongst an array of strings.

If there is no common prefix, return an empty string "".

Example 1:

Input: ["flower","flow","flight"]
Output: "fl"
Example 2:

Input: ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
Note:

All given inputs are in lowercase letters a-z.
'''

class Solution:
    def strxor(self, str1, str2):
        result = ''
        min_len = len(str1) if len(str1) < len(str2) else len(str2)
        for i in range(0, min_len):
            if str1[i] == str2[i]:
                result += str1[i]
            else:
                break
        return result

    def longestCommonPrefix(self, strs):
        if len(strs) == 0: 
            return ""
        result = strs[len(strs) - 1]
        for str in strs:
            result = self.strxor(str, result)
        return result

def main():
    inputs = ["flower","flow","flight"]
    ret = Solution().longestCommonPrefix(inputs)
    print(ret)

if __name__ == '__main__':
    main()