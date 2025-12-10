namespace practice_synergy_worker
{
    internal class Worker
    {
        //Фамилия и инициалы работника
        private string surnameInitials;
        //Название занимаемой должности
        private string position;
        //Зарплата
        private decimal salary;
        //Год поступления на работу
        private UInt16 hireYear;

        //Конструктор по умолчанию
        public Worker()
        {
            surnameInitials = "Unknown";
            position = "Unknown";
            salary = 0;
            hireYear = 0;
        }
        //Конструктор с четыремя параметрами
        public Worker(string surnameInitials, string position, decimal salary, UInt16 hireYear)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                GetExceptionMessage("surnameInitials");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                GetExceptionMessage("position");
            }
            if (salary < 0)
            {
                GetExceptionMessage("salary");
            }             
            if (hireYear < 1995)
            {
                GetExceptionMessage("employmentDate");
            }

            this.surnameInitials = surnameInitials;
            this.position = position;
            this.salary = salary;
            this.hireYear = hireYear;
        }
        //Конструктор с одним параметром
        public Worker(string surnameInitials)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                GetExceptionMessage("surnameInitials");
            }
            this.surnameInitials = surnameInitials;
            position = "Unknown";
            salary = 0;
            hireYear = 0;
        }
        //Конструктор с двумя параметрами
        public Worker(string surnameInitials, string position)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                GetExceptionMessage("surnameInitials");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                GetExceptionMessage("position");
            }
            this.surnameInitials = surnameInitials;
            this.position = position;
            salary = 0;
            hireYear = 0;
        }
        //Конструктор с тремя параметрами
        public Worker(string surnameInitials, string position, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                GetExceptionMessage("surnameInitials");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                GetExceptionMessage("position");
            }
            if (salary < 0)
            {
                GetExceptionMessage("salary");
            }
            this.surnameInitials = surnameInitials;
            this.position = position;
            this.salary = salary;
            hireYear = 0;
        }
        //Метод изменения фамилии и инициалов работника
        public void SetSurnameInitials(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                this.surnameInitials = value;
            }
            else
            {
                GetExceptionMessage("surnameInitials");
            }
        }
        //Метод изменения должности работника
        public void SetPosition(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                this.position = value;
            }
            else
            {
                GetExceptionMessage("position");
            }
        }
        //Метод изменения зарплаты
        public void SetSalary(decimal value)
        {
            if (!(value < 0))
            {
                this.salary = value;
            }
            else
            {
                GetExceptionMessage("salary");
            }                
        }
        //Метод изменения дня поступления на работы
        public void SetEmploymentDate(UInt16 value)
        {
            DateTime checkDate = new DateTime(1900, 1, 1);
            DateTime 
            if (!(value < 1995))
            {
                this.hireYear = value;
            }
            else
            {
                GetExceptionMessage("employmentDate");
            }
        }
        //Метод отображения фамилии и инициалов сотрудника
        public string GetSurnameInitials()
        {
            return this.surnameInitials;
        }
        //Метод отображения названия занимаемой должности
        public string GetPosition()
        {
            return this.position;
        }
        //Метод отображения зарплаты
        public string GetSalary()
        {
            return this.salary.ToString();
        }
        //Метод отображения года поступления на работу
        public string GetHireYear()
        {
            return this.hireYear.ToString();
        }
        //Метод для вызыва ошибки в случае некорректного ввода
        private void GetExceptionMessage(string field)
        {
            switch (field)
            {
                case "surnameInitials":
                    throw new ArgumentException("Surname and initials cannot be empty");
                case "position":
                    throw new ArgumentException("Position cannot be empty");
                case "salary":
                    throw new ArgumentException("Salary cannot by less than zero");
                case "employmentDate":
                    throw new ArgumentException("Hire year cannot be earlier than 1995");
            }
        }
    }
}
