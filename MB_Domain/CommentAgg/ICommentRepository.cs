﻿using MB_Application_Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB_Domain.CommentAgg
{
    public interface ICommentRepository
    {
        void CreateAndSave(Comment Entity);
        List<CommentViewModel> GetList();
        Comment Get(long id);
        void Save();
    }
}
