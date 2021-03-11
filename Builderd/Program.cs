using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builderd
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            director.GenerateProduct(builder);
            var model = builder.GetModel();
            Console.WriteLine(model.Id);
            Console.WriteLine(model.Discount);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);

            Console.ReadLine();


        }
    }

    internal class director
    {
        internal static void GenerateProduct(NewCustomerProductBuilder builder)
        {
            throw new NotImplementedException();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();

        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void ApplyDiscount()
        {
            model.Discount = model.UnitPrice *(decimal) 0.90;
            model.DiscountApplied = true;

        }

        public override ProductViewModel GetModel()
        {
            throw new NotImplementedException();
        }

        public override void GetProductData()
        {

            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        class OldCustomerProductBuilder : ProductBuilder
        {
            ProductViewModel model = new ProductViewModel();
            public override void ApplyDiscount()
            {
                model.Discount = model.UnitPrice * (decimal)0.90;
                model.DiscountApplied = false;

            }

            public override ProductViewModel GetModel()
            {
                return model;
            }

            public override void GetProductData()
            {
                model.Id = 1;
                model.CategoryName = "Beverages";
                model.ProductName = "Chai";
                model.UnitPrice = 20;

            }
        }


    }

     class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
