using System;

namespace Core_MVC_CRUD.Models.Entities.Abstract
{
    public enum Status { Active = 1, Modified = 2, Passive = 3 }
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        DateTime _createDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        Status _status = Status.Active;
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
