using SquareRoots.Core.Interfaces;
using SquareRoots.Factories.Interfaces;
using SquareRoots.IO.Interfaces;
using SquareRoots.Models;

namespace SquareRoots.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ISquqreRootFactory squareRootFactory;

        public Engine(IReader reader, IWriter writer, ISquqreRootFactory squareRootFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.squareRootFactory = squareRootFactory;

        }

        public void Run()
        {
            int number = int.Parse(reader.ReadLine());

            try
            {
                var squareRoot = squareRootFactory.Create(number) as SquareRoot;

                writer.WriteLine(squareRoot.GetSquareRoot().ToString());

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
