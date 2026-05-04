using ShopManager_Markov.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using Schema = System.ComponentModel.DataAnnotations.Schema;

namespace ShopManager_Markov.Models
{
    public class Product : Notification
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("Название должно быть не более 100 символов!", "Ошибка");
                else
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    MessageBox.Show("Цена не может быть отрицательной!", "Ошибка");
                else
                {
                    price = value;
                    OnPropertyChanged("Price");
                    OnPropertyChanged("PriceText");
                }
            }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 0)
                    MessageBox.Show("Количество не может быть отрицательным!", "Ошибка");
                else
                {
                    stock = value;
                    OnPropertyChanged("Stock");
                }
            }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        [Schema.NotMapped]
        private bool isEnable;
        [Schema.NotMapped]
        public bool IsEnable
        {
            get { return isEnable; }
            set
            {
                isEnable = value;
                OnPropertyChanged("IsEnable");
                OnPropertyChanged("IsEnableText");
            }
        }

        [Schema.NotMapped]
        public string IsEnableText
        {
            get { return IsEnable ? "Сохранить" : "Изменить"; }
        }

        [Schema.NotMapped]
        public string PriceText
        {
            get { return $"{Price:C}"; }
        }

        [Schema.NotMapped]
        public RelayCommand OnEdit
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    IsEnable = !IsEnable;
                    if (!IsEnable)
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_products.productsContext.SaveChanges();
                });
            }
        }

        [Schema.NotMapped]
        public RelayCommand OnDelete
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    if (MessageBox.Show("Удалить этот товар?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_products.Products.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_products.productsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_products.productsContext.SaveChanges();
                    }
                });
            }
        }
    }
}
