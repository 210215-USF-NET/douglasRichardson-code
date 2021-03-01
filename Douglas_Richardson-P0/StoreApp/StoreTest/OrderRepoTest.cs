using Xunit;
using Microsoft.EntityFrameworkCore;
using ToHDL;
using Entity = StoreDL.Entities;
using Model = StoreModels;
using System.Linq;
namespace StoreTest
{
    /// <summary>
    /// Testing the Order db repo
    /// </summary>
    public class OrderRepoTest
    {
        private readonly DbContextOptions<Entity.P0DatabaseContext> options;
        public HeroRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<Entity.HeroDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }

        private void Seed(){
            using (var context = new Entity.P0DatabaseContext(options))
            {
                //This makes sure that the state of the db gets recreated every time to maintain the modularity of the tests.
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //context.LocationTable
            }
        }
    }
}