using System;
using System.Collections.Generic;
using System.Linq;

namespace program_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter 1, 2 or 3 to execute specific Challenge:");
            string options = Console.ReadLine();

            switch (Int32.Parse(options))
            {
                case 1:
                    challengeSortNumber();
                    break;
                case 2:
                    challengePalindromicNumber();
                    break;
                case 3:
                    challengeAnagram();
                    break;
                default:
                    Console.WriteLine("Other");
                    break;
            }


        }
        static void challengeSortNumber()
        {
            List<int> randomList = new List<int>();
            var randomNumber = Enumerable.Range(1, 100).OrderBy(i => Guid.NewGuid());

            foreach (int num in randomNumber)
            {
                randomList.Add(num);

            }
            foreach (int num in randomList)
            {
                System.Console.WriteLine("Unsorted Number: " + num);
            }
            for (int i = 0; i <= randomList.Count - 1; i++)
            {
                for (int j = i + 1; j < randomList.Count; j++)
                {
                    if (randomList[i] > randomList[j])
                    {
                        int temp = randomList[i];
                        randomList[i] = randomList[j];
                        randomList[j] = temp;
                    }
                }
            }
            foreach (int num in randomList)
            {
                System.Console.WriteLine("Sorted Number: " + num);
            }

        }

        static void challengePalindromicNumber()
        {
            var palindrom = 0;

            for (var min = 990; min > 99; min -= 11)
            {

                for (var max = 999; max > 99; max--)
                {

                    var palindromNum = min * max;

                    if (palindrom < palindromNum && isPalindrome(palindromNum))
                    {
                        palindrom = palindromNum;
                        break;
                    }
                    else if (palindromNum < palindrom)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(palindrom);
        }
        static Boolean isPalindrome(int palnum)
        {

            var number = 0;
            var m = palnum;

            while (palnum > 0)
            {
                number = number * 10 + palnum % 10;
                palnum = palnum / 10 | 0;
            }
            return number == m;
        }

        static void challengeAnagram()
        {
            //Receive Words from User  
            Console.Write("Enter first word:");
            string wordnum1 = Console.ReadLine();
            Console.Write("Enter second word:");
            string wordum2 = Console.ReadLine();

            //Remove special characters from inputed words.  
            wordnum1 = System.Text.RegularExpressions.Regex.Replace(wordnum1, @"\s+|!#$%&/()=?»«@£§€{}.-;'<>_,", "");
            wordum2 = System.Text.RegularExpressions.Regex.Replace(wordum2, @"\s+|!#$%&/()=?»«@£§€{}.-;'<>_,", "");

            //convert inputed string to a array of characters 
            char[] char1 = wordnum1.ToLower().ToCharArray();
            char[] char2 = wordum2.ToLower().ToCharArray();

            //Sort arrays into ascending order
            Array.Sort(char1);
            Array.Sort(char2);

            //Assign sorted string to new strig variable  
            string newWrd1 = new string(char1);
            string newwrd2 = new string(char2);


            //ToLower allows to compare the words in same case, in this case, lower case.  
            //ToUpper will also do exact same thing in this context  
            if (newWrd1 == newwrd2)
            {
                Console.WriteLine(true + " " + "Words \"{0}\" and \"{1}\" are Anagrams", wordnum1, wordum2);
            }
            else
            {
                Console.WriteLine(false + " " + "Words \"{0}\" and \"{1}\" are not Anagrams", wordnum1, wordum2);
            }

            //Hold Console screen alive to view the results.  
            Console.ReadLine();
        }
    }
}
