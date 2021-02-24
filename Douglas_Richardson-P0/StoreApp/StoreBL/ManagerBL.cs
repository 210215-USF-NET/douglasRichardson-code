using StoreModels;
using StoreDL;
using System.Collections.Generic;
namespace StoreBL
{
    public class ManagerBL : IManagerBL
    {

        private IManagerRepo iManagerRepo;
        public ManagerBL(IManagerRepo newIManagerRepo){
            iManagerRepo = newIManagerRepo;
        }
        public void AddNewManager(Manager Manager){
            //TODO: check if email exists
            List<Manager> newList = GetManagers();
            int newManagerID = newList.Count + 1;
            Manager.ManagerID = newManagerID;
            iManagerRepo.AddNewManager(Manager);
        }
        public List<Manager> GetManagers(){
            return iManagerRepo.GetManagers();
        }

        public Manager FindManagerOnEmail(string emailAddress){
            List<Manager> theseManagers = GetManagers();
            foreach (Manager m in theseManagers)
            {
                if(m.EmailAddress.Equals(emailAddress)){
                    return m;
                }
            }
            return null; 
        }
    }
}