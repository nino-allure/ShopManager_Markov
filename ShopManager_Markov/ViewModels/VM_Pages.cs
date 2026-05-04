using ShopManager_Markov.Classes;
using ShopManager_Markov.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManager_Markov.ViewModels
{
    public class VM_Pages : Notification
    {
        public VM_Clients vm_clients = new VM_Clients();
        public VM_Products vm_products = new VM_Products();

        public VM_Pages()
        {
            MainWindow.init.frame.Navigate(new ClientsPage(vm_clients));
        }

        public RelayCommand OnClose
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.Close();
                });
            }
        }

        public RelayCommand OnShowClients
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new ClientsPage(vm_clients));
                });
            }
        }

        public RelayCommand OnShowProducts
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    MainWindow.init.frame.Navigate(new ProductsPage(vm_products));
                });
            }
        }
    }
}
