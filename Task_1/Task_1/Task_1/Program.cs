﻿using System;
using Task_1.Exceptions;

/*Задание 1.

Пользователь вводит с клавиатуры любую строку.В конце строки должно быть число, отделённой от предыдущих символов одним или несколькими пробелами (эти пробелы потом игнорируются).

1-Если в конце строки не было числа - вывести сообщение "Number parameter is missing"

2-Если было введено только число - вывести сообщение "String parameter is missing"

3-Если число не положительные - вывести сообщение "Can not work with negative nubmers or zero"

4-Если число от 0 до 5 - вывести строку из параметра 1 столько раз, сколько указано в числе.Если число не целое - последним вывести округлённое количество символов.Например, ввели строку abcdefghyj, и число 0.2 - вывести ab.

5-Если число больше 5 - вывести "Requested string [введённая строка] was repeadet [введёное число, округлённое до сотых]".

6-Если число равно 13 - вывести "Illuminati confirmed at [Текущее дата и время в США, штат Вашингтон]"

7-Если число равно 777 - пробросить кастомный JackpotException, обработать Exception в том же классе и вывести "Jackpot!".

8-Если число равно 888 - пробросить кастомный ImmortalityException, обработать Exception в том же классе, вывести "Immportality" и пробросить этот же Exception дальше.
Обработать ImmortalityException в Program.cs и вывести "Immortality is impossible".
*/

namespace Task_1
{
    class Program
    {

        static void Main(string[] args)
        {
            var checker = new InputChecker();
            int i = 10;

            while (i-- > 0)

                try
                {
                    var line = Console.ReadLine();

                    StringWithNumber obj = checker.Check(line);

                    Console.WriteLine(obj.Result());

                }
                catch (ImmortalityException ex)
                {
                    Console.WriteLine("immortality is impossible");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

        }
    }
}
