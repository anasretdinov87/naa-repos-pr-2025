using practice_synergy_worker;
class Program
{
    static void Main(string[] args)
    {        
        Boolean isWorkNotComplete = true;   //Флаг продолжать ли ввод работников
        List<Worker> workerList = new List<Worker>();
        Worker workerForGetData = new Worker();
        
        while (isWorkNotComplete) {
            Console.WriteLine("""                
                Команды:                
                w - для ввода нового сотрудника               
                s - для поиска работников с определенным стажем
                f - Добавить данные работников из файла workers.json
                test - Запуск тестов
                exit - выход из програмы                 
                """);
            Console.Write("Ввод команды:");
            string command = Console.ReadLine()??"no_command";
            switch (command)
            {
                case "w":
                    string fullName = "";
                    DateTime birthday = new DateTime(1900, 1, 1);
                    string birthPlace = "unknown";
                    string position = "";
                    decimal dec_salary = 0;
                    int hireYear = 0;
                    string academicDegree = "unknown";
                    string academicRank = "unknown";
                    Boolean isResearcher = false;
                    Boolean isFullNameNotValid = true;  //Флаг корректности ввода фамилии и инициалов
                    while (isFullNameNotValid)
                    {
                        Console.Write("Введите фамилию и инициалы сотрудника:");
                        fullName = Console.ReadLine()??"";
                        if (string.IsNullOrWhiteSpace(fullName))
                        {
                            Console.WriteLine("Ошибка ввода фамилии и инициалов сотрудника. Значение не может быть пустым. Повторите ввод.");
                        }
                        else
                        {
                            isFullNameNotValid = false;
                        }
                    }
                    Boolean isBirthdayNotValid = true;  //Флаг корректности ввода даты рождения
                    while (isBirthdayNotValid)
                    {
                        Console.Write("Введите дату рождения сотрудника:");
                        string strBirthday = Console.ReadLine() ?? "";                         
                        if (!string.IsNullOrWhiteSpace(strBirthday))
                        {
                            if (DateTime.TryParse(strBirthday, out birthday))
                            {
                                isBirthdayNotValid = false;
                            }                           
                        }
                        if(isBirthdayNotValid)
                        {
                            Console.WriteLine("Ошибка ввода даты рождения сотрудника. Повторите ввод.");
                        }                        
                    }
                    Boolean isPositionNotValid = true; //Флаг корректности ввода должности
                    while (isPositionNotValid)
                    {
                        Console.Write("Введите название должности сотрудника:");
                        position = Console.ReadLine()??"";
                        if (string.IsNullOrWhiteSpace(position))
                        {
                            Console.WriteLine("Ошибка ввода названия должности сотрудника. Значение не может быть пустым. Повторите ввод.");
                        }
                        else
                        {
                            isPositionNotValid = false;
                        }
                    }
                    Boolean isSalaryNotValid = true;  //Флаг корректности ввода зарплаты
                    while (isSalaryNotValid)
                    {
                        Console.Write("Введите зарплату сотрудника:");
                        string salary = Console.ReadLine()??"";                        
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
                    
                    Console.Write("Введите учёную степень сотрудника:");
                    academicDegree = Console.ReadLine() ?? "No";
                    if (string.IsNullOrWhiteSpace(academicDegree))
                    {
                        academicDegree = "No";
                    }

                    Console.Write("Введите учёное звание сотрудника:");
                    academicRank = Console.ReadLine() ?? "No";
                    if (string.IsNullOrWhiteSpace(academicRank))
                    {
                        academicRank = "No";
                    }

                    Boolean IsResearcherValueNotValid = true;
                    while (IsResearcherValueNotValid)
                    {
                        Console.Write("Укажите занимается ли сотрудник научной работой (1 - Да/0 - Нет):");
                        string strIsResearcher = Console.ReadLine() ?? "unknown"; ;
                        if  (strIsResearcher == "1")
                        {
                            isResearcher = true;
                            IsResearcherValueNotValid = false;
                        } else if (strIsResearcher == "0")
                        {
                            isResearcher = false;
                            IsResearcherValueNotValid = false;
                        }                        
                        
                        if (isHireYearNotValid)
                        {
                            Console.WriteLine("Ошибка. Введено некорректное значение.");
                        }
                    }
                    
                    // признак того, что сотрудник занимается научной работой
                    Worker worker = new Worker(fullName, birthday, birthPlace,position, dec_salary, hireYear, academicDegree, academicRank, isResearcher);
                    workerList.Add(worker);
                    Console.WriteLine("Работник успешно сохранен");
                    Console.WriteLine();
                    break;
                case "s":
                    Boolean isWorkExperienceNotValid = true; //Флаг корректности ввода значения стажа для поиска
                    while (isWorkExperienceNotValid)
                    {
                        Console.Write("Введите искомый стаж работы: ");
                        string strSearchWorkExperience = Console.ReadLine();                        
                        if (!string.IsNullOrWhiteSpace(strSearchWorkExperience)){
                            int searchWorkExperience = -1;
                                 if (int.TryParse(strSearchWorkExperience, out searchWorkExperience))
                                {
                                   if (searchWorkExperience >= 0)
                                    {
                                        List<Worker> resultListWorkers = new List<Worker>();
                                        resultListWorkers = workerForGetData.GetWorkersWithWorkExperience(workerList, searchWorkExperience);
                                        if (resultListWorkers.Count > 0)
                                        {                                           
                                            Console.WriteLine($"\nНайдено {resultListWorkers.Count} работников у которых стаж привышает значение {strSearchWorkExperience}:");
                                            foreach (Worker tempWorker in resultListWorkers)
                                            {
                                            Console.WriteLine(tempWorker.FullName);
                                                }
                                        }
                                        else
                                        {
                                        Console.WriteLine($"Не найдено работников у которых стаж превышает значение {strSearchWorkExperience}");
                                        }
                                        Console.WriteLine();
                                        isWorkExperienceNotValid = false;
                                    }
                                }
                        }
                        if (isWorkExperienceNotValid)
                        {
                            Console.WriteLine("Ошибка. Введено некорректное значение, необходимо ввести целое положительное число.");
                        }
                    }                    
                    break;
                case "f":
                    try
                    {
                        List<Worker> temp_workers = new List<Worker>();
                        temp_workers = workerForGetData.GetWorkersFromFile();
                        workerList.AddRange(temp_workers);
                        Console.WriteLine($"Успешно добавлено {temp_workers.Count()} записей из файла workers.json");
                        Console.WriteLine();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Ошибка. Не удалось загрузить данные из файла workers.json -  {ex}");
                        Console.WriteLine();
                    }
                    break;
                case "test":
                    Test test = new Test();
                    Console.Write("""
                        Список тестов:
                        1 - Проверка стажа
                        2 - Проверка загрузки сотрудников из файла
                        3 - Поиск работников со стажем 10 лет

                        Ввод команды:
                        """);
                    string test_command = Console.ReadLine() ?? "no_command";
                    switch (test_command)
                    {
                        case "1":
                            test.Test1();
                            break;
                        case "2":
                            test.Test2();
                            break;
                        case "3":
                            test.Test3();
                            break;
                    }
                    break;
                case "exit":
                    isWorkNotComplete = false;
                    break;
                default:
                    Console.WriteLine("Несуществующая команда. Повторите ввод.\n");
                    break;
            }
        }       
    }
}