using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace NewJooleWebsiteRepo
{
    public interface IQuery<T> where T : class 
    {
        IEnumerable<T> find(T v);
        void remove(T entity);

        IQueryable<T> Entities { get; }
        T Find(int v);
        string Search(string s);
        //IQueryable<T> DataSet(string s);
    };
}