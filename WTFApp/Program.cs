public string path = "Notebook.txt";
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
        $"\n Нажмите 4 для того чтобы показать сотрудников в диапазоне определённых дат" +
        $"\n Нажмите 5 для сортировки по убыванию" +
        $"\n Нажмите 6 для сортировки по возрастанию" +
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