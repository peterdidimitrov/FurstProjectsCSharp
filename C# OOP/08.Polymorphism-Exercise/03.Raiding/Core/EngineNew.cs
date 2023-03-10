using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class EngineNew : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IHero> heroes;

        public EngineNew(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;

            heroes = new List<IHero>();
        }
        public void Run()
        {
            ProcessCommand();

            int bossPower = int.Parse(reader.ReadLine());

            foreach (var hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int totalPower = heroes.Sum(h => h.Power);
            if (bossPower <= totalPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }

        private void ProcessCommand()
        {
            int n = int.Parse(reader.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();

                try
                {
                    heroes.Add(heroFactory.Create(name, type));

                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}