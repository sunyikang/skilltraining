#include <iostream>
#include <set>
#include <stdio.h>
#include <map>
#include <cstring>
#include <cctype>
#include <vector>
#include <memory>
#include <stack>
using namespace std;

bool comparefunction(int n1, int n2)
{
    string s1 = std::to_string(n1);
    string s2 = std::to_string(n2);

    int c1 = atoi((s1 + s2).c_str());
    int c2 = atoi((s2 + s1).c_str());

    return c1 > c2;
}

class ListNode
{
public:
    int val;
    ListNode* next;

public:
    ListNode(int value)
    {
        this->val = value;
        this->next = NULL;
    }

    ~ListNode()
    {
        delete this->next;
        this->next = NULL;
    }
};

class LeetCode1116 {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) {

        // 0. exception
        if(n == 0)
            return;

        if(m == 0)
        {
            for(int i = 0; i < n; i++)
                nums1[i] = nums2[i];

            return;
        }

        // 1. move to right with m unit
        for(int i = m - 1; i >= 0; i --)
        {
            nums1[i + n] = nums1[i];
        }

        // 2. compair and insert
        int id = 0;
        int id1 = n;
        int id2 = 0;

        while(id1 < n + m && id2 < n)
        {
            if(nums1[id1] < nums2[id2])
            {
                nums1[id] = nums1[id1];
                id1++;
            }
            else
            {
                nums1[id] = nums2[id2];
                id2++;
            }

            id++;
        }

        if(id1 == n + m)
        {
            for(int i = id; i < n+m; i++)
            {
                nums1[id++] = nums2[id2++];
            }
        }
    }

    string convertToTitle(int n) {

        if(n < 0)
            return "";

        std::stack<int>* stack = new std::stack<int>();
        string result = "";

        int x = n;
        int value = 0;
        int left = 0;
        do
        {
            value = x % 26;
            left = x / 26;

            if(value == 0)
            {
                value = 26;
                left --;
            }

            stack->push(value);

            if(left != 0)
            {
                x = left;
            }
        }
        while(left != 0);

        while(stack->size() != 0)
        {
            int num = stack->top();
            if(num == 26)
                result += 'Z';
            else
                result += (char)(num - 1 + (int)'A');
            stack->pop();
        }

        return result;
    }

    string convertToTitle2(int n)
    {
        string str = "";
        while(n > 0) { str += 'A' + (n - 1) % 26; n = (n - 1) / 26;}
        reverse(str.begin(), str.end());
        return str;
    }

    string largestNum(vector<int> nums)
    {
        string result = "";
        std::sort(nums.begin(), nums.end(), comparefunction);

        for (std::vector<int>::iterator it=nums.begin(); it!=nums.end(); ++it)
          result += std::to_string(*it);

        std::cout << "nums contains:";
        for (std::vector<int>::iterator it=nums.begin(); it!=nums.end(); ++it)
          std::cout << ' ' << *it;
        std::cout << '\n';

        return result;
    }

    void PrintLink(ListNode* root)
    {
        while(root!=NULL)
        {
            cout << root->val;
            root = root->next;
        }
        cout << "\n";
    }

    ListNode* Merge(ListNode* left, ListNode* right)
    {
        ListNode* root = new ListNode(0);
        ListNode* node = root;

        while(left != NULL && right != NULL)
        {
            if(left->val < right->val)
            {
                node->next = left;
                left = left->next;
            }
            else
            {
                node->next = right;
                right = right->next;
            }

            node = node->next;
        }

        if(left == NULL)
            node->next = right;

        if(right == NULL)
            node->next = left;

        node = root;
        root = root->next;
        node->next = NULL;
        delete node;

        return root;
    }

    ListNode* sortList(ListNode* root)
    {
        if(root == NULL || root->next == NULL)
            return root;

        ListNode* quick = root->next;
        ListNode* slow = root;

        while(quick != NULL && quick->next != NULL)
        {
            quick = quick->next->next;
            slow = slow->next;
        }

        ListNode* mid = slow->next;
        slow->next = NULL;

        root = sortList(root);
        mid = sortList(mid);

        return Merge(root, mid);
    }

    ListNode* insertToLeft(ListNode* head, ListNode* currentNode)
    {
        ListNode* beforeCurrent = head;

        // 1. find beforecurrent
        while(beforeCurrent->next != currentNode)
        {
            beforeCurrent = beforeCurrent->next;
        }

        // 2. break beforeCurrent and currentNode
        beforeCurrent->next = NULL;

        // 3. insert
        if(head->val > currentNode->val)
        {
            beforeCurrent->next = currentNode->next;
            currentNode->next = head;
            return currentNode;
        }
        else if(beforeCurrent->val < currentNode->val)
        {
            beforeCurrent->next = currentNode;
            return head;
        }
        else
        {
            ListNode* temp = head;
            while(temp != NULL && temp->next != NULL && temp->next->val < currentNode->val)
            {
                temp = temp->next;
            }

            beforeCurrent->next = currentNode->next;
            currentNode->next = temp->next;
            temp->next = currentNode;

            return head;
        }
    }

    ListNode* insertionSortList(ListNode* head)
    {
        if(head == NULL) return NULL;

        ListNode* p = head->next;

        while(p != NULL)
        {
            ListNode* pNext = p->next;
            head = insertToLeft(head, p);
            p = pNext;
        }

        return head;
    }

    ListNode* insertionSortList2(ListNode* head)
    {
        if(head == NULL) return NULL;
        
        ListNode* newhead = new ListNode(0);
        newhead->next = head;

        ListNode* before = head;
        ListNode* current = head->next;

        while(current != NULL)
        {
            if(before->val > current->val)
            {
                before->next = current->next;

                if(newhead->next->val > current->val)
                {
                    current->next = newhead->next;
                    newhead->next = current;
                }
                else
                {
                    ListNode* temp = newhead;
                    while(temp->next != before)
                    {
                        temp = temp->next;
                        if(temp->next->val > current->val)
                        {
                            current->next = temp->next;
                            temp->next = current;
                            break;
                        }
                    }
                }

                current = before->next;
            }
            else
            {
                before = before->next;
                current = before->next;
            }
        }

        head = newhead->next;
        delete newhead;
        return head;
    }
};

