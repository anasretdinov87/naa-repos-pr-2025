using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_synergy_worker
{
    internal class Person
    {      
        private string fullName;  //Полное имя сотрудника
        private DateTime birthday; //Дата рождения
        private string birthPlace; //Место рождения
        public void SetFullName(string value)
        {
            this.fullName = value;
        }
        public void SetBirthday(DateTime value)
        {
            this.birthday = value;
        }
        public void SetBirthPlace(string value)
        {
            this.birthPlace = value;
        }
    }
}
