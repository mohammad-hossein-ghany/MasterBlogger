﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Infrastructure_Query
{
    public class ArticleQueryView
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ArticleCategory { get; set; }
        public string CreationDate { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public long CommentsCount { get; set; }
        public List<CommentQueryView> Comments { get; set; }
    }
}
