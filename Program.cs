using practice_synergy_worker;
class Program
{
    static void Main(string[] args)
    {
        //Флаг продолжать ли ввод работников
        Boolean isWorkNotComplete = true;

        List<Worker> workerList = new List<Worker>();
        while (isWorkNotComplete) {
            Console.WriteLine("Команды: w - для ввода нового работника, s - для поиска работников с определенным стажем, exit - выход из програмы");
            Console.Write("Ввод команды:");
            string command = Console.ReadLine()??"no_command";
            switch (command)
            {
                case "w":
                    //Флаг корректности ввода фамилии и инициалов
                    Boolean isSurnameInitialsNotValid = true;
                    while (isSurnameInitialsNotValid)
                    {
                        Console.Write("Введите фамилию и инициалы работника:");
                        string surnameInitials = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(surnameInitials))
                        {
                            Console.WriteLine("Ошибка ввода фамилии и инициалов работника. Значение не может быть пустым. Повторите ввод.");
                        }
                        else
                        {
                            isSurnameInitialsNotValid = false;
                        }
                    }
                    //Флаг корректности ввода должности
                    Boolean isPositionNotValid = true;
                    while (isPositionNotValid)
                    {
                        Console.Write("Введите название должности работника:");
                        string position = Console.ReadLine();
                        if (string.IsNullOrEmpty(position))
                        {
                            Console.WriteLine("Ошибка ввода названия должности работника. Значение не может быть пустым. Повторите ввод.")
                        }
                        else
                        {
                            isPositionNotValid = false;
                        }
                    }
                    Boolean isSalaryNotValid = true;
                    while (isSalaryNotValid)
                    {

                    }
                    Console.Write("Введите зарплату работника:");
                    string salary = Console.ReadLine();
                    Console.Write("Введите год поступление на работу:");
                    string hireYear = Console.ReadLine();                     
                    break;
                case "s":
                    break;
                case "exit":
                    isWorkNotComplete = false;
                    break;
                default:
                    Console.WriteLine("Несуществующая команда. Повторите ввод.");
                    break;
            }
        }       
    }
}