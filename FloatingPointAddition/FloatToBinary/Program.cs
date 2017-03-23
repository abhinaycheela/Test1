using System;

namespace FloatingPointAddition
{
    class Program
    {
        static void Main(tring[] args)
        {
            Console.WriteLine("Enter number1 :");
            string input1 = Console.ReadLine();
            Console.WriteLine("Enter numer2:");
            string input2 = Console.ReadLine();
            double answer;
            AdditionOfFloat additionObject = new AdditionOfFloat();

            try { 
               answer = additionObject.Addition(input1, input2);
            }
            catch
            {
                Console.WriteLine("enter correct format of a floating point number");
                return ;
            }

            Console.Write("Addition of given numbers is : "+(float)answer);
            Console.WriteLine();          
       }
    }
}
