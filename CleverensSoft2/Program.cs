using CleverensSoft2;

public class Program
{
    public static void Main()
    {
        ExecuteTasks.ReadWrite();

        Console.WriteLine($"Final count = {Server.GetCount()}");
    }

}
