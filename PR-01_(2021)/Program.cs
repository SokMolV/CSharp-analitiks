using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace first_program
{
  class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }
  }
  class Program
  {
    //string put =;
    static async Task Main(string[] args)
    {
      char choice_2;
      Console.WriteLine("ВОЗМОЖНО ВЫПОЛНИТЬ СЛЕДУЮЩИЕ ДЕЙСТВИЯ\n");
      do
      {

        Console.WriteLine("1) Информацию в консоль о логических дисках, именах, метке тома, размере типе файловой системы.");
        Console.WriteLine("2) Работа с файлами.");
        Console.WriteLine("3) Работа с форматом XML.");
        Console.WriteLine("4) Работа с ZIP сжатием.");
        Console.WriteLine("5) Работа с форматом JSON.");
        Console.WriteLine("0) Выход из программы.");
        Console.Write("Выберите номер команды: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
          case 1:
            /*Вывести информацию в консоль о логических дисках, именах, метке тома, размере типе файловой системы.*/
            {
              Console.WriteLine("1. ИНФОРМАЦИЯ О ДИСКАХ");
              DriveInfo[] drivers = DriveInfo.GetDrives();
              foreach (DriveInfo drive in drivers)
              {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                  Console.WriteLine($"Объем диска: {drive.TotalSize}");
                  Console.WriteLine($"Свободное пространство: {drive.TotalFreeSpace}");
                  Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
                Console.WriteLine();
              }
              break;
            }
          case 2:
            {
              Console.WriteLine("2.Работа с файлами");
              string path = @"D:\Documents\SOKOL";
              Console.WriteLine("Введите строку для записи в файл:");
              string text = Console.ReadLine();
              // запись в файл
              using (FileStream fstream = new FileStream($"{path}text.txt", FileMode.OpenOrCreate))
              {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
              }
              // чтение из файла
              using (FileStream fstream = File.OpenRead($"{path}text.txt"))
              {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
              }
              Console.WriteLine("Удалить файл? + OR -: ");
              switch (Console.ReadLine())
              {
                case "+":
                  if (File.Exists($"{path}text.txt"))
                  {
                    File.Delete($"{path}text.txt");
                    Console.WriteLine("Файл удален!");
                  }
                  else Console.WriteLine("Файла не существует!");
                  break;
                case "-":
                  break;
                default:
                  Console.WriteLine("Введено неверное значение!");
                  break;
              }
              Console.WriteLine();
              break;
            }
          case 3:
            {
              Console.WriteLine("Работа с XML:");
              XmlDocument xDoc = new XmlDocument();
              XDocument xdoc = new XDocument();
              Console.Write("Сколько пользователей нужно ввести: ");
              int count = Convert.ToInt32(Console.ReadLine());
              XElement list = new XElement("users");
              for (int i = 1; i <= count; i++)
              {
                XElement User = new XElement("user");
                Console.Write("Введите имя пользователя: ");
                XAttribute UserName = new XAttribute("name", Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите возраст пользователя: ");
                XElement UserAge = new XElement("age", Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
                Console.Write("Введите название компании: ");
                XElement UserCompany = new XElement("company", Console.ReadLine());
                Console.WriteLine();
                User.Add(UserName);
                User.Add(UserAge);
                User.Add(UserCompany);
                list.Add(User);
              }
              xdoc.Add(list);
              xdoc.Save(@"D:\Documents\SOKOL\users.xml");

              Console.Write("Прочитать XML файл? (+ OR -): ");
              switch (Console.ReadLine())
              {
                case "+":
                  Console.WriteLine();
                  xDoc.Load(@"D:\Documents\SOKOL\users.xml");
                  XmlElement xRoot = xDoc.DocumentElement;
                  foreach (XmlNode xnode in xRoot)
                  {
                    if (xnode.Attributes.Count > 0)
                    {
                      XmlNode attr = xnode.Attributes.GetNamedItem("name");
                      if (attr != null)
                        Console.WriteLine($"Имя: {attr.Value}");
                    }
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                      if (childnode.Name == "age")
                        Console.WriteLine($"Возраст: {childnode.InnerText}");
                      if (childnode.Name == "company")
                        Console.WriteLine($"Компания: {childnode.InnerText}");
                    }
                  }
                  Console.WriteLine();
                  break;
                case "-":
                  break;
                default:
                  Console.WriteLine("Введены неправильные данные!");
                  break;
              }
              Console.Write("Удалить созданный xml файл? (+ OR -): ");
              switch (Console.ReadLine())
              {
                case "+":
                  FileInfo xmlfilecheck = new FileInfo(@"D:\Documents\SOKOL\users.xml");
                  if (xmlfilecheck.Exists)
                  {
                    xmlfilecheck.Delete();
                    Console.WriteLine("Файл удален!");
                  }
                  else Console.WriteLine("Файла не существует!");
                  break;
                case "-":
                  break;
                default:
                  Console.WriteLine("Введено неверное зачение!");
                  break;
              }
              Console.WriteLine();
              break;
            }
          case 4:
            {
              Console.WriteLine("Работа с ZIP:");
              string SourceFile = @"D:\Documents\SOKOL\oop.txt"; // исходный файл
              string CompressedFile = @"D:\Documents\SOKOL\bin.gz"; // сжатый файл
              string TargetFile = @"D:\Documents\SOKOL\oop1.txt"; // восстановленный файл
                                                                   // создание сжатого файла
              Compress(SourceFile, CompressedFile);
              // чтение из сжатого файла
              Decompress(CompressedFile, TargetFile);
              Console.WriteLine("Удалить файлы? (+ OR -): ");
              switch (Console.ReadLine())
              {
                case "+":
                  if ((File.Exists(SourceFile) &&
                       File.Exists(CompressedFile) && File.Exists(TargetFile)) == true)
                  {
                    File.Delete(SourceFile);
                    File.Delete(CompressedFile);
                    File.Delete(TargetFile);
                    Console.WriteLine("Файлы удалены!");
                  }
                  else Console.WriteLine("Ошибка в удалении файлов!\n Проверьте их наличие!");
                  break;
                case "-":
                  break;
                default:
                  Console.WriteLine("Введены неправильные данные! Попробуйте снова!");
                  break;
              }
              Console.WriteLine();
              break;
            }
          case 5:
            {
              Console.WriteLine("Работа с JSON:");
              // сохранение данных
              using (FileStream fs = new FileStream(@"D:\Documents\SOKOL\user.json", FileMode.OpenOrCreate))
              {
                Person Marya = new Person() { Name = "Marya", Age = 19 };
                await JsonSerializer.SerializeAsync<Person>(fs, Marya);
                Console.WriteLine("Данные введены автоматически и они сохранены!");
              }

              // чтение данных
              using (FileStream fs = new FileStream(@"D:\Documents\SOKOL\user.json", FileMode.OpenOrCreate))
              {
                Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
              }
              Console.Write("Вы хотите удалить файл? (+ OR -): ");
              switch (Console.ReadLine())
              {
                case "+":
                  File.Delete(@"D:\Documents\SOKOL\user.json");
                  Console.WriteLine("\nФайл удален!");
                  break;
                case "-":
                  break;
              }
              break;
            }
          default:
            Console.WriteLine("\nВВЕДЕНЫ НЕПРАВИЛЬНЫЕ ДАННЫЕ!");
            break;
        }
        Console.WriteLine("================================");
        Console.Write("\nХотите продолжить? + OR -: ");
        choice_2 = Convert.ToChar(Console.ReadLine());
        Console.Write('\n');
      } while (choice_2 != '-');
    }
    public static void Compress(string sourceFile, string compressedFile)
    {
      // поток для чтения исходного файла
      using (FileStream sourceStream = new FileStream(sourceFile, FileMode.OpenOrCreate))
      {
        // поток для записи сжатого файла
        using (FileStream targetStream = File.Create(compressedFile))
        {
          // поток архивации
          using (GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress))
          {
            sourceStream.CopyTo(compressionStream); // копируем байты из одного потока в другой
            Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                sourceFile, sourceStream.Length.ToString(), targetStream.Length.ToString());
          }
        }
      }
    }
    public static void Decompress(string compressedFile, string targetFile)
    {
      // поток для чтения из сжатого файла
      using (FileStream sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate))
      {
        // поток для записи восстановленного файла
        using (FileStream targetStream = File.Create(targetFile))
        {
          // поток разархивации
          using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
          {
            decompressionStream.CopyTo(targetStream);
            Console.WriteLine("Восстановлен файл: {0}", targetFile);
          }
        }
      }
    }
  }
}