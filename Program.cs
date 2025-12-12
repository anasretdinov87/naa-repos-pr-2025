using practice_synergy_worker;
class Program
{
    static void Main(string[] args)
    {
        
        Boolean isWorkNotComplete = true;   //Флаг продолжать ли ввод работников
        List<Worker> workerList = new List<Worker>();
        while (isWorkNotComplete) {
            string surnameInitials = "";
            string position = "";
            decimal dec_salary = 0;
            int hireYear = 0;
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
                        surnameInitials = Console.ReadLine();
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
                        position = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(position))
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
                        string strHireYear = Console.ReadLine()??"0";                        ;
                        if (int.TryParse(strHireYear, out hireYear))
                        {
                            int currentYear = DateTime.Now.Year;
                            if ((hireYear >= 1995) && (hireYear <= currentYear))
                            {                                 
                                isHireYearNotValid = false;
                            }
                        }                        
                        if (isHireYearNotValid)
                        {
                            Console.WriteLine("Ошибка ввода. Введен некорректный год. Возможен ввод от 1995 до текущего года");
                        }                        
                    }
                    Worker worker = new Worker(surnameInitials, position, dec_salary, hireYear);
                    workerList.Add(worker);
                    Console.WriteLine("Работник успешно сохранен");
                    Console.WriteLine();
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