namespace practice_synergy_worker
{
    internal class Test
    {
          public void Test1()  //Тест проверки корректности определения стажа
            {
                // Создаём работника
                Worker worker = new Worker(
                    "Иванов И. И.",
                    new DateTime(1985, 5, 10),
                    "г. Москва",
                    "Доцент",
                    75000.00m,
                    2010,
                    "к. ф.-м. н.",
                    "доцент",
                    true
                );           

                // Проверяем стаж
                int expectedExperience = 2025 - 2010; 
                Console.WriteLine($"Стаж: {worker.WorkExperienceYears} лет\n"); 

                if (worker.WorkExperienceYears == expectedExperience)
                    Console.WriteLine("Тест 1 пройден: данные сохранены корректно.\n");
                else
                    Console.WriteLine("Тест 1 НЕ пройден: ошибка в расчёте стажа.\n");
                }
         public void Test2()   //Тест проверки корректности загрузки json файла
            {
                Worker worker = new Worker();
                try
                {
                    List<Worker> workers = worker.GetWorkersFromFile();
                    Console.WriteLine($"\nЗагружено {workers.Count} работников из файла.");
                    foreach (Worker w in workers)
                    {
                        Console.WriteLine($"- {w.FullName}, должность: {w.Position}, стаж: {w.WorkExperienceYears} лет");
                    }
                        Console.WriteLine("\nТест 2 пройден: файл успешно загружен и десериализован.\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nТест 2 НЕ пройден: ошибка при загрузке файла: {ex.Message}\n");
                }
            }
         public void Test3() //Тест проверки корректности поиска сотрудников по стажу
            {
                Worker worker = new Worker();
                //Создаём список работников
                List<Worker> workerList = new List<Worker>
                    {
                        new Worker("Алексеев А. А.", new DateTime(1980, 1, 1), "г. Казань", "Старший преподаватель", 60000, 2008, "к. п. н.", "доцент", true),
                        new Worker("Борисова Б. Б.", new DateTime(1990, 6, 15), "г. Екатеринбург", "Ассистент", 45000, 2022, "нет", "нет", false),
                        new Worker("Васильев В. В.", new DateTime(1975, 3, 10), "г. Ростов", "Профессор", 150000, 2000, "д. и. н.", "профессор", true)
                    };

                //ищем работников со стажем > 10 лет (на 2025 год)
                int requiredExperience = 10;
                List<Worker> filteredWorkers = worker.GetWorkersWithWorkExperience(workerList, requiredExperience);
              
                Console.WriteLine($"\nНайдено работников со стажем > {requiredExperience} лет: {filteredWorkers.Count}");
                foreach (Worker w in filteredWorkers)
                {
                    int actualExperience = 2025 - w.HireYear;
                    Console.WriteLine($"- {w.FullName}, стаж: {actualExperience} лет, должность: {w.Position}");
                }
                
                if (filteredWorkers.Count == 2 &&
                    filteredWorkers.Any(w => w.FullName == "Алексеев А. А.") &&
                    filteredWorkers.Any(w => w.FullName == "Васильев В. В."))
                    {
                        Console.WriteLine("Тест 3 пройден: фильтрация по стажу работает корректно.\n");
                    }
                    else
                    {
                        Console.WriteLine("Тест 3 НЕ пройден: некорректный результат фильтрации.\n");
                    }
            }
    }
}

