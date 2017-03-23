using System;
namespace FloatingPointAddition
{
    /// <summary>
    /// Class providing procedures for addition of two floating point numbers
    /// </summary>
    class AdditionOfFloat
    {
        int StringLength(string input)
        {
            int count = 0;
            foreach(char ch in input)
            {
                count++;
            }
            return count;
        }
        /// <summary>
        /// returns binary format of  given real number 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string BinaryConversion(string str)
        {
            string[] input = (str.Split('.'));
            string IntegerPart = input[0];
            string DecimalPart = string.Empty;
            string binaryForm = string.Empty;
            float intValue = Convert.ToSingle(IntegerPart);
            float decimalvalue = 0F;

            if (input.Length > 1)
            {
                DecimalPart = "." + input[1];
                decimalvalue = Convert.ToSingle(DecimalPart);
            }

            while (intValue >= 1)
            {
                binaryForm = ((long)((intValue / 1) % 2)) + binaryForm;

                intValue = intValue / 2;
            }

            binaryForm = binaryForm + ".";

            while (decimalvalue > 0.0)
            {
                binaryForm = binaryForm + (int)((decimalvalue * 2));
                decimalvalue = (decimalvalue * 2) % 1;
            }

            return binaryForm;
        }
        /// <summary>
        /// converts float number into IeeeFormat and returns it
        /// </summary>
        /// <param name="str"></param>
        string IeeeFormat(string str)
        {
            string binaryForm = BinaryConversion(str);
            int count = 0;
            int positionOfOne = -1;
            int positionOfDot = 0;
            int power = 0;
            for (int iterator = 0; iterator < StringLength(binaryForm); iterator++)
            {
                if (count < 1 && (SubString(binaryForm, iterator, 1).Equals("1")))
                {
                    positionOfOne = iterator;
                    count++;
                }
                else if (SubString(binaryForm, iterator, 1).Equals("."))
                {
                    positionOfDot = iterator;
                }
                if (count > 1)
                {
                    break;
                }
            }

            if ((positionOfDot - positionOfOne) > 0)
            {
                power = 127 + (positionOfDot - positionOfOne) - 1;
            }
            else
            {
                power = 127 + (positionOfDot - positionOfOne);
            }
            if (positionOfOne == -1)
            {
                power = 0;
            }
        
            int iterator1 = 8;

            char[] ieeeValue = new char[32];
            for (int iterator2 = 0; iterator2 < 32; iterator2++)
            {
                ieeeValue[iterator2] = (char)48;
            }
            while (power > 0)
            {
                ieeeValue[iterator1--] = (char)(48 + power % 2);
                power = power / 2;
            }
            iterator1 = 9;
            for (int iterator2 = positionOfOne + 1; iterator2 < StringLength(binaryForm) && iterator1 < 32; iterator2++)
            {
                if (!(binaryForm[iterator2].Equals('.')))
                    ieeeValue[iterator1++] = binaryForm[iterator2];
            }

            return new string(ieeeValue);
        }
        /// <summary>
        ///     Returns the given string with the additional padding characters
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numOfChars"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        string PadAtLeft(string value, int numOfChars, char ch)
        {
            for (int iterator = 0; iterator < numOfChars; iterator++)
            {
                value = "0" + value;
            }
            return value;
        }
        /// <summary>
        ///    Returns the given string with the additional padding characters
        /// </summary>
        /// <param name="str"></param>
        /// <param name="numOfChars"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        string PadAtRight(string value, int numOfChars, char ch)
        {
            for (int iterator = 0; iterator < numOfChars; iterator++)
            {
                value = value + "0";
            }
            return value;
        }

        /// <summary>
        ///    Returns a specified number raised to the power of specified power 
        /// </summary>
        /// <param name="radix"></param>
        /// <param name="_Exponent"></param>
        /// <returns></returns>
        float Power(int radix, int exponent)
        {
            float result = 1f;

            for (int iterator = exponent; iterator > 0; iterator--)
            {
                result *= 2;
            }
            return result;
        }

