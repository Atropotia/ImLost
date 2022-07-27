using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WTFApp
{
    class Willkommen
    {
        static string path = "Notebook.txt";
        static List<Worker> worker = new List<Worker>();

        public void Start()
        {
            if (!File.Exists(path))
            {
                FileInfo fi1 = new FileInfo(path);
            }

            else
            {
                ReadData();
            }

            while (true)
            {
                bool exit = false;
                Console.WriteLine($"Доброго времени суток.\n Нажмите 1 чтобы вывести данные на экран" +
                $"\n Нажмите 2 для добавления сотрудника" +
                $"\n Нажмите 3 для удаления определённых данных" +
                $"\n Нажмите 4 для редактирования данных" +
                $"\n Нажмите 5 для того чтобы показать сотрудников в диапазоне определённых дат" +
                $"\n Нажмите 6 для сортировки по убыванию" +
                $"\n Нажмите 7 для сортировки по возрастанию" +
                $"\n Нажмите 0 для выхода");
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 1:
                        PrintFile();
                        break;
                    case 2:
                        AddLine();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Edit();
                        break;
                    case 5:
                        SortDate();
                        break;
                    case 6:
                        SortDateDown();
                        break;
                    case 7:
                        SortDateUp();
                        break;
                    case 0:
                        Exit();
                        exit = true;
                        return;
                    default:
                        break;

                }
            }
        }

        //Добавление сотрудника
        public static void AddLine()
        {
            string line = $"{worker.Count}#{DateTime.Now}#";
            Console.Write("Введите фамилию, имя и отчество сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите возраст сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите рост сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите дату рождения сотрудника: ");
            line += Console.ReadLine() + "#";
            Console.Write("Введите место рождения сотрудника: ");
            line += Console.ReadLine();
            worker.Add(new Worker(line));

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Выход из программы
        static private void Exit()
        {
            Console.WriteLine("Для сохранения и выхода нажмите ENTER, для выхода без созранения введите N и нажмите ENTER:");
            if (Console.ReadLine() == "N")
            {
                Console.WriteLine("Выход без сохранения");
            }
            else
            {
                SaveToFile();
                Console.WriteLine("Данные были сохранены");
            }
        }
    }
}
