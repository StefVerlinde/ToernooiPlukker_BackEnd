﻿using System.Collections.Generic;
using ToernooiPlukkerAPI.DTOs;

namespace ToernooiPlukkerAPI.Models
{
    public interface IToernooiRepository
    {
        IEnumerable<ToernooiDTO> GetAll();
        Toernooi GetById(int id);
        IEnumerable<ToernooiDTO> GetByUserId(int id);
        void Add(Toernooi toernooi);
        void Delete(Toernooi toernooi);
        Toernooi Update(Toernooi toernooi);
        void SaveChanges();
    }
}