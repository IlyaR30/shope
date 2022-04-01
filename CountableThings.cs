namespace ConsoleApp2
{
    public class CountableThings
    {
        private string name;
        public int amount;
        private int price;
        public string Name
        {
            get => name;
            init => name = value;
        }
        public int Price
        {
            get => price;
            init => price = value;
        }

        public CountableThings(string name, int amount, int price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;
           

        }
        public void Remove(int count)
        {
            amount = (count < amount) ? amount - count : 0;
        }
        public void ToAdd(int count)
        {
            amount += count;
        }
        public int ToCost(int count) { return price*count; }
    }
}
