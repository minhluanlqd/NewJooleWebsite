using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NewJooleWebsiteEntities;
using NewJooleWebsiteBLL;

namespace NewJooleWebsiteService
{
    public class Service
    {
        static string connectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=\"data source = (localdb)\\ProjectsV13;initial catalog = JooleWebsite.DAL; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework\"";
        static DbContext context = new DbContext(connectionString);
        Joole jul = new Joole(context);
        public bool confirm(string id, string pw)
        {
            List<tblUser> _userList = userList(id, pw);
            if (_userList.Count() > 0)
            {
                if (isEmail(id)&& _userList.First().User_Email == id && _userList.First().Password == pw)
                {
                    return true;
                }
                else if (_userList.First().User_Name == id && _userList.First().Password == pw)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        private bool isEmail(string loginName)
        {
            return (loginName.Contains("@"));
        }

        private List<tblUser> userList(string id, string pass)
        {
            tblUser temp = new tblUser();
            if (isEmail(id))
            {
                temp.User_Email = id;
            }
            else
            {
                temp.User_Name = pass;
            }
            temp.Password = pass;
            return jul.users.find(temp).ToList();
        }

        //get the ID of the current user
        public string getID(string id, string pass)
        {
            List<tblUser> idList = userList(id, pass);
            return idList.First().User_id;
        }

        //public string value()
        //{
        //    var a = jul.users.find(1);
        //    if (a.user_id != 0)
        //        return a.user_name;
        //    else
        //        return null;
        //}
    }
}