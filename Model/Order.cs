﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSellingSystem.Model
{
    public class Order
    {
        public int Id { get; set; }
        public SqlMoney Total { get; set; }
        public SqlDateTime DateTime { get; set; }
        public string Status { get; set; }

    }
}