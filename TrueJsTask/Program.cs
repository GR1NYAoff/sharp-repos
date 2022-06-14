using TrueJsTask;

internal class Program
{
    private static void Main()
    {
        try
        {
            var app = new MaxBottlesApplication();
            var args = Console.ReadLine();

            Console.WriteLine(app.Run(args!));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.ReadKey();
        }

    }
}

