﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NewJooleWebsiteRepo
{
    public interface Repo<T> where T : class
    {
        IEnumerable<T> find(T v);
        void remove(T entity);
        IQueryable<T> Entities { get; }
        T Find(string v);
        string Search(string s);
        IQueryable<T> DataSet(string s);
    }
}