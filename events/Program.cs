namespace events
{
    public class Program
    {
        public static void Main()
        {
            var instance = new MyClass();

            // SUBSCRIBE ON EVENT
            instance.myEvent += Handler1;
            instance.myEvent += Handler2;

            instance.InvokeEvent();

            Console.WriteLine();

            var cnt = new Counter();

            cnt.finish += FinishHandelr;

            cnt.Count(1, 8);

            _ = Console.ReadKey();

        }
        private static void FinishHandelr()
        {
            Console.WriteLine("Finish counting!");
        }
        private static void Handler1()
        {
            Console.WriteLine("First handler");
        }
        private static void Handler2()
        {
            Console.WriteLine("Second handler");
        }
    }

    public delegate void SomeEvent();
    public delegate void FinishEvent();
    public delegate void SomeDelegate();

    public class MyClass
    {
        public event SomeEvent? myEvent = null;
        public event SomeEvent? MyEvent
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }
        public void InvokeEvent()
        {
            if (myEvent != null)
                myEvent.Invoke();
        }
    }

    public class Counter
    {
        public event FinishEvent? finish = null;

        public void Count (int start, int end)
        {
            for (int i = start; i <= end; i++)
                Console.WriteLine(i);

            if (finish != null)
                finish!.Invoke();
        }
    }
}