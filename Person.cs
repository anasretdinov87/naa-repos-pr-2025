namespace practice_synergy_worker
{
    internal class Person
    {      
        private string _fullName = "unknown";  //Полное имя сотрудника
        private DateTime _birthday = new DateTime(1900,1,1); //Дата рождения
        private string _birthPlace = "unknown"; //Место рождения

        public Person() { } //Конструктор по умолчанию
        public Person(string fullName, DateTime birthday, string birthPlace) //Конструктор с тремя полями
        {
            FullName = fullName;
            Birthday = birthday;
            BirthPlace = birthPlace;
        }
        public Person(string fullName, DateTime birthday) //Конструктор с двумя полями
        {
            FullName = fullName;
            Birthday = birthday;
            BirthPlace = "unknown";
        }
        public Person(string fullName) //Конструктор с одним полем
        {
            FullName = fullName;
            Birthday = new DateTime(1900,1,1);
            BirthPlace = "unknown";
        }
        //-----------------------------------------
        // Методы изменения и вывода полей
        public string FullName
        {
            get => _fullName;
            set => _fullName = value??"unknown";
        }
        public DateTime Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }
        public string BirthPlace
        {
            get => _birthPlace; 
            set => _birthPlace = value ?? "unknown";
        }
        //-----------------------------------------
    }
}
