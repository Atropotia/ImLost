using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTFApp
{
    internal class FileETC
    {
        //Чтение из файла данных
        private static void ReadData()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    worker.Add(new Worker(sr.ReadLine()));
                }

            }
        }

        //Редактирование записи о сотруднике
        public static void Edit()
        {
            Console.Write("Введите ID сотрудника для редактирования записи: ");
            int ID;
            try
            {
                int cid = int.Parse(Console.ReadLine());
                Console.Write($"Редактируемые данные о работнике: {worker[cid].ID} ");
                ID = cid;
            }
            catch
            {
                Console.Write($"Введите верный ID");
                Console.ReadKey();
                Console.Clear();
                return;
            }

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

        //Просмотр записей в определённом промежутке дат
        public static void SortDate()
        {
            DateTime min, max;
            Console.Write("Введите начальную дату: ");
            min = DateTime.Parse(Console.ReadLine());

            Console.Write("Введите конечную дату: ");
            max = DateTime.Parse(Console.ReadLine());

            foreach (Worker employee in worker)
            {
                if (employee.CurrentTime >= min && employee.CurrentTime <= max)
                {
                    Console.WriteLine($"{employee.ID}" + " " +
                                 $"{employee.CurrentTime}" + " " +
                                 $"{employee.Name}#" + " " +
                                 $"{employee.Age}#" + " " +
                                 $"{employee.Height}#" + " " +
                                 $"{employee.BirthDate}#" + " " +
                                 $"{employee.BirthPlace}");
                }
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Вывод на экран записей из файла
        static private void PrintFile()
        {
            if (worker != null)
            {
                foreach (Worker employee in worker)
                {
                    Console.WriteLine($"{employee.ID}" + " " +
                                 $"{employee.CurrentTime}" + " " +
                                 $"{employee.Name}" + " " +
                                 $"{employee.Age}" + " " +
                                 $"{employee.Height}" + " " +
                                 $"{employee.BirthDate}" + " " +
                                 $"{employee.BirthPlace}");
                }
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Сортировка данных в пордке возрастания
        static private void SortDateUp()
        {
            DateTime[] counter = new DateTime[worker.Count];
            string[] list = new string[worker.Count];

            for (int i = 0; i < list.Length; i++)
            {
                counter[i] = worker[i].CurrentTime;
                list[i] =
                    worker[i].ID + " " +
                    worker[i].Name + " " +
                    worker[i].Age + " " +
                    worker[i].Height + " " +
                    worker[i].BirthDate + " " +
                    worker[i].BirthPlace + " ";
            }
        }

        //Сотировка данных в порядке убывания
        static private void SortDateDown()
        {
            DateTime[] counter = new DateTime[worker.Count];
            string[] list = new string[worker.Count];

            for (int i = 0; i < list.Length; i++)
            {
                counter[i] = worker[i].CurrentTime;
                list[i] =
                    worker[i].ID + " " +
                    worker[i].Name + " " +
                    worker[i].Age + " " +
                    worker[i].Height + " " +
                    worker[i].BirthDate + " " +
                    worker[i].BirthPlace + " ";
            }

            Array.Sort(counter, list);

            for (int i = counter.Length - 1; i >= 0; i--)
            {
                int found = list[i].IndexOf(" ");
                Console.WriteLine(list[i].Substring(0, found) + "   " + counter[i] + "  " + list[i].Substring(found + 1));
            }

            Console.WriteLine("Готово. Нажмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        //Удаление сотрудника
        static private void Delete()
        {
            Console.WriteLine("Введите ID сотрудника для удаления");
            string id = Console.ReadLine().ToString();
            List<Worker> notesForDelete = worker.FindAll(note => note.ID.ToString() == id);
            if (notesForDelete.Count == 0)
            {
                Console.WriteLine($"Записи с номером {id} не найдено");
            }
            else
            {
                DeleteNotes(notesForDelete);
            }
        }

        //Метод для удаления записи
        static void DeleteNotes(List<Worker> notesForDelete)
        {
            foreach (Worker note in notesForDelete)
            {
                worker.Remove(note);
            }
        }
    }
}
