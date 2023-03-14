using SquareRoots.Core.Interfaces;
using SquareRoots.Factories.Interfaces;
using SquareRoots.IO.Interfaces;
using SquareRoots.Models.Interfaces;

namespace SquareRoots.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ISquqreRootFactory squareRootFactory;

        private readonly ICollection<ISquareRoot> squareRoots;
        public Engine(IReader reader, IWriter writer, ISquqreRootFactory squareRootFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.squareRootFactory = squareRootFactory;

            squareRoots = new List<ISquareRoot>();
        }

        public void Run()
        {
            int number = int.Parse(reader.ReadLine());

            try
            {
                squareRootFactory.Create(number);
                squareRoots.Add(squareRootFactory.Create(number));

                double result = squareRoots.First().GetSquareRoot();
                writer.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {

                writer.WriteLine(ex.Message);
            }
            finally
            {
                writer.WriteLine("Goodbye.");
            }
        }
    }
}
