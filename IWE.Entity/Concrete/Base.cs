﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWE.Entity.Concrete
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string WhoCreated { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
        public string WhoUpdated { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public bool Status { get; set; }
    }
}