﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
