using ShopManager_Markov.Classes;
using ShopManager_Markov.Context;
using ShopManager_Markov.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ShopManager_Markov.ViewModels
{
    public class VM_Products : Notification
    {
        public ProductsContext productsContext = new ProductsContext();
        public ObservableCollection<Product> Products { get; set; }

        public VM_Products() => Products = new ObservableCollection<Product>(productsContext.Products.OrderBy(x => x.Name));

        public RelayCommand OnAddProduct
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Product NewProduct = new Product()
                    {
                        Name = "Новый товар",
                        Price = 0,
                        Stock = 0,
                        Category = "",
                        Description = "",
                        IsEnable = true
                    };
                    Products.Add(NewProduct);
                    productsContext.Products.Add(NewProduct);
                    productsContext.SaveChanges();
                });
            }
        }
    }
}
