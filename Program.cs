using System;
using System.Collections.Generic;
using System.Linq;


namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 7, 8 };
            int diff = 4;
            System.Console.WriteLine(ArithmeticTriplets(nums, diff));
        }
        /**
            LeetCode: Array
        */

        /*
       2367. Number of Arithmetic Triplets
       Time: 28:22 minutes
       Time complexity: O(n)
       Space complexity: O(n), which means that the memory usage increases linearly with the input size 'n'. This is because the code creates a dictionary object 'hash', which stores each element of the input array as a key-value pair.

       Best respond found:
        int count = 0;
        // Define a HashSet to store unique integers from the input array
        HashSet<int> hash_num = new HashSet<int>();
        // Iterate through each element in the input integer array "nums"
        foreach(int num in nums)
        {
            // Check if the HashSet contains two other integers which would form an arithmetic sequence with current element "num"
            if(hash_num.Contains(num - diff) && hash_num.Contains(num - 2 * diff))
            {
                // If the HashSet has both required integers, increment the arithmetic triplet count
                count++;
            }	
            // Add the current element "num" to the HashSet for future reference
            hash_num.Add(num);  
        }
       */
        public static int ArithmeticTriplets(int[] nums, int diff)
        {
            int count = 0;
            Dictionary<int, int> hash = new Dictionary<int, int>();
            for (int a = 0; a < nums.Length; a++)
            {
                hash.Add(nums[a], a);
            }

            for (int k = nums.Length - 1; k >= 0; k--)
            {
                int value = nums[k];
                int toFind = value - diff;
                if (hash.ContainsKey(toFind))
                {
                    if (hash.GetValueOrDefault(toFind) < k)
                    {
                        int j = hash.GetValueOrDefault(toFind);
                        value = nums[j];
                        toFind = value - diff;
                        if (hash.ContainsKey(toFind))
                        {
                            if (hash.GetValueOrDefault(toFind) < j)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }
        /*
       1773. Count Items Matching a Rule
       Time: 8:54 minutes
       Time complexity: O(n)
       Space complexity: O(1), which means it requires a fixed amount of memory regardless of the input size.
       */
        public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
        {
            return items.Where(y => ruleKey == "type" && y[0] == ruleValue || ruleKey == "color" && y[1] == ruleValue || ruleKey == "name" && y[2] == ruleValue).Count();
        }

        /*
       2652. Sum Multiples
       Time: 7:28 minutes
       Time complexity: O(n)
       Space complexity: O(1), which means it requires a fixed amount of memory regardless of the input size.
       */
        public static int SumOfMultiples(int n)
        {
            return Enumerable.Range(1, n).Where(i => i % 3 == 0 || i % 5 == 0 || i % 7 == 0).Sum();
        }

        /*
        1528. Shuffle String
        Time: 6:47 minutes
        Time complexity: O(n)
        Space complexity: O(n)
        */
        public static string RestoreString(string s, int[] indices)
        {
            char[] chars = new char[indices.Length];
            s.Select((x, i) => chars[indices[i]] = x).ToArray();
            return new String(chars);
        }

        /*
        1313. Decompress Run-Length Encoded List
        Time: 10:09 minutes
        Time complexity: O(n)
        Space complexity: O(m), where 'm' is the total number of integers generated
        */
        public static int[] DecompressRLElist(int[] nums)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i += 2)
            {
                int freq = nums[i];
                int val = nums[i + 1];
                result = result.Concat(Enumerable.Repeat(val, freq).ToList()).ToList();
            }
            return result.ToArray();
        }

        /*
        1720. Decode XORed Array
        Time: 9:02 minutes
        Time complexity: O(n), because the for loop runs for 'n' iterations where 'n' is the length of the input encoded array.
        Space complexity: O(n)
        */
        public static int[] Decode(int[] encoded, int first)
        {
            int[] original = new int[encoded.Length + 1];
            original[0] = first;

            for (int i = 0; i < encoded.Length; i++)
            {
                original[i + 1] = encoded[i] ^ original[i];
            }
            return original;
        }

        /*
        1389. Create Target Array in the Given Order
        Time: 5:37 minutes
        Time complexity: O(n^2), because the list 'target' is being constantly modified using the Insert() method, which in the worst case (i.e. when inserting at index 0) has to shift all elements to the right of it by one position.
        Space complexity: O(n)
        */
        public static int[] CreateTargetArray(int[] nums, int[] index)
        {
            List<int> target = new List<int>(nums.Length);
            for (int i = 0; i < nums.Length; i++)
            {
                target.Insert(index[i], nums[i]);
            }
            return target.ToArray();
        }

        /*
        1365. How Many Numbers Are Smaller Than the Current Number
        Time: 8:15 minutes
        Time complexity: O(n^2)
        Space complexity: O(n)
        */
        public static int[] SmallerNumbersThanCurrent(int[] nums)
        {
            return nums.Select(n => nums.Count(x => x < n)).ToArray();
        }

        /*
        2114. Maximum Number of Words Found in Sentences
        Time: 6:58 minutes
        Time complexity: O(n)
        Space complexity: O(1)
        */
        public static int MostWordsFound(string[] sentences)
        {
            return sentences.Select(x => x.Split(' ')).Select(x => x.Length).Max();
        }

        /*
        1480. Running Sum of 1d Array
        Time: 7:41 minutes
        Time complexity: O(n^2), Since the Select method iterates over each element and then creates a subarray for each element, and then sums elements of that subarray, the time complexity of this code is O(n^2).
        Space complexity: O(n), because it creates a new output array of the same size as the input array to store the running sum values. 
        */
        public static int[] RunningSum(int[] nums)
        {
            return nums.Select((n, i) => nums[..(i + 1)].Sum()).ToArray();
        }

        /*
        1672. Richest Customer Wealth
        Time: 9:50 minutes
        Time complexity: O(nm), where "n" is the number of rows in the accounts array and "m" is the number of columns in each row. This is because we are using LINQ's Select method to convert each row of the 2D array into a 1D array and calculating the sum of each 1D array using the Sum method.
        Space complexity: O(1), as only constant extra space is used for holding some additional variables.
        */
        public static int MaximumWealth(int[][] accounts)
        {
            return accounts.Select(x => x.Sum()).Max();
        }

        /*
        2574. Left and Right Sum Differences
        Time: 5:12 minutes
        Time complexity: O(n^2), where n is the length of the nums array. This is because for each element in the nums array, the code needs to calculate the sum of all elements to its right and left using LINQ's Sum method. 
        Space complexity: O(n), where n is the length of the nums array. This is because the code creates three new arrays (rigthSum, leftSum, and answer) each containing n elements, one for each element of the nums array.
        */
        public static int[] LeftRightDifference(int[] nums)
        {
            int[] rigthSum = nums.Select((n, i) => nums[(i + 1)..].Sum()).ToArray();
            int[] leftSum = nums.Select((n, i) => nums[..(i)].Sum()).ToArray();
            int[] answer = leftSum.Select((x, i) => Math.Abs(x - rigthSum[i])).ToArray();
            return answer;
        }

        /*
        1431. Kids With the Greatest Number of Candies
        Time: 10:05 minutes
        Time complexity: O(n), where n is the length of the candies array. This is because the code uses LINQ's Select method which iterates through each element of the candies array once, and has a constant time complexity for each iteration. 
        Space complexity: O(n), where n is the length of the candies array. This is because the code creates a new list (ToList()) containing n boolean values, one for each element of the candies array.
        */
        public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            return candies.Select(x => ((x + extraCandies) >= candies.Max())).ToList();
        }

        /*
        1512. Number of Good Pairs
        Time: 6:23 minutes
        Time complexity: O(n^2), where n is the length of the input array nums. This is because there are two nested loops, and each loop iterates over almost all elements in the array.
        Space complexity: O(1), since only one integer variable number is created and used throughout the entire function, and no additional data structures are used.
        */
        public static int NumIdenticalPairs(int[] nums)
        {
            int number = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int val = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (val == nums[j])
                    {
                        number++;
                    }
                }
            }
            return number;
        }

        /*
        2011. Final Value of Variable After Performing Operations
        Time: 8:45 minutes
        Learned: 
        Contains

        Time complexity: O(n), where n is the length of the input array operations. This is because the foreach loop iterates over each element in the array, which is a constant time operation.
        Space complexity: O(1), since only one integer variable result is created and used throughout the entire function, resulting in constant space complexity.
        */
        public static int FinalValueAfterOperations(string[] operations)
        {
            int result = 0;
            foreach (var item in operations)
            {
                if (item.Contains('-')) result = result - 1;
                if (item.Contains('+')) result = result + 1;
            }
            return result;
        }

        /*
        1929. Concatenation of Array
        Time: 9:17 minutes
        Learned: 
        Array.Copy
        rray.ConstrainedCopy

        Time complexity: O(n), where n is the length of the input array nums. This is because two Array methods are called with O(n) time complexity, and copying an array takes linear time.
        Space complexity: O(n), since the output array has twice the length of the input array, resulting in O(2n) = O(n) space complexity.
        */
        public int[] GetConcatenation(int[] nums)
        {
            int[] result = new int[nums.Length * 2];
            Array.Copy(nums, result, nums.Length);
            Array.ConstrainedCopy(nums, 0, result, nums.Length, nums.Length);
            return result;
        }

        /*
        1470. Shuffle the Array
        Time: 5:59 minutes

        Time complexity: O(n), where n is the length of the input array nums. This is because the for loop runs exactly n times.
        Space complexity: O(n), since the output array has the same length as the input array, resulting in O(n) space complexity.
        */
        public static int[] Shuffle(int[] nums, int n)
        {
            int[] result = new int[nums.Length];
            for (int i = 0, j = n, k = 0; i <= n - 1 && j < nums.Length && k < nums.Length; i++, j++, k++)
            {
                result[k] = nums[i];
                k++;
                result[k] = nums[j];
            }
            return result;
        }

        /*
        1920. Build Array from Permutation
        Time: 7:32 minutes
        Time complexity: O(n), where n is the length of the input array nums. This is because the for loop iterates over each element in the array once, resulting in a linear time complexity.
        Space complexity:  O(n), as an additional array result is created with the same length as the input array.
        */
        public static int[] BuildArray(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums;
            int[] result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int val = nums[nums[i]];
                result[i] = val;
            }
            return result;
        }
    }


}
