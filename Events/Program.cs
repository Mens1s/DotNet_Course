namespace Events
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Product hardDisk = new Product(50);
            hardDisk.ProductName = "hard disk";

            Product gsm = new Product(50);
            gsm.ProductName = "iPhone";
            gsm.StockControlEvent += Gsm_StockControlEvent;           
            
            for (int i = 0; i < 10; i++)
            {
                hardDisk.Sell(10);
                gsm.Sell(10);
                Console.ReadLine();
            }
        }
        private static void Gsm_StockControlEvent()
        {
            Console.WriteLine("GSM Amount is too less. Buy new one.");
        }
    }

    public delegate void StockControl();
    
    public class Product
    {
        private int _stock;
        
        public Product(int stock)
        {
            _stock = stock;
        }
        
        public event StockControl StockControlEvent;
        public String ProductName { get; set; }

        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
                if (value <= 15 && StockControlEvent != null)
                {
                    StockControlEvent();
                }
            }
        }

        public void Sell(int amount)
        {
            if (Stock < amount)
            {
                Console.WriteLine("Stock is empty.");
                return;
            }
            Stock -= amount;
            Console.WriteLine("Stock amount : {0}", _stock);
        }
    }
}