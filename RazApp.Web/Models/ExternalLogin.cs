﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazApp.Web.Models
{
    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}