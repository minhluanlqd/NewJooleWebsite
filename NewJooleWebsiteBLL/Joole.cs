using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace NewJooleWebsiteBLL
{
    public interface IJoole
    {
        IUser users { get; }
    }
    public class Joole
    {
        private DbContext context;

        public Joole(DbContext context)
        {
            this.context = context;
        }
        public IUser users => new IUserClass(context);
    }
}