﻿using ExampleApp.Common.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleApp.Common.Models
{
    public class User : BaseDatabaseItem
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
    }
}
