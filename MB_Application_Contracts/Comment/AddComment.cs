﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Application_Contracts.Comment
{
    public class AddComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public String Message { get; set; }
        public long ArticleId { get; set; }
    }
}
