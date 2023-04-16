
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace Homework4
{

    public class Programm
    {
        public static async Task Main()
        {
            const string nameArchive = "arhive.zip";
            const string directory = "archive";
            const string path = @"%AppData%\Lesson12Homework.txt";
            const string nameFile = "Help.csv";

            //Распаковывает архив в папку рядом с запускаемым файлом программы
            try
            {
                ZipFile.ExtractToDirectory(sourceArchiveFileName: nameArchive, destinationDirectoryName: directory);
                Console.WriteLine("Архив распакован");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Кажется, название архива указано неправильно");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Не удалось открыть архив или он уже создан");
            }
            catch (Exception ex) //извините, я пока не очень шарю в исключениях, так что буду ловить все....
            {
                Console.WriteLine(ex.Message);
            }
            
            //Считывает названия файлов и папок из указанной папки
            try
            {
                string[] contentsDir = Directory.GetDirectories(directory);
                foreach (string dir in contentsDir)
                {
                    Console.WriteLine($"{dir}");
                }
                string[] contentsFile = Directory.GetFiles(directory);
                foreach(string file in contentsFile)
                {
                    Console.WriteLine($"{file}");
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Нет разрешения у вызванного объекта");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Файл поврежден");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Строка пути пустая или содержит недопустимые символы");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            //Записывает информацию о содержимом папки (тип (файл/папка), название, дата изменения)
            //в текстовый файл в формате .csv (разделитель – \t (знак табуляции) )
            await FileInfo(nameFile, directory); 

            //Удаляет папку с распакованным архивом
            try
            {
                Directory.Delete(directory,true); //нагуглила, что true помогает удалить файлы в папке тоже
                Console.WriteLine("Папка удалена");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Указан недопустимый путь");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Пусть пустой или содержит недопустимые символы");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Файл в этой папке сейчас используется, закройте его и попробуйте еще раз");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Сохраняет путь к файлу csv в файле %AppData%/Lesson12Homework.txt
            await FileWriter(path, nameFile);
        }

        public static async Task FileInfo (string path, string directory)
        {
            //я старалась сделать через DirectoryInfo, как вы говорили, но самостоятельно не разобралась, как он работает, выдавал ошибку в коде (требуется ссылка на объект)
            try
            {
                await using StreamWriter helpp = new StreamWriter(path);
                string[] dirList = Directory.GetDirectories(directory);
                for (int i = 0; i < dirList.Length; i++)
                {
                    dirList[i] += "\tdirectory\t" + Directory.GetLastWriteTime(dirList[i]);
                    dirList[i] = dirList[i].Replace("archive\\", ""); //удалила путь
                    helpp.WriteLine(dirList[i]);
                }

                string[] fileList = Directory.GetFiles(directory);
                for (int i = 0; i < fileList.Length; i++)
                {
                    fileList[i] += "\tfile\t" + File.GetLastWriteTime(fileList[i]);
                    fileList[i] = fileList[i].Replace("archive\\", ""); //удалила путь в названии
                    helpp.WriteLine(fileList[i]);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Ваш путь до файла пустой");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Файл по указанному пути не найден");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static async Task FileWriter(string path, string nameFile)
        {
            try
            {
                await using StreamWriter fileWriter = new StreamWriter(Environment.ExpandEnvironmentVariables(path));
                fileWriter.WriteLine(Path.GetFullPath(nameFile));

                Console.WriteLine($"Файл успешно создан, путь к {nameFile} записан");
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine("Файл закрыт, не могу в него что-то записать");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
/*
 Во второй программе у меня не было StreamReader и StreamWriter, поэтому переделывать нечего. 
Старалась их туда добавить, но не получилось, программа не работала
 */