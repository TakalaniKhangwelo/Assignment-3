using System;

public class ExtendedNumberToWordsConverter
{
    // Array of words for numbers 0-19
    private static readonly string[] Units =
    {
        "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
        "Seventeen", "Eighteen", "Nineteen"
    };

    // Array of words for multiples of ten from 20 to 90
    private static readonly string[] Tens =
    {
        "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
    };

    // Main method to convert a number to words
    public static string Convert(int number)
    {
        // Check if the number is in the valid range (0 to 9999)
        if (number < 0 || number > 9999)
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 0 and 9999");

        // Special case for zero
        if (number == 0) return "Zero";

        // Call the method to convert the number and trim any extra spaces
        return ConvertToWords(number).Trim();
    }

    // Helper method to convert numbers to words
    private static string ConvertToWords(int number)
    {
        // Initialize an empty string to hold the words
        string words = "";

        // Handle thousands
        if (number >= 1000)
        {
            words += Units[number / 1000] + " Thousand "; // Get the word for the thousands place
            number %= 1000; // Reduce the number to the remainder
        }

        // Handle hundreds
        if (number >= 100)
        {
            words += Units[number / 100] + " Hundred "; // Get the word for the hundreds place
            number %= 100; // Reduce the number to the remainder
        }

        // Handle tens (20 and above)
        if (number >= 20)
        {
            words += Tens[number / 10] + " "; // Get the word for the tens place
            number %= 10; // Reduce the number to the remainder
        }

        // Handle units (1 to 9)
        if (number > 0)
        {
            words += Units[number] + " "; // Get the word for the units place
        }

        return words; // Return the constructed string of words
    }

    // Main method to run the program
    public static void Main()
    {
        // Prompt user for input
        Console.Write("\nEnter a number (0 to 9999): ");
        if (int.TryParse(Console.ReadLine(), out int number)) // Attempt to parse the input
        {
            // Convert the number to words
            string words = Convert(number);
            Console.WriteLine($"{number} in words : {words}");

            // Provide feedback based on the number's size
            if (number >= 100)
            {
                Console.WriteLine($"This number has hundreds.");
            }
            else if (number >= 10)
            {
                Console.WriteLine($"This number has tens.");
            }
            else
            {
                Console.WriteLine($"This number is a unit.");
            }
        }
        else
        {
            // Handle invalid input
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}
