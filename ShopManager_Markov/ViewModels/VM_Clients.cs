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
    public class VM_Clients : Notification
    {
        public ClientsContext clientsContext = new ClientsContext();
        public ObservableCollection<Client> Clients { get; set; }

        public VM_Clients() => Clients = new ObservableCollection<Client>(clientsContext.Clients.OrderBy(x => x.FullName));

        public RelayCommand OnAddClient
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Client NewClient = new Client()
                    {
                        FullName = "Новый клиент",
                        Phone = "",
                        Email = "",
                        Address = "",
                        TotalPurchases = 0,
                        IsEnable = true
                    };
                    Clients.Add(NewClient);
                    clientsContext.Clients.Add(NewClient);
                    clientsContext.SaveChanges();
                });
            }
        }
    }
}
