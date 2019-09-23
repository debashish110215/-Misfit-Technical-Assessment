using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.Helper
{
    public class Calculation
    {
        public static string CalculateSumWithoutDec(string num1, string num2)
        {
            num1 = num1.Replace("-", "");
            num2 = num2.Replace("-", "");
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
            bool negativeSign = num1.Contains("-") || num2.Contains("-");
            

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
            // var num3 = Get10sComplement(num2);
            // bool hasCarry = false;
            if (negativeSign)
                sum = Subtract(num1, num2);
            else
                sum += CalculateSumWithoutDec(num1, num2);

            // if (hasCarry)
            //     sum = "-" + sum.Remove(0, 1);
            // else
            //     sum = Get10sComplement(sum);
            if(String.IsNullOrEmpty(sum))
                sum = "0";
            else if (dotPoint > 0)
                sum = sum.Insert(sum.Length - dotPoint, ".");

            return sum;
        }
        public static string Subtract(string orgx1, string orgx2)
        {
            string x1 = orgx1, x2 = orgx2;
            string result = "";

            if (x1.Contains("-") && x2.Length < x1.Length - 1)
            {
                result += "-";
            }
            else if (x2.Contains("-") && x1.Length < x2.Length - 1)
            {
                result += "-";
                (x1, x2) = interchange(x1, x2);
            }
            else
            {
                x1 = x1.Replace("-", "");
                x2 = x2.Replace("-", "");

                //if (x1.Length < x2.Length)
                //    (x1, x2) = interchange(x1, x2);
                //else if (x1.Length > x2.Length) {
                //    result += "-";
                //}
                //else
                if (orgx1.Contains("-"))
                {
                    if (x1.Length >= x2.Length)
                    {
                        for (int i = 0; i < x2.Length; i++)
                        {
                            if (x1[i] > x2[i])
                            {
                                result += "-";
                                break;
                            }
                            else if (x2[i] > x1[i])
                            {
                                (x1, x2) = interchange(x1, x2);
                                break;
                            }
                            continue;

                        }
                    }
                    else
                    {
                        result += "-";
                        (x1, x2) = interchange(x1, x2);
                    }
                }
                else if (orgx2.Contains("-"))
                {
                    if (x2.Length >= x1.Length)
                    {
                        for (int i = 0; i < x1.Length; i++)
                        {
                            if (x2[i] > x1[i])
                            {
                                result += "-";
                                (x1, x2) = interchange(x1, x2);
                                break;
                            }
                            else if (x1[i] > x2[i])
                                break;

                            continue;

                        }
                    }
                    //else {
                    //    result += "-";
                    //}
                }
            }
            x1 = x1.Replace("-", "");
            x2 = x2.Replace("-", "");


            int n1 = x1.Length, n2 = x2.Length;

            char[] ch = x1.ToCharArray();
            Array.Reverse(ch);
            x1 = new string(ch);
            char[] ch1 = x2.ToCharArray();
            Array.Reverse(ch1);
            x2 = new string(ch1);
            string str = "";
            int carry = 0;
            for (int i = 0; i < n2; i++)
            {
                if ((int)x1[i]-'0' < ((int)(x2[i]-'0'))+ carry)
                {
                    str += (10 + (int)(x1[i] - '0')) - (((int)(x2[i] - '0')) + carry);
                    carry = 1;
                }
                else
                {
                    str += (int)(x1[i] - '0') - (((int)(x2[i] - '0')) + carry);
                    carry = 0;
                }
            }
            for (int i = n2; i < n1; i++)
            {
                if (x1[i].Equals('0'))
                {
                    str += (10 + ((int)(x1[i] - '0'))) - carry;
                    carry = 1;
                }
                else
                {
                    str += ((int)(x1[i] - '0')) - carry;
                    carry = 0;
                }
            }
            char[] ch2 = str.ToCharArray();
            Array.Reverse(ch2);
            str = new string(ch2);


            return result + str.TrimStart('0');
        }

        public static (string, string) interchange(string x1, string x2)
        {
            string t = x1;
            x1 = x2;
            x2 = t;

            return (x1, x2);
        }
        //public static (string,bool) Subtarct(string num1, string num2)
        //{
        //    string str = "";
        //    bool hasCarry = false;
        //    str = CalculateSumWithoutDec(num1, num2);

        //    hasCarry = str.Length > num1.Length && str.Length > num2.Length;
        //    return (str,hasCarry);
        //}


        //static string Add(string s1, string s2)
        //{
        //    bool carry = false;
        //    string result = string.Empty;
        //    if (s1[0] != '-' && s2[0] != '-')
        //    {
        //        if (s1.Length < s2.Length)
        //            s1 = s1.PadLeft(s2.Length, '0');
        //        if (s2.Length < s1.Length)
        //            s2 = s2.PadLeft(s1.Length, '0');

        //        for (int i = s1.Length - 1; i >= 0; i--)
        //        {
        //            var augend = Convert.ToInt64(s1.Substring(i, 1));
        //            var addend = Convert.ToInt64(s2.Substring(i, 1));
        //            var sum = augend + addend;
        //            sum += (carry ? 1 : 0);
        //            carry = false;
        //            if (sum > 9)
        //            {
        //                carry = true;
        //                sum -= 10;
        //            }
        //            result = sum.ToString() + result;
        //        }
        //        if (carry)
        //        {
        //            result = "1" + result;
        //        }
        //    }

        //    else if (s1[0] == '-' || s2[0] == '-')
        //    {
        //        long sum = 0;
        //        if (s2[0] == '-')
        //        {
        //            //Removing negative sign
        //            char[] MyChar = { '-' };
        //            string NewString = s2.TrimStart(MyChar);
        //            s2 = NewString;

        //            if (s2.Length < s1.Length)
        //                s2 = s2.PadLeft(s1.Length, '0');

        //            for (int i = s1.Length - 1; i >= 0; i--)
        //            {
        //                var augend = Convert.ToInt64(s1.Substring(i, 1));
        //                var addend = Convert.ToInt64(s2.Substring(i, 1));
        //                if (augend >= addend)
        //                {
        //                    sum = augend - addend;
        //                }
        //                else
        //                {
        //                    int temp = i - 1;
        //                    long numberNext = Convert.ToInt64(s1.Substring(temp, 1));
        //                    //if number before is 0
        //                    while (numberNext == 0)
        //                    {
        //                        temp--;
        //                        numberNext = Convert.ToInt64(s1.Substring(temp, 1));
        //                    }
        //                    //taking one from the neighbor number
        //                    int a = int.Parse(s1[temp].ToString());
        //                    a--;
        //                    StringBuilder tempString = new StringBuilder(s1);
        //                    string aString = a.ToString();
        //                    tempString[temp] = Convert.ToChar(aString);
        //                    s1 = tempString.ToString();
        //                    while (temp < i)
        //                    {
        //                        temp++;
        //                        StringBuilder copyS1 = new StringBuilder(s1);
        //                        string nine = "9";
        //                        tempString[temp] = Convert.ToChar(nine);
        //                        s1 = tempString.ToString();
        //                    }
        //                    augend += 10;
        //                    sum = augend - addend;
        //                }
        //                result = sum.ToString() + result;
        //            }
        //            //Removing the zero infront of the answer
        //            char[] zeroChar = { '0' };
        //            string tempResult = result.TrimStart(zeroChar);
        //            result = tempResult;
        //        }
        //    }

        //    return result;
        //}


        //static string Get10sComplement(string num)
        //{
        //    if (num.Contains("-"))
        //        num.Replace("-", "");
        //    string tensComplement = "";

        //    for (int i= 0;i < num.Length;i++)
        //    {
        //        tensComplement += 10 - (int)(num[i]-'0');
        //    }

        //    return tensComplement;
        //}
    }
}
