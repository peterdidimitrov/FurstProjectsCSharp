namespace Telephony.Models.Interfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split();
            string[] urls = Console.ReadLine()
                .Split();

            ICallable callable;
            foreach (var phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 10)
                {
                    callable = new Smartphone();
                }
                else
                {
                    callable = new StationaryPhone();
                }
                try
                {
                    Console.WriteLine(callable.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowseble browseble = new Smartphone();

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(browseble.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}