//#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    LeetCode1116 lc;

    {
        ListNode* root = new ListNode(4);
        ListNode* node = root;
        node->next = new ListNode(3);
        node = node->next;
        node->next = new ListNode(2);
        node = node->next;
        node->next = new ListNode(1);
        node = node->next;
        root = lc.insertionSortList2(root);
        lc.PrintLink(root);
    }

    return -1;

    {
        ListNode* root = new ListNode(5);
        ListNode* node = root;
        node->next = new ListNode(4);
        node = node->next;
        node->next = new ListNode(6);
        node = node->next;
        node->next = new ListNode(1);
        node = node->next;

        root = lc.sortList(root);

        lc.PrintLink(root);
    }


    {
        vector<int> nums;
        nums.push_back(3);
        nums.push_back(30);
        nums.push_back(34);
        nums.push_back(31);
        nums.push_back(5);
        cout << lc.largestNum(nums) << "\n";
    }


    {
        cout << lc.convertToTitle2(1) << "\n";
        cout << lc.convertToTitle2(26) << "\n";
        cout << lc.convertToTitle2(52) << "\n";
        cout << lc.convertToTitle2(27) << "\n";
        cout << lc.convertToTitle2(241523523) << "\n";
    }

    {
        vector<int> nums1;
        nums1.push_back(1);
        nums1.push_back(2);
        nums1.push_back(5);
        nums1.push_back(6);
        nums1.push_back(7);
        nums1.push_back(0);
        vector<int> nums2;
        nums2.push_back(3);
        lc.merge(nums1, 5, nums2, 1);
        for(int i = 0; i < (int)nums1.size(); i++)
        {
            cout << to_string(nums1[i]) + " ";
        }
        cout << "\n";
    }

    {
        vector<int> nums1;
        nums1.push_back(1);
        vector<int> nums2;
        lc.merge(nums1, 1, nums2, 0);
        for(int i = 0; i < (int)nums1.size(); i++)
        {
            cout << to_string(nums1[i]) + " ";
        }
        cout << "\n";
    }

    {
        vector<int> nums1;
        nums1.push_back(0);
        vector<int> nums2;
        nums2.push_back(1);
        lc.merge(nums1, 0, nums2, 1);
        for(int i = 0; i < (int)nums1.size(); i++)
        {
            cout << to_string(nums1[i]) + " ";
        }
        cout << "\n";
    }
}
#endif

