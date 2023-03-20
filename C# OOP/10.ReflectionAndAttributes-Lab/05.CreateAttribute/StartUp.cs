using System.Reflection;

namespace AuthorProblem
{
    [Author("Victor")]
    public static class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            var traker = new Tracker();
            traker.PrintMethodsByAuthor();
        }

    }
}