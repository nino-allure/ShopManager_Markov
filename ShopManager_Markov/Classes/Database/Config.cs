using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShopManager_Markov.Classes.Database
{
    public class Config
    {
        public static readonly string connection = "server=localhost;" +
            "uid=root;" + "pwd=;" + "database=ShopManager;";

        public static readonly MySqlServerVersion version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
