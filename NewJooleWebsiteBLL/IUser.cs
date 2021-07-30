using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewJooleWebsiteRepo;
using System.Data.Entity;
using System.Threading.Tasks;
using NewJooleWebsiteEntities;


namespace NewJooleWebsiteBLL
{
    public interface IUser : IQuery<tblUser>
    {

    }
    public class IUserClass : IUser
    {
        private DbContext context;
        private IDbSet<tblUser> userTbl => context.Set<tblUser>();
        public IQueryable<tblUser> Entities => context.Set<tblUser>();

        public tblUser Find(string ID)
        {
            var thisID = userTbl.Find(ID);
            return thisID;
        }

        public IUserClass(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<tblUser> find(tblUser c)
        {
            var result = userTbl.Where(p => p.User_Name == c.User_Name || p.User_Email == c.User_Email);

            return result;

        }

        public tblUser Find(int v)
        {
            return userTbl.Find(v);
        }

        public void remove(tblUser tb)
        {
        }

        public string Search(string s)
        {
            return null;
        }



    }
}