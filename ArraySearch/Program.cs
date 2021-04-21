using System;

namespace ArraySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 2, 8, 0, 24, 51 };
            int selection = 0;
            int entry;
            bool checker = false;
            Console.Write("1- Search value by index\n2- Search index by value\n");
            while (!checker)
            {
                selection = NumberEntry("Entry: ", "Invalid entry.");
                checker = Limitation(selection, 1, 2, "Please choose 1 or 2");
            }
            checker = false;

            if (selection == 1)
            {
                while (!checker)
                {
                    entry = NumberEntry("Enter an index of the array: ", "Invalid entry.");
                    checker = Limitation(entry, 0, array.Length - 1, "That is not a valid index.");
                    if (checker)
                    {
                        Console.WriteLine($"The value at index {entry} is {array[entry]}");
                        checker = !ContinueEntry();
                    }
                }
            }
            else
            {
                while (!checker)
                {
                    entry = NumberEntry("Enter a number: ", "That value cannot be found in the array");
                    checker = Limitation(entry, array, "That value cannot be found in the array");
                    if (checker)
                    {
                        Console.WriteLine($"The value {entry} can be found at index {Array.IndexOf(array,entry)}.");
                        checker = !ContinueEntry();
                    }
                }
            }
            Console.WriteLine("Goodbye!");

        }

        public static bool Limitation(int entry, int lower, int upper, string error)
        {
                if (entry >= lower && entry <= upper)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine(error);
                    return false;
                }
            
        } //end Limitation

        public static bool Limitation(int entry, int [] array, string error)
        {
            for (int index = 0; index < array.Length; index++)
                {
                    if (entry == array[index])
                    {
                        //Console.WriteLine($"The value {array[index]} can be found at index {index}.");
                        return true;
                    }
                }
                Console.WriteLine(error);
                return false;
        } //end Limitation

        static bool ContinueEntry()
        {
            string text;
            while (true)
            {
                Console.Write("Would you like to continue? (Y/N)?: ");
                text = Console.ReadLine().Trim().ToLower();

                switch (text)
                {
                    case "y":
                    case "yes":
                        return true;

                    case "n":
                    case "no":
                        return false;

                    default:
                        Console.WriteLine("Invalid Entry.");
                        break;
                }
            }
        } //end ContinueEntry

        public static int NumberEntry(string phrase, string error)
        {
            string text;
            int number;
            while (true)
            {
                Console.Write(phrase);
                text = Console.ReadLine().Trim().ToLower();
                if (int.TryParse(text, out number))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine(error);
                }
            }
        } //end NumberEntry
    }
}
