﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId); // categoryId'ye göre sonuç alacağımız için 
                                          // tek bir Category döndürecek
    }
}
