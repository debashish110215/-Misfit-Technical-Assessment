using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.Helper
{
    public class Calculation
    {
        public static string CalculateSumWithoutDec(string num1, string num2)
        {
            // Before proceeding further, make sure length  
            // of num2 is larger.  
            if (num1.Length > num2.Length)
            {
                string t = num1;
                num1 = num2;
                num2 = t;
            }

            // Take an empty string for storing result  
            string str = "";

            // Calculate length of both string  
            int n1 = num1.Length, n2 = num2.Length;

            // Reverse both of strings 
            char[] ch = num1.ToCharArray();
            Array.Reverse(ch);
            num1 = new string(ch);
            char[] ch1 = num2.ToCharArray();
            Array.Reverse(ch1);
            num2 = new string(ch1);

            int carry = 0;
            for (int i = 0; i < n1; i++)
            {
                // Do school mathematics, compute sum of  
                // current digits and carry  
                int sum = ((int)(num1[i] - '0') +
                        (int)(num2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');

                // Calculate carry for next step  
                carry = sum / 10;
            }

            // Add remaining digits of larger number  
            for (int i = n1; i < n2; i++)
            {
                int sum = ((int)(num2[i] - '0') + carry);
                str += (char)(sum % 10 + '0');
                carry = sum / 10;
            }

            // Add remaining carry  
            if (carry > 0)
                str += (char)(carry + '0');

            // reverse resultant string 
            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            str = new string(ch2);

            return str;
        }

        public static string CalculateSum(string num1, string num2)
        {
            if (String.IsNullOrWhiteSpace(num1) || String.IsNullOrWhiteSpace(num2))
                return String.Empty;

            var sum = "";
            if (num1.Contains("-") && num2.Contains("-"))
                sum += "-";

            num1 = num1.Replace("+", "");
            num2 = num2.Replace("+", "");
            bool negativeSign = false;
            if (num1.Contains("-") || num2.Contains("-"))
            {
                negativeSign = true;
                num1 = num1.Replace("-", "");
                num2 = num2.Replace("-", "");
            }

            string[] num1DecPoints = num1.Split('.');
            string[] num2DecPoints = num2.Split('.');
            string num1DecDigits = num1DecPoints.Length > 1 ? num1DecPoints[1] : String.Empty;
            string num2DecDigits = num2DecPoints.Length > 1 ? num2DecPoints[1] : String.Empty;
            var dotPoint = num1DecDigits.Length > num2DecDigits.Length? num1DecDigits.Length:num2DecDigits.Length;

            if (num1DecDigits.Length > num2DecDigits.Length)
            {
                for (int i = num2DecDigits.Length; i < num1DecDigits.Length; i++)
                    num2DecDigits += "0";
            }
            else
            {
                for (int i = num1DecDigits.Length; i < num2DecDigits.Length; i++)
                    num1DecDigits += "0";
            }

            num1 = num1DecPoints[0] + num1DecDigits;
            num2 = num2DecPoints[0] + num2DecDigits;

           if(negativeSign)
                sum = Subtarct(num1, num2);
           else
               sum = CalculateSumWithoutDec(num1, num2);

            if (dotPoint > 0)
                sum = sum.Insert(sum.Length - dotPoint, ".");
            
            return sum;
        }

        public static string Subtarct(string num1, string num2)
        {
            string str = "";
            string workingNum1 = num1.Replace("-","");
            string workingNum2 = num2.Replace("-", "");
            if (workingNum1.Length < workingNum2.Length)
            {
                string t = workingNum2;
                workingNum2 = workingNum1;
                workingNum1 = t;
            }

            int n1 = workingNum1.Length, n2 = workingNum2.Length;

            // Reverse both of strings 
            char[] ch1 = workingNum1.ToCharArray();
            Array.Reverse(ch1);
            workingNum1 = new string(ch1);
            char[] ch2 = workingNum2.ToCharArray();
            Array.Reverse(ch2);
            workingNum2 = new string(ch2);

            int carry = 0;

            for (int i = 0; i < n2; i++)
            {
                int result = 0;
                if (workingNum2[i] > workingNum1[i])
                {
                    result = 10 + (int)(((int)workingNum1[i]) - ((int)workingNum2[i]) + carry);
                    str += (char)(result % 10 + '0');
                    carry = 1;
                }
                   
                else
                {
                    result = (int)(((int)workingNum1[i]) - ((int)workingNum2[i]) + carry);
                    str += (char)(result % 10 + '0');
                    carry = 0;
                }
                    

               // carry = result / 10;
            }

            for (int i = n2; i < n1; i++)
            {
                int result = 0;
                if (workingNum1[i] == 0)
                {
                    result = 10 + ((int)workingNum1[i])-'0' - carry;
                    str += (char)(result % 10 + '0');
                    carry = 1;
                }
                else
                {
                    result = ((int)workingNum1[i]) - '0' - carry;
                    str += (char)(result % 10 + '0');
                    carry = 0;
                }
                    

                //carry = result / 10;
            }
            char[] ch3 = str.ToCharArray();
            Array.Reverse(ch3);
            str = new string(ch3);

            if (carry > 0 )
                return "-" + str;

            return str;
        }
    }
}
