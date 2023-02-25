using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            //productDirector.GenerateProduct(new OldCustomerProductBuilder());
            var buider = new OldCustomerProductBuilder();
            productDirector.GenerateProduct(buider);
            var model = buider.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.DiscountApplied);
            Console.ReadLine();
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void AppliedDiscount();
        public abstract ProductViewModel GetModel();
    }

    class NewCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * 0.9m;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    class OldCustomerProductBuilder : ProductBuilder
    {
        private ProductViewModel model = new ProductViewModel();
        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverages";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void AppliedDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

     class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.AppliedDiscount();
        }
    }
}