        /// <summary>
        /// Retrieves a substring from the specified string. The substring starts at a specified character position.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        string SubString(string mainString, int startIndex)
        {
            string subString = string.Empty;

            for (int iterator = startIndex; iterator < StringLength(mainString); iterator++)
            {
                subString = subString + mainString[startIndex++];
            }
            return subString;
        }
        /// <summary>
        /// Retrieves a substring from the specified string. The substring starts at a specified character position and has a specified width.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        string SubString(string mainString, int startIndex, int width)
        {
            string subString = string.Empty;

            for (int iterator = 0; iterator < width; iterator++)
            {
                subString = subString + mainString[startIndex++];
            }
            return subString;
        }
        /// <summary>
        /// converts the given binary value to floating point number and returns it.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        float BinaryToFloat(string input)
        {
            string[] array = input.Split('.');
            string IntegerPart = array[0];
            float result = 0;
            
            for (int iterator = StringLength(array[0]) - 1; iterator >= 0; iterator--)
            {

                result += (IntegerPart[iterator] - '0') * (Power(2, (StringLength(array[0]) - 1 - iterator)));
            }

            if (array.Length > 1)
            {
                string DecimalPart = array[1];
                for (int iterator = 0; iterator < StringLength(array[1]); iterator++)
                {
                    result += (DecimalPart[iterator] - '0') / (Power(2, (iterator + 1)));
                }
            }
            return result;
        }

        /// <summary>
        /// returns addition of given two numbers
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
      public  double Addition(string input1, string input2)
        {            
            string ieeeValue1 = IeeeFormat(input1);
            string ieeeValue2 = IeeeFormat(input2);
            Console.WriteLine();
            int max_Exponent = (int) BinaryToFloat(SubString(ieeeValue1,1,8));
            int min_Exponent = (int)BinaryToFloat(SubString(ieeeValue2, 1, 8));            
            bool swapped = false;

            if (max_Exponent < min_Exponent)
            {
                int temp = max_Exponent;
                max_Exponent = min_Exponent;
                min_Exponent = temp;
                swapped = true;
            }

            int exp = max_Exponent - 127;
            int ShiftValue = max_Exponent - min_Exponent;

            string mantissa1 = SubString(ieeeValue1, 9);
            string mantissa2 = SubString(ieeeValue2, 9);
            if (swapped)
            {
                string tempString = mantissa1;
                mantissa1 = mantissa2;
                mantissa2 = tempString;
            }
            if (max_Exponent != 0)
            {
                mantissa1 = "1" + mantissa1;
            }
            else
            {
                mantissa1 = "0" + mantissa1;
            }
            if (min_Exponent != 0)
            {
                mantissa2 = "1" + mantissa2;
            }
            else
            {
                mantissa2 = "0" + mantissa2;
            }

            mantissa1 = PadAtRight(mantissa1, ShiftValue, '0');
            mantissa2 = PadAtLeft(mantissa2, ShiftValue, '0');
            char[] sum = new char[25 + ShiftValue];
            char carry = '0';

            for (int iterator = StringLength(mantissa1); iterator > 0; iterator--)
            {
                sum[iterator] = (char)(48 + ((mantissa1[iterator - 1] - '0') + (mantissa2[iterator - 1] - '0') + (carry - '0')) % 2);
                carry = (char)(48 + ((mantissa1[iterator - 1] - '0') + (mantissa2[iterator - 1] - '0') + (carry - '0')) / 2);
            }
            sum[0] = (char)(48 + ((carry - '0') + (0)) % 2);
            string answer = new string(sum);

            if (exp < 0)
            {
                answer = PadAtLeft(answer, Math.Abs(exp) - 1, '0');
                answer = "0." + SubString(answer, 1);
            }
            else
            {
                answer = SubString(answer, 0, 2 + exp) + "." + SubString(answer, 2 + exp);
            }

            return BinaryToFloat(answer);
        }
      
    }
}
