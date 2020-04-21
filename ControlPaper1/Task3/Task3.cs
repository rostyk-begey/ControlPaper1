using System;
using System.Reflection;
using Microsoft.VisualBasic;

namespace ControlPaper1.Task3
{
    interface IBuyable
    {
        public double GetPrice();
    }
    public abstract class ProductOrService : IBuyable
    {
        protected String title;
        
        public ProductOrService(string title)
        {
            this.title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public virtual string Title
        {
            get => title;
            set => title = value;
        }

        public override string ToString()
        {
            return title;
        }

        public virtual double GetPrice()
        {
            throw new NotImplementedException();
        }
    }

    public class PieceProduct : ProductOrService
    {
        private int count;
        private double pricePerItem;

        public PieceProduct(string title, double pricePerItem, int count = 1) : base(title)
        {
            this.pricePerItem = pricePerItem;
            this.count = count;
        }

        public double PricePerItem
        {
            get => pricePerItem;
            private set => pricePerItem = value;
        }

        public int Count
        {
            get => count;
            private set => count = value;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("({0})", pricePerItem);
        }

        public override double GetPrice()
        {
            return count * pricePerItem;
        }
    }

    public class WeightProduct : ProductOrService
    {
        private double weight;
        private double pricePerKg;

        public WeightProduct(string title, double pricePerKg, double weight) : base(title)
        {
            this.pricePerKg = pricePerKg;
            this.weight = weight;
        }

        public double PricePerKg
        {
            get => pricePerKg;
            private set => pricePerKg = value;
        }

        public override string ToString()
        {
            return base.ToString() + String.Format("({0})", pricePerKg);
        }

        public override double GetPrice()
        {
            return weight * pricePerKg;
        }
    }

    public class Service : ProductOrService
    {
        private double price;

        public Service(string title, double price) : base(title)
        {
            this.price = price;
        }

        public double Price
        {
            get => price;
            private set => price = value;
        }

        public override string ToString()
        {
            return base.ToString() + Strings.Format("({0})", price.ToString());
        }

        public override double GetPrice()
        {
            return price;
        }
    }

    public class BonusCard : ProductOrService
    {
        private double weightProductPercent;
        private double pieceProductPercent;
        private double servicePercent;
        private double price;
        private double bonusCount = 0.0;

        public BonusCard(string title, double price = 0, double weightProductPercent = 0.0, double pieceProductPercent = 0.0, double servicePercent = 0.0) : base(title)
        {
            this.weightProductPercent = weightProductPercent;
            this.pieceProductPercent = pieceProductPercent;
            this.servicePercent = servicePercent;
            this.price = price;
        }

        public override double GetPrice()
        {
            return price;
        }

        public double GetPriceWithDiscount(ProductOrService item)
        {
            double itemPrice = item.GetPrice();
            double discountPercent = 0.0;
            if (item is PieceProduct) discountPercent = pieceProductPercent;
            else if (item is WeightProduct) discountPercent = weightProductPercent;
            else if (item is Service) discountPercent = servicePercent;
            bonusCount += (itemPrice * discountPercent) / 100;
            return itemPrice - (itemPrice * discountPercent) / 100;
        }

        public double BonusCount
        {
            get => bonusCount;
            private set => bonusCount = value;
        }

        public override string ToString()
        {
            return String.Format("BonusCard({0}) bonuses: {1}", title, bonusCount);
        }
    }
    
    public static class Task3
    {
        public static void Run()
        {
            Console.WriteLine("--- TASK 1 ---");
            ProductOrService[] productsAndServices = new ProductOrService[]
            {
                new PieceProduct("PieceProduct 1", 10), 
                new PieceProduct("PieceProduct 1", 20, 2),
                new WeightProduct("WeightProduct 1", 30, 1), 
                new WeightProduct("WeightProduct 1", 40, 3), 
                new Service("Service 1", 10), 
                new Service("Service 1", 10), 
            };
            
            var bonusCard = new BonusCard("Bonus card 1", 0, 1, 2, 3);

            double totalPrice = 0.0;
            
            foreach (var item in productsAndServices)
            {
                totalPrice += bonusCard.GetPriceWithDiscount(item);
            }
            Console.WriteLine("Total price: {0}, Bonuses: {1}", totalPrice, bonusCard.BonusCount);
            Console.WriteLine("=== END TASK 2 ===");
        }
    }
}