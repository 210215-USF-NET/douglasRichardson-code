﻿using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StoreDL
{
    /// <summary>
    /// Creates new products on the database
    /// </summary>
    public class ProductRepo
    {
        private Entity.P0DatabaseContext context;
        private Mapper.ProductMapper mapper; 
        public ProductRepo(Entity.P0DatabaseContext context, Mapper.ProductMapper mapper){
            this.mapper = mapper;
            this.context = context;
        }
        public void AddNewProduct(Model.Product Product)
        {
            context.Products.Add(mapper.ParseProduct(Product));
            context.SaveChanges();
        }

        public List<Model.Product> GetProducts()
        {
           return context.Products.Select(x => mapper.ParseProduct(x)).ToList();
        }

    }//class
}
