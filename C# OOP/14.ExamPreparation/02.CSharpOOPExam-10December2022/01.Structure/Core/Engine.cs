namespace ChristmasPastryShop.Core
{
    using System;
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.IO;
    using ChristmasPastryShop.IO.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Repositories;

    public class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private IController controller;

        public Engine()
        {
            this.writer = new Writer();
            this.reader = new Reader();
            //this.controller = new Controller();
        }
        public void Run()
        {
            while (true)
            {
                string[] input = reader.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    //Gingerbread gingerbread = new Gingerbread("PEcho");
                    //Stolen stolen = new Stolen("Ep");

                    //MulledWine mulledWine = new MulledWine("Vino", "Middle");
                    //writer.WriteLine(gingerbread.ToString());
                    //writer.WriteLine(stolen.ToString());
                    //Booth booth = new Booth(12, 10);
                    //CocktailRepository cocktailRepository = new CocktailRepository();
                    //DelicacyRepository delicacyRepository = new DelicacyRepository();
                    //cocktailRepository.AddModel(mulledWine);
                    //delicacyRepository.AddModel(stolen);
                    //delicacyRepository.AddModel(gingerbread);

                    //writer.WriteLine(booth.ToString());

                    string result = string.Empty;

                    if (input[0] == "AddBooth")
                    {
                        int capacity = int.Parse(input[1]);

                        result = controller.AddBooth(capacity);
                    }
                    else if (input[0] == "AddDelicacy")
                    {
                        int boothId = int.Parse(input[1]);
                        string delicacyTypeName = input[2];
                        string delicacyName = input[3];

                        result = controller.AddDelicacy(boothId, delicacyTypeName, delicacyName);
                    }
                    else if (input[0] == "AddCocktail")
                    {
                        int boothId = int.Parse(input[1]);
                        string coctailTypeName = input[2];
                        string cocktailName = input[3];
                        string size = input[4];

                        result = controller.AddCocktail(boothId, coctailTypeName, cocktailName, size);
                    }
                    else if (input[0] == "ReserveBooth")
                    {
                        int countOfPeople = int.Parse(input[1]);

                        result = controller.ReserveBooth(countOfPeople);
                    }
                    else if (input[0] == "TryOrder")
                    {
                        int bootId = int.Parse(input[1]);
                        string order = input[2];

                        result = controller.TryOrder(bootId, order);
                    }
                    else if (input[0] == "LeaveBooth")
                    {
                        int boothId = int.Parse(input[1]);

                        result = controller.LeaveBooth(boothId);
                    }
                    else if (input[0] == "BoothReport")
                    {
                        int boothId = int.Parse(input[1]);

                        result = controller.BoothReport(boothId);
                    }

                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
