using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CustomSorting
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _staticList;
        private string _sortedList;
        private List<Card> _cardList;
        private List<Card> _sortedCardList;
        private bool _descendingIsChecked = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand SortCommand { get; set; }

        public string StaticList
        {
            get
            {
                return this._staticList;
            }

            set
            {
                this._staticList = value;
                this.OnPropertyChanged("StaticList");
            }
        }

        public string SortedList
        {
            get
            {
                return this._sortedList;
            }

            set
            {
                this._sortedList = value;
                this.OnPropertyChanged("SortedList");
            }
        }

        public bool DescendingIsChecked
        {
            get
            {
                return this._descendingIsChecked;
            }

            set
            {
                this._descendingIsChecked = value;
                this.OnPropertyChanged("DescendingIsChecked");
            }
        }

        public ViewModel()
        {
            this._cardList = this.GetCards();

            this._staticList = this.CreateStringList(this._cardList);

            this.SortCommand = new RelayCommand(this.Sort);
        }

        private void Sort(object parameter)
        {
            if (!this._descendingIsChecked)
            {
                this._sortedCardList = this._cardList.OrderBy(o => o.ValueSortNumber).ThenBy(t => t.SuitSortNumber).ToList();
            }
            else
            {
                this._sortedCardList = this._cardList.OrderByDescending(o => o.ValueSortNumber).ThenBy(t => t.SuitSortNumber).ToList();
            }

            this.SortedList = this.CreateStringList(this._sortedCardList);
        }

        private List<Card> GetCards()
        {
            List<Card> list = new List<Card>
            {
                new Card("King", "Diamonds"),
                new Card("2", "Hearts"),
                new Card("Jack", "Diamonds"),
                new Card("7", "Spades"),
                new Card("4", "Clubs"),
                new Card("6", "Diamonds"),
                new Card("Ace", "Spades"),
                new Card("3", "Clubs"),
                new Card("9", "Diamonds"),
                new Card("Queen", "Hearts")
            };

            return list;
        }

        private string CreateStringList(List<Card> cardList)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card card in cardList)
            {
                sb.Append(card.DisplayName + Environment.NewLine);
            }

            return sb.ToString();
        }

        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}