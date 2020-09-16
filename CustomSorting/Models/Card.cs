namespace CustomSorting
{
    public class Card
    {
        public Card(string value, string suit)
        {
            this.Value = value;
            this.Suit = suit;
        }

        public string DisplayName
        {
            get
            {
                return Value + " of " + Suit;
            }
        }

        public string Value { get; set; }

        public string Suit { get; set; }

        public int ValueSortNumber
        {
            get
            {
                switch (Value.ToLower())
                {
                    case "2":
                        return 0;

                    case "3":
                        return 1;

                    case "4":
                        return 2;

                    case "5":
                        return 3;

                    case "6":
                        return 4;

                    case "7":
                        return 5;

                    case "8":
                        return 6;

                    case "9":
                        return 7;

                    case "10":
                        return 8;

                    case "jack":
                        return 9;

                    case "queen":
                        return 10;

                    case "king":
                        return 11;

                    case "ace":
                        return 12;

                    default:
                        return 100;
                }
            }
        }

        public int SuitSortNumber
        {
            get
            {
                switch (Suit.ToLower())
                {
                    case "hearts":
                        return 0;

                    case "diamonds":
                        return 1;

                    case "clubs":
                        return 2;

                    case "spades":
                        return 3;

                    default:
                        return 100;
                }
            }
        }
    }
}