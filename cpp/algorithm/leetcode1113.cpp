#include <iostream>
#include <set>
#include <stdio.h>
#include <map>
#include <cstring>
#include <cctype>
#include <vector>
#include <memory>
using namespace std;


int chosedNum = 6;

int guess(int num)
{
    if(num > chosedNum)
        return -1;
    else if(num < chosedNum)
        return 1;
    else
        return 0;
}

class LeetCode1113 {

public:
    int guessHelper(long left, long right)
    {
        long mid = (left + right) / 2;
        if(guess(mid) > 0)
        {
            return guessHelper(mid + 1, right);
        }
        else if(guess(mid) < 0)
        {
            return guessHelper(left, mid - 1);
        }
        else
        {
            return mid;
        }
    }

    int guessNumber(int n)
    {
        return guessHelper(0, n);
    }

    int guessNumber2(int n)
    {
        long left=0;
        long right = n;
        while(left <= right)
        {
            long mid = (left + right)/ 2;

            if(guess(mid) > 0)
            {
                left = mid + 1;
            }
            else if(guess(mid) < 0)
            {
                right = mid -1;
            }
            else
            {
                return mid;
            }
        }
        return -1;
    }

    int searchInsert(vector<int>& nums, int target)
    {
        if(target < nums[0])
            return 0;

        if(target > nums[nums.size() - 1])
            return nums.size();

        int left = 0;
        int right = nums.size() - 1;
        while(left <= right)
        {
            int mid = (left + right) / 2;

            if(nums[mid] < target)
                left = mid + 1;
            else if(nums[mid] > target)
                right = mid - 1;
            else
                return mid;
        }

        return left;
    }

    int findRightLast(vector<int>& nums, int left, int right, int target)
    {
        if(nums[left] == nums[right])
            return right;

        while(left+1 < right)
        {
            int mid = (left + right)/2;
            if(nums[mid] == target)
            {
                left = mid;
            }
            else
            {
                right = mid -1;
            }
        }
        return (nums[left] == nums[right]) ? right : left;
    }

    int findLeftFirst(vector<int>& nums, int left, int right, int target)
    {
        if(nums[left] == nums[right])
            return left;

        while(left + 1 < right)
        {
            int mid = (left + right)  /2;
            if(nums[mid] == target)
            {
                right = mid;
            }
            else
            {
                left = mid + 1;
            }
        }
        return (nums[left] == nums[right]) ? left : right;
    }

    vector<int> searchRange(vector<int>& nums, int target)
    {
        vector<int> range;

        if(target < nums[0] || target > nums[nums.size() - 1])
        {
            range.push_back(-1);
            range.push_back(-1);
            return range;
        }

        int left = 0;
        int right = nums.size() - 1;
        int mid = (left + right) / 2;
        while (left+1 < right)
        {
            mid = (left + right) / 2;
            int middleValue = nums[mid];
            if(middleValue < target)
            {
                left = mid;
            }
            else if(middleValue > target)
            {
                right = mid - 1;
            }
            else
            {
                break;
            }
        }

        if(left == right)
        {
            if(nums[left] == target)
            {
                range.push_back(left);
                range.push_back(left);
                return range;
            }
            else
            {
                range.push_back(-1);
                range.push_back(-1);
                return range;
            }
        }
        if(left + 1 == right)
        {
            if(nums[left] == target && nums[right] == target)
            {
                range.push_back(left);
                range.push_back(right);
                return range;
            }
            else if(nums[left] == target && nums[right] != target)
            {
                range.push_back(left);
                range.push_back(left);
                return range;
            }
            else if(nums[left] != target && nums[right] == target)
            {
                range.push_back(right);
                range.push_back(right);
                return range;
            }
            else if(nums[left] < target && target < nums[right])
            {
                range.push_back(-1);
                range.push_back(-1);
                return range;
            }
            else
            {
                cout << "error";
                range.push_back(-1);
                range.push_back(-1);
                return range;
            }
        }

        range.push_back(findLeftFirst(nums, left, mid, target));
        range.push_back(findRightLast(nums, mid, right, target));
        return range;
    }

    void printRange(vector<int> range)
    {
        cout << "\n";
        cout << range[0];
        cout << "\n";
        cout << range[1];
        cout << "\n";
    }


