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
    }
}
