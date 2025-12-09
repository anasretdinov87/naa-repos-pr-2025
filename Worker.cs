namespace practice_synergy_worker
{
    internal class Worker
    {
        private string surnameInitials;
        private string position;
        private decimal salary;
        private DateTime employmentDate;

        public Worker()
        {
            surnameInitials = "Unknown";
            position = "Unknown";
            salary = 0;
            employmentDate = new DateTime(1900, 1, 1);
        }

        public Worker(string surnameInitials, string position, decimal salary, DateTime employmentDate)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                throw new ArgumentException("Full name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position cannot be empty");
            }
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot by less than zero");
            }
            DateTime checkDate = new DateTime(1900, 1, 1);
            if (employmentDate < checkDate)
            {
                throw new ArgumentException("Employment date cannot be earlier than  1 January 1995");
            }

            this.surnameInitials = surnameInitials;
            this.position = position;
            this.salary = salary;
            this.employmentDate = employmentDate;
        }
        public Worker(string surnameInitials)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                throw new ArgumentException("Full name cannot be empty");
            }
            this.surnameInitials = surnameInitials;
            position = "Unknown";
            salary = 0;
            employmentDate = new DateTime(1900, 1, 1);
        }
        public Worker(string surnameInitials, string position)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                throw new ArgumentException("Full name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position cannot be empty");
            }
            this.surnameInitials = surnameInitials;
            this.position = position;
            salary = 0;
            employmentDate = new DateTime(1900, 1, 1);
        }
        public Worker(string surnameInitials, string position, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(surnameInitials))
            {
                throw new ArgumentException("Full name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(position))
            {
                throw new ArgumentException("Position cannot be empty");
            }
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot by less than zero");
            }

            this.surnameInitials = surnameInitials;
            this.position = position;
            this.salary = salary;
            employmentDate = new DateTime(1900, 1, 1);
        }
    }
}