    struct ListNode {
         int val;
          ListNode *next;
          ListNode(int x) : val(x), next(NULL) {}
    };

    public:
    ListNode* mergeTwoLists(ListNode* l1, ListNode* l2)
    {
        if(l1 == NULL)
            return l2;

        if(l2 == NULL)
            return l1;

        if(l1->val < l2->val)
        {
            ListNode* t1 = l1;

            while(t1 != NULL && t1->next != NULL && t1->next->val < l2->val)
            {
                t1 = t1->next;
            }

            t1->next = mergeTwoLists(t1->next,l2);
            return l1;
        }
        else
        {
            ListNode* t2 = l2;

            while(t2 != NULL && t2->next != NULL && t2->next->val < l1->val)
            {
                t2 = t2->next;
            }

            t2->next = mergeTwoLists(l1, t2->next);
            return l2;
        }
    }


    public:
        ListNode* mergeTwoLists2(ListNode* l1, ListNode* l2)
        {
            if(l1 == NULL)
                return l2;

            if(l2 == NULL)
                return l1;

            if(l1->val < l2->val)
            {
                ListNode* t1 = l1;
                t1 = t1->next;
                l1->next = mergeTwoLists2(t1,l2);
                return l1;
            }
            else
            {
                ListNode* t2 = l2;
                t2 = t2->next;
                l2->next = mergeTwoLists2(l1, t2);
                return l2;
            }
        }
};

//#define VALID_MAIN
#ifdef VALID_MAIN
int main()
{
    LeetCode1113 lc;
    int result = 0;

    {

    }

    {
        // [1,2,3]
        // 1
        {
            vector<int> nums;
            nums.push_back(1);
            nums.push_back(2);
            nums.push_back(3);

            vector<int> range;

            range = lc.searchRange(nums, 1);
            lc.printRange(range);

        }

        // [1,5]
        // 4
        {
            vector<int> nums;
            nums.push_back(1);
            nums.push_back(5);

            vector<int> range;

            range = lc.searchRange(nums, 4);
            lc.printRange(range);

        }

        // [1,2,3,3,3,3,4,5,9]
        // 3
        {
            vector<int> nums;
            nums.push_back(1);
            nums.push_back(2);
            nums.push_back(3);
            nums.push_back(3);
            nums.push_back(3);
            nums.push_back(3);
            nums.push_back(4);
            nums.push_back(5);
            nums.push_back(9);

            vector<int> range;

            range = lc.searchRange(nums, 3);
            lc.printRange(range);
        }

        // [5, 7, 7, 8, 8, 10]
        {
            vector<int> nums;
            nums.push_back(5);
            nums.push_back(7);
            nums.push_back(7);
            nums.push_back(8);
            nums.push_back(8);
            nums.push_back(10);

            vector<int> range;

            range = lc.searchRange(nums, -1);
            lc.printRange(range);

            range = lc.searchRange(nums, 5);
            lc.printRange(range);

            range = lc.searchRange(nums, 7);
            lc.printRange(range);

            range = lc.searchRange(nums, 8);
            lc.printRange(range);

            range = lc.searchRange(nums, 10);
            lc.printRange(range);

            range = lc.searchRange(nums, 11);
            lc.printRange(range);
        }
    }

    {
        vector<int> numlist;
        numlist.push_back(1);
        numlist.push_back(3);
        numlist.push_back(5);
        numlist.push_back(6);
        result = lc.searchInsert(numlist, 3);
        cout << result;
        cout << "\n";
        result = lc.searchInsert(numlist, 4);
        cout << result;
        cout << "\n";
        result = lc.searchInsert(numlist, 5);
        cout << result;
        cout << "\n";
        result = lc.searchInsert(numlist, -1);
        cout << result;
        cout << "\n";
        result = lc.searchInsert(numlist, 7);
        cout << result;
        cout << "\n";
    }

    {
        result = lc.guessNumber(10);
        cout << result;
        cout << "\n";

        result = lc.guessNumber2(10);
        cout << result;
        cout << "\n";

        chosedNum = 1702766719;
        result = lc.guessNumber2(2126753390);
        cout << result;
        cout << "\n";
    }
}
#endif

