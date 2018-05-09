using System;
using System.Collections.Generic;

namespace ReversePolishCalculator
{
    /*
     * This class calculates an expression given in reverse Polish notation.
     * By: James B Fairbourn Jr.
     */
    class ReversePolishCalculator
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an expression in reverse Polish notation: ");
            string input = Console.ReadLine();
            string[] values = input.Split(' ');         //split user input by space delimiter
            Calculate(values);                          //calculate the expression provided by user
        }
        /// <summary>
        /// This method calculates values in reverse Polish notation.
        /// </summary>
        /// <param name="values">String array of operators and operands</param>
        public static void Calculate(string[] values)
        {
            Stack<double> valueStack = new Stack<double>(); 
            foreach (string value in values)            //iterate through each string in the array, and perform function for each operator.  
            {                                           //Operands are added to the stack.
                double leftOperand, rightOperand;
                switch (value)
                {
                    case "+":                           //add
                        rightOperand = valueStack.Pop();
                        leftOperand = valueStack.Pop();
                        valueStack.Push(leftOperand + rightOperand);
                        break;
                    case "-":                          //subtract
                        rightOperand = valueStack.Pop();
                        leftOperand = valueStack.Pop();
                        valueStack.Push(leftOperand - rightOperand);
                        break;
                    case "*":                          //multiply
                    case "x":
                    case "X":                           
                        rightOperand = valueStack.Pop();
                        leftOperand = valueStack.Pop();
                        valueStack.Push(leftOperand * rightOperand);
                        break;
                    case "/":                          //divide
                        rightOperand = valueStack.Pop();
                        if(rightOperand == 0)
                        {
                            Console.WriteLine("Unable to divide by 0.  Please try again.");
                            Console.Read();
                            return;
                        }
                        leftOperand = valueStack.Pop();
                        valueStack.Push(leftOperand / rightOperand);
                        break;
                    default:                          //value does not match any operator, try parsing integer value and adding to stack.
                        if (int.TryParse(value.ToString(), out int intValue))
                        {
                            valueStack.Push(intValue);
                        }
                        else
                        {
                            Console.WriteLine("'" + value + "'" + " is not a valid value.  Please try again.");
                            Console.Read();
                            return;
                        }
                        break;
                }
            }
            if(valueStack.Count > 1)
            {
                Console.WriteLine("The expression entered is not in reverse Polish notation.  Please try again.");
                Console.Read();
                return;
            }
            else
            {
                Console.WriteLine("Output: " + valueStack.Pop());       //display output
                Console.Read();
            }
                
        }
    }
}
