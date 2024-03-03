using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab3CSharp
{
    class Money
    {
        // Захищені поля
        private int _nominal;
        private int _num;
        public static int _count;
        // Конструктор
        public Money(int nominal, int num)
        {
            _nominal = nominal;
            _num = num;
            _count = nominal*num;
        }
        public static int Count
        {
            get { return _count; }
        }
        // Метод для виведення інформації
        public void DisplayInfo()
        {
            Console.WriteLine($"Nominal: {_nominal}, Count: {_num}");
        }

        // Метод для перевірки, чи вистачить грошей на покупку товару
        public static bool IsEnoughMoney(int amount)
        {
            return _count >= amount;
        }
        public bool IsEnoughMoneyThis(int amount)
        {
            return _nominal * _num >= amount;
        }

        // Метод для розрахунку кількості товару, яку можна купити на гроші
        public static int CalculateItemsToBuy(int amount)
        {
            if (IsEnoughMoney(amount))
            {
                return  _count / amount;
            }
            else
            {
                return 0;
            }
        }

        // Властивості для отримання і встановлення значень полів
        public int Nominal
        {
            get { return _nominal; }
            set {
                _count -= _nominal * _num;
                _count += value * _num;
                _nominal = value; }
        }

        public int Num
        {
            get { return _num; }
            set {
                _count -= _nominal * _num;
                _count += value * _nominal;
                _num = value; }
        }

        // Властивість для отримання суми грошей
        public int TotalAmount
        {
            get { return _nominal * _num; }
        }
    }


    class Goods
    {
        private string _name;
        private int _price;
        
        public Goods(string a, int b) {       
        _name = a;
        _price = b;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public void DisplayInfo() {
            Console.WriteLine(" " + _name + "   \t" + _price );
        
        }


    }
    internal class Program
    {
        public static void task1()
        {
            // Приклад використання класу Money
            Money[] moneyWallet = new Money[5];
            moneyWallet[0] = new Money(20, 43);
            moneyWallet[1] = new Money(10, 50);
            moneyWallet[2] = new Money(50, 2);
            moneyWallet[3] = new Money(100, 3);
            moneyWallet[4] = new Money(500, 4);

            // Виводимо інформацію про гаманець
            foreach (Money a in moneyWallet)
            {
                a.DisplayInfo();
            };
            Console.WriteLine("This was your money \n\n\n");

            Goods[] goods = new Goods[10];
            goods[0] = new Goods("Ananas", 53);
            goods[1] = new Goods("Forel(100g)", 40);
            goods[2] = new Goods("Aplle(fruit)", 10);
            goods[3] = new Goods("Chees(kg)", 200);
            goods[4] = new Goods("Milk(1L)", 10);
            goods[5] = new Goods("Bred(1 piece)", 22);
            goods[6] = new Goods("CocaCola(1L)", 30);
            goods[7] = new Goods("Fanta(1Ton(s))", 2405);
            goods[8] = new Goods("TV", 10000);
            goods[9] = new Goods("PowerGenerator", 100000);
            foreach (Goods a in goods)
            {
                a.DisplayInfo();
            }
            Console.WriteLine("This was goods we have \n\n\n");


            foreach (Goods b in goods)
            {
                if (Money.IsEnoughMoney(b.Price))
                {
                    Console.WriteLine($"You have enought money to bay {b.Name}, needed sum is {b.Price * Money.CalculateItemsToBuy(b.Price)} UAgrn to get {Money.CalculateItemsToBuy(b.Price)} pieces.");
                }
                else
                {
                    Console.WriteLine($"You have not enought money to bay {b.Name}, needed sum is {b.Price} UAgrn.");
                }

            }


            // Змінюємо кількість купюр у гаманці
            moneyWallet[3].Num = 28;
            moneyWallet[3].DisplayInfo();

            foreach (Goods b in goods)
            {
                if (Money.IsEnoughMoney(b.Price))
                {
                    Console.WriteLine($"You have enought money to bay {b.Name}, needed sum is {b.Price * Money.CalculateItemsToBuy(b.Price)} UAgrn to get {Money.CalculateItemsToBuy(b.Price)}.");
                }
                else
                {
                    Console.WriteLine($"You have not enought money to bay, needed sum is {b.Price} UAgrn.");
                }

            }
            // Виводимо загальну суму грошей у гаманці
            Console.WriteLine($"Total sum on vallet: {Money.Count} UAgrn.");
        }
        public static void task2()
        {
            Organization[] A = new Organization[3];
            A[0] = new Oil_Gas_Company("OilTrade", 2540, "Patrol", "Natural", 4, 5, 10);
            A[1] = new Oil_Gas_Company("OilManuf", 1140, "Dirt", "Blue", 3, 2, 4);
            A[2] = new Oil_Gas_Company("GasTrans", 440, "Dirt", "Green", 4, 6, 5);
            foreach (Organization a in A)
            {
                Console.WriteLine();
                a.Show();
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 ");
            task1();
            task2();


         
        }
    }
    }

 