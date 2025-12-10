class Program
{
    static void Main(string[] args)
    {
        //Флаг для цикла продолжения ввода команд
        Boolean isWorkNotComplete = true;
        while (isWorkNotComplete) {
            Console.WriteLine("Введите w - для ввода нового работника, d - для поиска работников с определенным стажем, exit - выход из програмы");
            Console.Write("Ввод:");
            string command = Console.ReadLine()??"no_command";
            switch (command)
            {
                case "w":
                    break;
                case "d":
                    break;
                case "exit":
                    isWorkNotComplete = false;
                    break;
                default:
                    Console.WriteLine("Несуществующая команда. Повторите ввод.");
                    break;
            }
        }
       
    }
}