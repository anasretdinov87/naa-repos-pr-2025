using practice_synergy_worker;
class Program
{
    static void Main(string[] args)
    {
        
        Boolean isWorkNotComplete = true;   //Флаг продолжать ли ввод работников
        List<Worker> workerList = new List<Worker>();
        while (isWorkNotComplete) {
            Console.WriteLine("Команды: w - для ввода нового работника, s - для поиска работников с определенным стажем, exit - выход из програмы");
            Console.Write("Ввод команды:");
            string command = Console.ReadLine()??"no_command";
            switch (command)
            {
                case "w":                    
                    Boolean isSurnameInitialsNotValid = true;  //Флаг корректности ввода фамилии и инициалов
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
                    Boolean isPositionNotValid = true; //Флаг корректности ввода должности
                    while (isPositionNotValid)
                    {
                        Console.Write("Введите название должности работника:");
                        string position = Console.ReadLine();
                        if (string.IsNullOrEmpty(position))
                        {
                            Console.WriteLine("Ошибка ввода названия должности работника. Значение не может быть пустым. Повторите ввод.");
                        }
                        else
                        {
                            isPositionNotValid = false;
                        }
                    }
                    Boolean isSalaryNotValid = true;  //Флаг корректности ввода зарплаты
                    while (isSalaryNotValid)
                    {
                        Console.Write("Введите зарплату работника:");
                        string salary = Console.ReadLine();
                        decimal dec_salary = 0;
                        if (!(decimal.TryParse(salary, out dec_salary)))
                        {
                            Console.WriteLine("Ошибка ввода зарплаты. Некорректное значение. Повторите ввод.");
                        } else if (dec_salary < 0)
                        {
                            Console.WriteLine("Ошибка ввода зарплаты. Значение не может быть меньше нуля. Повторите ввод.");
                        }
                        else
                        {
                            isSalaryNotValid = false;
                        }
                    }
                    Boolean isHireYearNotValid = true; //Флаг корректности ввода года поступления на работу
                    while (isHireYearNotValid)
                    {
                        Console.Write("Введите год поступление на работу:");
                        string hireYear = Console.ReadLine();
                        Uint16 currentYear
                    }
                                         
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