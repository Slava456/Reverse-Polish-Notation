using System;
using System.Collections.Generic;

namespace RPNLib
{
    public class RPNCountClass
    {
        public string _input;
        public RPNCountClass(string input)
        {
            _input = input;
        }
        
        private byte GetPriority(char s)
        {
            switch (s)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 4;
                case '^': return 5;
                default: return 6;
            }
        }

        public bool isDelimeter(char c)
        {
            return " =".IndexOf(c) != -1;
        }

        public bool isOpenBreaker(char c)
        {
            return GetPriority(c) == 0;
        }

        public bool isClosedBreaker(char c)
        {
            return GetPriority(c) == 1;
        }

        public bool isOperator(char c)
        {
            return "+-/*^".IndexOf(c) != -1;
        }

        public double Calculate()
        {
            return Counting(GetExpression(Correct()));
        }

        private string Correct()
        {
            string normal = string.Empty;
            for (int i = 0; i < _input.Length; i++)
            {
                if (i == 0)
                {
                    normal += _input[i];
                }
                else if (_input[i] == '.')
                {
                    normal += ',';
                }
                else
                {
                    char c = _input[i - 1];
                    if (isOpenBreaker(_input[i]) && !isOperator(c))
                    {
                        normal += '*';
                        normal += _input[i];
                    }
                    else if (i != _input.Length - 1)
                    {
                        c = _input[i + 1];
                        normal += _input[i];
                        if (isClosedBreaker(_input[i]) && !isOperator(c))
                        {
                            normal += '*';
                        }
                    }
                    else
                    {
                        normal += _input[i];
                    }
                }
            }
            return normal;
        }

        private string GetExpression(string input)
        {
            string output = string.Empty; //Строка для хранения выражения
            Stack<char> operStack = new Stack<char>(); //Стек для хранения операторов

            for (int i = 0; i < input.Length; i++) //Для каждого символа в входной строке
            {
                //Разделители пропускаем
                if (isDelimeter(input[i]))
                {
                    continue; //Переходим к следующему символу
                }
                //Если символ - цифра, то считываем все число
                if (char.IsDigit(input[i])) //Если цифра
                {
                    //Читаем до разделителя или оператора, что бы получить число
                    while (!isDelimeter(input[i]) && !isOperator(input[i]) 
                           && !isOpenBreaker(input[i]) && !isClosedBreaker(input[i]))
                    {
                        output += input[i]; //Добавляем каждую цифру числа к нашей строке
                        i++; //Переходим к следующему символу

                        if (i == input.Length)
                        {
                            break; //Если символ - последний, то выходим из цикла
                        }
                    }

                    output += " "; //Дописываем после числа пробел в строку с выражением
                    i--; //Возвращаемся на один символ назад, к символу перед разделителем
                }
                //Если символ - оператор
                if (isOperator(input[i]) || isOpenBreaker(input[i]) || isClosedBreaker(input[i])) //Если оператор
                {
                    if (isOpenBreaker(input[i])) 
                    {
                        operStack.Push(input[i]); //Записываем её в стек
                    }
                    else if (isClosedBreaker(input[i])) 
                    {
                        //Выписываем все операторы до открывающей скобки в строку
                        char s = operStack.Pop();
                        while (!isOpenBreaker(s))
                        {
                            output += s.ToString() + ' ';
                            s = operStack.Pop();
                        }
                    }
                    else //Если любой другой оператор
                    {
                        if (operStack.Count > 0) //Если в стеке есть элементы
                        {
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) //И если приоритет нашего оператора меньше или равен приоритету оператора на вершине стека
                            {
                                output += operStack.Pop().ToString() + " "; //То добавляем последний оператор из стека в строку с выражением
                            }
                        }
                        operStack.Push(char.Parse(input[i].ToString())); //Если стек пуст, или же приоритет оператора выше - добавляем операторов на вершину стека
                    }
                }
            }
            //Когда прошли по всем символам, выкидываем из стека все оставшиеся там операторы в строку
            while (operStack.Count > 0)
            {
                output += operStack.Pop() + " ";
            }
            return output; //Возвращаем выражение в постфиксной записи
        }

        private double Counting(string input)
        {
            double result = 0; //Результат
            Stack<double> temp = new Stack<double>(); //Временный стек для решения

            for (int i = 0; i < input.Length; i++) //Для каждого символа в строке
            {
                //Если символ - цифра, то читаем все число и записываем на вершину стека
                if (char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!isDelimeter(input[i]) && !isOperator(input[i]) 
                           && !isOpenBreaker(input[i]) && !isClosedBreaker(input[i])) //Пока не разделитель
                    {
                        a += input[i]; //Добавляем
                        i++;
                        if (i == input.Length)
                        {
                            break;
                        }
                    }
                    temp.Push(double.Parse(a)); //Записываем в стек
                    i--;
                }
                else if (isOperator(input[i]) || isOpenBreaker(input[i]) || isClosedBreaker(input[i])) //Если символ - оператор
                {
                    //Берем два последних значения из стека
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i]) //И производим над ними действие, согласно оператору
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                        case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                    }
                    temp.Push(result); //Результат вычисления записываем обратно в стек
                }
            }
            return temp.Peek(); //Забираем результат всех вычислений из стека и возвращаем его
        }
    }
}
