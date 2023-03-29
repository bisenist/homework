
using System;
using System.Numerics;

namespace Homework2
{
    public class Programm
    {
        public static void Main()
        {
            Console.WriteLine("Привет! Введи размер массива целым положительным числом");
            try //я знаю,  что не надо кидать сразу весь код сюда, но не смогла придумать, как сделать красиво без этого
            {
                int arraySize = ReadInt();
                if (arraySize < 1) //здесь я хотела дать второй шанс заполнить число правильно без окончания программы
                {
                    Console.WriteLine("Массив не может быть отрицательным или равным нулю, иначе мы не сможем продолжить. Попробуй еще раз! Если ошибешься, придется начать сначала");
                    arraySize = ReadInt();
                }
                int[] array = new int[arraySize];
                for (int i = 0;  i < arraySize; i++) //заполняем массив
                {
                    Console.WriteLine($"Введи значение {i+1} элемента"); 
                    array[i] = ReadInt();
                }
                int[] unique = array.Distinct().ToArray(); //делаю новый, убирая повторяющиеся значения
                Array.Sort(unique); //сортирую по возрастанию (не могу найти как сразу по убыванию сделать)
                Array.Reverse(unique); //переворачиваю в обратный порядок, чтобы первым был максимальным
                Console.WriteLine($"Второе наибольшее число: {unique[1]}"); //выдаю второй по величине элемент
            }
            // если юзер введет одинаковые элементы или сделает массив из 1 числа
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Кажется, в твоем массиве нет второго наибольшего элемента");
            }
            // ловлю сразу все ошибки. тоже знаю, что так делать не надо, но не могу понять какие еще не обработала
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            finally 
            {
                Console.WriteLine("Программа завершена");
             }
        }

        public static int ReadInt()
        {
            if (Int32.TryParse(Console.ReadLine(), out var value))
            {
                return value;
            }
            else
            {
                throw new Exception("К сожалению, это не число или не целое число. Попробуй еще раз сначала!");
            }
        }
    }
}
