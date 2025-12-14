using System;
using System.Text;
using System.Text.Json;

namespace practice_synergy_worker
{
    internal class Worker:Person, IDisposable
    {
        private FileStream _fileStream;    //Поток файла
        private bool _disposed;       //Флаг, указывающий, был ли объект утилизирован

        private string _position = "unknown";  //должность
        private decimal _salary = 0;   //зарплата
        private int _hireYear = 1900;  //год трудоустройства
        private string _academicDegree = "unknown"; //учёная степень
        private string _academicRank = "unknown"; //учёное звание
        private Boolean _isResearcher = false; //признак научного сотрудника
                         
        public Worker(   //Конструктор со всеми полями
            string fullName,
            DateTime birthday,
            string birthPlace,
            string position,
            decimal salary,
            int hireYear,
            string academicDegree,
            string academicRank,
            Boolean isResearcher)
            : base(fullName, birthday, birthPlace)
        {
            Position = position;
            Salary = salary;
            HireYear = hireYear;
            AcademicDegree = academicDegree;
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        //---------------------------------------------
        //Различные варианты конструкторов
        public Worker(   
            string fullName,
            DateTime birthday,            
            string position,
            decimal salary,
            int hireYear,
            string academicDegree,
            string academicRank,
            Boolean isResearcher)
            : base(fullName, birthday)
        {
            Position = position;
            Salary = salary;
            HireYear = hireYear;
            AcademicDegree = academicDegree;
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        public Worker(
            string fullName,           
            string position,
            decimal salary,
            int hireYear,
            string academicDegree,
            string academicRank,
            Boolean isResearcher)
            : base(fullName)
        {
            Position = position;
            Salary = salary;
            HireYear = hireYear;
            AcademicDegree = academicDegree;
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        public Worker(   
            string fullName,
            DateTime birthday,
            string birthPlace,
            int hireYear,
            string academicDegree,
            string academicRank,
            Boolean isResearcher)
            : base(fullName, birthday, birthPlace)
        {
            Position = "unknown";
            Salary = 0;
            HireYear = hireYear;
            AcademicDegree = academicDegree;
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        public Worker(   
            string fullName,
            DateTime birthday,
            string birthPlace,        
            string academicDegree,
            string academicRank,
            Boolean isResearcher)
            : base(fullName, birthday, birthPlace)
        {
            Position = "unknown";
            Salary = 0;
            HireYear = 0;
            AcademicDegree = academicDegree;
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        public Worker(   
            string fullName,
            DateTime birthday,
            string birthPlace,           
            string academicRank,
            Boolean isResearcher)
            : base(fullName, birthday, birthPlace)
        {
            Position = "unknown";
            Salary = 0;
            HireYear = 0;
            AcademicDegree = "unknown";
            AcademicRank = academicRank;
            IsResearcher = isResearcher;
        }
        public Worker(   
            string fullName,
            DateTime birthday,
            string birthPlace,         
            Boolean isResearcher)
            : base(fullName, birthday, birthPlace)
        {
            Position = "unknown";
            Salary = 0;
            HireYear = 0;
            AcademicDegree = "unknown";
            AcademicRank = "unknown";
            IsResearcher = isResearcher;
        }
        public Worker(   
            string fullName,
            DateTime birthday,
            string birthPlace
            )
            : base(fullName, birthday, birthPlace)
        {
            Position = "unknown";
            Salary = 0;
            HireYear = 0;
            AcademicDegree = "unknown";
            AcademicRank = "unknown";
            IsResearcher = false;
        }
        //-----------------------------------------
        // Методы изменения и вывода полей
        public string Position
        {
            get => _position;
            set => _position = value ?? "unknown";
        }
        public decimal Salary
        {
            get => _salary;
            set => _salary = value;
        }
        public int HireYear
        {
            get => _hireYear;
            set => _hireYear = value;
        }
        public string AcademicDegree
        {
            get => _academicDegree;
            set => _academicDegree = value ?? "unknown";
        }
        public string AcademicRank
        {
            get => _academicRank;
            set => _academicRank = value ?? "unknown";
        }
        public Boolean IsResearcher
        {
            get => _isResearcher;
            set => _isResearcher = value;
        }
        //-----------------------------------------
        public int WorkExperienceYears => DateTime.Today.Year - HireYear; //Вывод стажа
        //public Worker(): base() {    //Конструктор по умолчанию
        //    FullName = "unknown";
        //    Birthday = new DateTime(1900, 1, 1);
        //    BirthPlace = "unknown";
        //    Position = "unknown";
        //    Salary = 0;
        //    HireYear = 0;
        //    AcademicDegree = "unknown";
        //    AcademicRank = "unknown";
        //    IsResearcher = false;
        //}
        public Worker(): base() { }   //Конструктор по умолчанию
        public List<Worker> GetWorkersFromFile()   //Загрузка рабочих из файла workers.json. Файл в корне проекта Visual Studio
        {           
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string filePath = Path.Combine(projectDirectory, "..", "workers.json");
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found");
            //string content = File.ReadAllText(filePath);
            _fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            string content = LoadTextFile();
            List<Worker> workers = JsonSerializer.Deserialize<List<Worker>>(content);
            return workers;
        }
         public string LoadTextFile()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(Worker));
            
            using(var reader = new StreamReader(_fileStream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fileStream?.Close();
                    _fileStream?.Dispose();
                }
                _disposed = true;
            }
        }
        ~Worker()   //Деструктор
        {
            Dispose(false);
        }
        public List<Worker> GetWorkersWithWorkExperience(List<Worker> workers, int searchWorkExperience)
        {
            List<Worker> findedWorkers = new List<Worker>();
            foreach (Worker worker in workers)
            {
                int currentYear = DateTime.Now.Year;
                int workerHireYear = worker.HireYear;
                if (currentYear - workerHireYear > searchWorkExperience)
                {
                    findedWorkers.Add(worker);
                }
            }
            return findedWorkers;
        }
    }
}
