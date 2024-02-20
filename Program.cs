namespace ConsoleAppHomework1902ex2;
 class Program
{
    private static readonly object locker = new object(); 
    static void Main()
    {
        int[] data = { 45, 36, 28, 11, 72, 99 };
        int numberToFind = 36;
        var sortTask = Task.Run(() =>
        {
            lock (locker) 
            {
                Console.WriteLine("Сортировка массива...");
                Array.Sort(data);
                Console.WriteLine("Массив отсортирован.");
            }
        });
        sortTask.ContinueWith(t =>
        {
            lock (locker) 
            {
                Console.WriteLine("Поиск числа в массиве...");
                bool found = data.Contains(numberToFind);
                if (found)
                {
                    Console.WriteLine($"Число {numberToFind} найдено в массиве.");
                }
                else
                {
                    Console.WriteLine($"Число {numberToFind} не найдено в массиве.");
                }
            }
        }).Wait(); 
    }
}