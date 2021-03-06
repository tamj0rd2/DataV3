﻿namespace DataV3.ViewModels
{
    using System;

    public abstract class BaseAuthorViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
