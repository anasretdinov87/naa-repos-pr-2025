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
    }
}
