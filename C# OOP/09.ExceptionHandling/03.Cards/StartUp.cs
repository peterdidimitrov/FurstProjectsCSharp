namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> listOfCards = new();
            string[] cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < cards.Length; i++)
            {
                string[] cardInfo = cards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var card = CreateCard(cardInfo[0], cardInfo[1]);
                if (card != null)
                {
                    listOfCards.Add(card);
                }
            }

            Console.WriteLine(string.Join(" ", listOfCards));

        }
        public static Card CreateCard(string face, string suit)
        {
            IReadOnlyCollection<string> validCardFaces = new HashSet<string>()
            { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            IReadOnlyCollection<string> validCardSuits = new HashSet<string>()
            { "S", "H", "D", "C" };
            Card card = null;
            try
            {
                if (!validCardFaces.Contains(face) || !validCardSuits.Contains(suit))
                {
                    throw new ArgumentException("Invalid card!");
                }
                else
                {
                    card = new Card(face, suit);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return card;

        }
    }
    public interface ICard
    {
        public string Face { get; }
        public string Suit { get; }
    }
    public class Card : ICard
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            private set
            {
                face = value;
            }
        }

        public string Suit
        {
            get { return suit; }
            private set
            {
                suit = value;
            }
        }

        public override string ToString()
        {

            switch (suit)
            {
                case "S":
                    suit = ("\u2660");
                    break;
                case "H":
                    suit = ("\u2665");
                    break;
                case "D":
                    suit = ("\u2666");
                    break;
                case "C":
                    suit = ("\u2663");
                    break;
            }

            return $"[{face}{suit}]";
        }
    }
}