using ConsoleApp2;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security;
using System.Xml.Linq;

namespace Homework4
{
    public class Programm
    {
        public static void Main()
        {
            const string path = @"%AppData%\Lesson12Homework.txt";

            //1.Считывает путь к' файлу из % AppData %/Lesson12Homework.txt
            string pathToFile = string.Empty;
            try
            {
                pathToFile = File.ReadAllText(Environment.ExpandEnvironmentVariables(path));
                pathToFile = pathToFile.Trim();
                Console.WriteLine($"Путь успешно считан: {pathToFile}");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Был указан недопустимый путь");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Ваш файл не найден");
            }
            catch (SecurityException ex)
            {
                Console.WriteLine("Нет разрешения у файла");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //2.Открывает указанный файл .csv
            try
            {
                using FileStream fileStream = File.OpenRead(pathToFile);
                Console.WriteLine("Открыт файл");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Был указан недопустимый путь");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Нет разрешения у файла");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл по такому пути не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //3.Выводит в консоль список файлов, прочитанный из файла csv, отсортированный по дате изменения
            var listCsv = new List<Class1>();

            try
            {
                var csvData = File.ReadLines(pathToFile);
                foreach (var line in csvData)
                {
                    var newLine = line.Split("\t");
                    listCsv.Add(new Class1(newLine[0], newLine[1], Convert.ToDateTime(newLine[2])));
                    Console.WriteLine($"Данные считаны");
                }

                Console.WriteLine(); //разделила для симпатичности

                foreach (var element in listCsv.OrderBy(x => x.DateOfLastChange))
                {
                    Console.WriteLine($"{element.Name} - {element.Type} - {element.DateOfLastChange}");
                }

            }
            catch (SecurityException ex)
            {
                Console.WriteLine("Нет разрешения у файла");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл по такому пути не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //4.Удаляет файл % AppData %/ Lesson12Homework.txt
            try
            {
                File.Delete(pathToFile);
                Console.WriteLine("Файл удален");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Кажется, файл используется. Закройте его и запустите еще раз");
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine("Путь в недопустимом формате");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}