
using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace StoreDL
{
    /// <summary>
    /// Handles the creation of managers in the database
    /// </summary>
    public class ManagerRepo : IManagerRepo
    {
        private Entity.P0DatabaseContext context;
        private Mapper.ManagerMapper mapper; 
        public ManagerRepo(Entity.P0DatabaseContext context, Mapper.ManagerMapper mapper){
            this.mapper = mapper;
            this.context = context;
        }
        public void AddNewManager(Model.Manager manager)
        {
            context.Managers.Add(mapper.ParseManager(manager));
            context.SaveChanges();
        }

        public Model.Manager GetManagerByEmail(string email)
        {
            return context.Managers.Select(x => mapper.ParseManager(x)).ToList().FirstOrDefault(x => x.EmailAddress == email);
        }

        public List<Model.Manager> GetManagers()
        {
           return context.Managers.Select(x => mapper.ParseManager(x)).ToList();
        }

    }//class
}
