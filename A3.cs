using System;
using System.Collections.Generic;

namespace COMP10066_Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */

    public class A3
    {
        ///<summary>
        ///  This method 'Avg' takes in a list, numList and a boolean parameter, incNeg in order to calculate  
        ///  the average of all of the list elements and uses logic to determine if negative elements will be included.
        ///  The method returns the average of the list.
        ///</summary>
        public static double Avg(List<double> numList, bool incNeg)
        {
            double listSum = Sum(numList, incNeg);  ///The method calls the Sum function by sending the list and boolean as parameters.  The new sum value gets set to the variable listSum.
            int counter = 0;    /// The variable counter is used as a counter to increment.
            for (int i = 0; i < numList.Count; i++)  /// The method uses a for loop to iterate over each item in the list.
            {
                if (incNeg || numList[i] >= 0)  ///  if statement to check if the elements of the list are negative
                {
                    counter++;  /// counter is increased by 1.
                }
            }
            if (counter == 0)  /// if statement to check if any values in the list are positive and giving a message to the user if there are no values greater than 0 in the list
            {
                throw new ArgumentException("no values are > 0");   ///  Print statement to communicate to the user if "no values are > 0".
            }
            return listSum / counter;   ///  Calculates the average of the list by dividing the list sum by the length of the list.
        }
        /// <summary>
        /// This method takes takes in a list, numList and a boolean parameter, incNeg.  The method calculates the sum of the items
        /// in the list numList and returns the sum.
        /// </summary>
        public static double Sum(List<double> numList, bool incNeg)  
        {
            if (numList.Count <= 0)  ///  If statement checking if the length of numList is less than 0.
            {
                throw new ArgumentException("numList cannot be empty"); /// Error handling that sends the message "numList cannot be empty".
            }

            double sum = 0.0;    /// Set the value of sum to 0.0.
            foreach (double val in numList)   /// foreach loop that checks each value in numList.
            {
                if (incNeg || val >= 0)   ///if statement to check if negative elements will be included in the sum.
                {
                    sum += val;  /// adds the val variable to sum.
                }
            }
            return sum;   /// returns sum.
        }
        /// <summary>
        ///  This function calculates the median value of the elements in numList.
        ///  The method returns the median value.
        /// </summary>
        public static double Median(List<double> data)   /// Method takes a list called data as a parameter. 
        {
            if (data.Count == 0)    /// if statement that checks the length of data.
            {
                throw new ArgumentException("Size of array must be greater than 0");  /// Error handling message "Size of array must be greater than 0".
            }

            data.Sort();  /// Calling the Sort() method on data.

            double median = data[data.Count / 2];   /// Finding the median value of the data list.
            if (data.Count % 2 == 0)  /// If statement using modulo to check if the list is even in length.
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;   /// If the list length is even then the median varaible is set to the average of the middle two elements.

            return median;  /// returns median.
        }
        /// <summary>
        ///   
        ///
        /// </summary>
        public static double SD(List<double> data)
        {
            if (data.Count <= 1)
            {
                throw new ArgumentException("Size of array must be greater than 1");
            }

            int dataLength = data.Count;   /// sets datalength to the length of data. 
            double standardError = 0;   /// sets standardError to 0.
            double average = Avg(data, true);   /// Sets the average variable to the average of the elements in data and includes negative elements.

            for (int i = 0; i < dataLength; i++)   ///  For loop to iterate over the length of the data list.
            {
                double value = data[i];   /// sets value to the element value.
                standardError += Math.Pow(value - average, 2);  /// adds the difference of the element value to the power of 2 to the standardError variable.
            }
            double stdev = Math.Sqrt(standardError / (dataLength - 1));   /// sets the stdev to the square root of the standardError divided by the dataLength minus 1.
            return stdev;    /// returns stdev.
        }

        // Simple set of tests that confirm that functions operate correctly
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 };
            
            ///<testing> Testing Different Methods </testing>
            List<Double> list1 = new List<double> {2.2, 3.4, 6.5, 10000.1, -90.4};
            Avg(list1, true);  /// callign the Avg() function.
            Sum(list1, false);  ///  calling the Sum() function by excluding negative element values.
            Sum(list1, true);   /// calling the Sum() function by including negative element values.
            Median(list1);    ///Calling the Median() method.
            SD(list1);     /// Calling the SD method.

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, true));   /// Print statement to test Sum()

            Console.WriteLine("The average of the array = {0}", Avg(testDataD, true));  ///Print statement to test Avg()

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD));   /// Print statement to test Median()

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testDataD));  /// Print statement to test SD.
        }
    }
}

