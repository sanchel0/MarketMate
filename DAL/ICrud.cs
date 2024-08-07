﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICrud<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
        T GetById(string id);
        List<T> GetAll();
        //List<T> GetAll(params IList[] parametros);
    }
}
