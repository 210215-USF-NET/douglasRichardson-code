using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IManagerRepo
    {
         public void AddNewManager(Manager Manager);
         //getManagers is for putting all the Managers into a list and resaving them into the json file
        List<Manager> GetManagers();

    }
}