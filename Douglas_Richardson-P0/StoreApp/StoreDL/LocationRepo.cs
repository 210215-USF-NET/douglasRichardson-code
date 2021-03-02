
using System;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using Mapper = StoreDL.Mappers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Serilog;
namespace StoreDL
{
    public class LocationRepo
    {
        private Entity.P0DatabaseContext context;
        private Mapper.LocationMapper mapper; 
        public LocationRepo(Entity.P0DatabaseContext context, Mapper.LocationMapper mapper){
            this.mapper = mapper;
            this.context = context;
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(@"ourLog.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        public void AddNewLocation(Model.Location location)
        {
            context.LocationTables.Add(mapper.ParseLocation(location));
            context.SaveChanges();
            Log.Information("New location was created. "+location.LocationName);
        }

        public List<Model.Location> GetLocations()
        {
            if(context.LocationTables.Any(x => x != null)){
                return context.LocationTables.Select(x => mapper.ParseLocation(x)).ToList();
            }else{
                return null;
            }
            
        }

    }//class
}
