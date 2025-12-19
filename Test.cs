using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_synergy_worker
{
    internal class Test
    {
          public void Test1()
        {
            // создаём работника
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

            // Проверяем свойства
            Console.WriteLine($"ФИО: {worker.FullName}");           // → "Иванов И. И."
            Console.WriteLine($"Должность: {worker.Position}");         // → "Доцент"
            Console.WriteLine($"Зарплата: {worker.Salary}");            // → 75000.00
            Console.WriteLine($"Учёная степень: {worker.AcademicDegree}"); // → "к. ф.-м. н."
            Console.WriteLine($"Научный сотрудник: {worker.IsResearcher}"); // → true

            // Шаг 3: проверяем стаж (на 2025 год)
            int expectedExperience = 2025 - 2010; // 15 лет
            Console.WriteLine($"Стаж: {worker.WorkExperienceYears} лет"); // → 15

            if (worker.WorkExperienceYears == expectedExperience)
                Console.WriteLine("Тест 1 пройден: данные сохранены корректно.");
            else
                Console.WriteLine("Тест 1 НЕ пройден: ошибка в расчёте стажа.");
        }
        public void Test2()
        {
            Worker workerInstance = new Worker();

            try
            {
                List<Worker> workers = workerInstance.GetWorkersFromFile();

                Console.WriteLine($"Загружено {workers.Count} работников из файла.");

                foreach (Worker w in workers)
                {
                    Console.WriteLine($"- {w.FullName}, должность: {w.Position}, стаж: {w.WorkExperienceYears} лет");
                }

                Console.WriteLine("Тест 2 пройден: файл успешно загружен и десериализован.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Тест 2 НЕ пройден: ошибка при загрузке файла: {ex.Message}");
            }
        }
            public void Test3()
            {
            // Шаг 1: создаём список работников
            List<Worker> allWorkers = new List<Worker>
{
    new Worker("Алексеев А. А.", new DateTime(1980, 1, 1), "г. Казань", "Старший преподаватель", 60000, 2008, "к. п. н.", "доцент", true),
    new Worker("Борисова Б. Б.", new DateTime(1990, 6, 15), "г. Екатеринбург", "Ассистент", 45000, 2022, "нет", "нет", false),
    new Worker("Васильев В. В.", new DateTime(1975, 3, 10), "г. Ростов", "Профессор", 150000, 2000, "д. и. н.", "профессор", true)
};

            // Шаг 2: ищем работников со стажем > 10 лет (на 2025 год)
            int requiredExperience = 10;
            List<Worker> filteredWorkers = workerInstance.GetWorkersWithWorkExperience(allWorkers, requiredExperience);

            // Шаг 3: выводим результат
            Console.WriteLine($"Найдено работников со стажем > {requiredExperience} лет: {filteredWorkers.Count}");
            foreach (Worker w in filteredWorkers)
            {
                int actualExperience = 2025 - w.HireYear;
                Console.WriteLine($"- {w.FullName}, стаж: {actualExperience} лет, должность: {w.Position}");
            }

            // Проверка: должны быть только Алексеев (17 лет) и Васильев (25 лет)
            if (filteredWorkers.Count == 2 &&
                filteredWorkers.Any(w => w.FullName == "Алексеев А. А.") &&
                filteredWorkers.Any(w => w.FullName == "Васильев В. В."))
            {
                Console.WriteLine("Тест 3 пройден: фильтрация по стажу работает корректно.");
            }
            else
            {
                Console.WriteLine("Тест 3 НЕ пройден: некорректный результат фильтрации.");
            }
        }
        }
    }
}
