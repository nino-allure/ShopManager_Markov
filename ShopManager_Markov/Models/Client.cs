using System;
using System.Collections.Generic;
using System.Text;
using Schema = System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using ShopManager_Markov.Classes;
using System.Windows;

namespace ShopManager_Markov.Models
{
    public class Client : Notification
    {
        public int Id { get; set; }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                Match match = Regex.Match(value, "^.{1,100}$");
                if (!match.Success)
                    MessageBox.Show("ФИО слишком большое!", "Ошибка");
                else
                {
                    fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private decimal totalPurchases;
        public decimal TotalPurchases
        {
            get { return totalPurchases; }
            set
            {
                totalPurchases = value;
                OnPropertyChanged("TotalPurchases");
                OnPropertyChanged("TotalPurchasesText");
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
        public string TotalPurchasesText
        {
            get { return $"{TotalPurchases:C}"; }
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
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_clients.clientsContext.SaveChanges();
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
                    if (MessageBox.Show("Удалить этого клиента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_clients.Clients.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_clients.clientsContext.Remove(this);
                        (MainWindow.init.DataContext as ViewModels.VM_Pages).vm_clients.clientsContext.SaveChanges();
                    }
                });
            }
        }
    }
}
