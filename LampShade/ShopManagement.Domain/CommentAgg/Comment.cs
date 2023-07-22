﻿using _0_FrameWorkWork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        //public string Website { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        //public long OwnerRecordId { get; private set; }
        //public int Type { get; private set; }
        //public long ParentId { get; private set; }
        public long ProductId { get;private set; }
        //public Comment Parent { get; private set; }
        public Product Product { get; private set; }

        public Comment(string name, string email, string message, long productId)
        {
            Name = name;
            Email = email;
            Message = message;
            ProductId = productId;
        }


        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
