using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NewJooleWebsiteRepo;
using NewJooleWebsiteEntities;

namespace NewJooleWebsiteBLL
{
    public interface UserInterface : Repo<tblUser>
    {

    }
    public class UserRepo : UserInterface
    {
        private DbContext context;

        
        public UserRepo(DbContext context)
        {
            this.context = context;
        }

        public IQueryable<tblUser> Entities => throw new NotImplementedException();

        private List<tblUser> dbSet => context.Set<tblUser>().ToList();

        public IQueryable<tblUser> DataSet(string s)
        {
            throw new NotImplementedException();
        }

        /*
         * this method will query through a given list and find a row based on either the username or email and return
         * the row to the user as IEnumerable<tblUser>
         * return: IEnumerable<tblUser> - rows for all the users that matches either the username or email
         * arg: take a tblUser
         */
        public IEnumerable<tblUser> find(tblUser c)
        {
            var filteredRows = dbSet.Where(p => p.User_Name == c.User_Name || p.User_Email == c.User_Email);

            return filteredRows;

        }


        //creates a new, unique id for a new user
        public string newID()
        {
            var x = dbSet.Count() + 1;
            var id = "userX" + x;
            return id;
        }



        public tblUser find(int v)
        {
            throw new NotImplementedException();
        }

        public tblUser Find(string v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblUser entity)
        {
            // dbSet.Find(entity);
        }

        public string Search(string s)
        {
            throw new NotImplementedException();
        }
    }
}