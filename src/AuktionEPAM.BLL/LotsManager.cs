using AuktionEPAM.DAL;
using AuktionEPAM.ENTITY;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuktionEPAM.BLL
{
    public class ILotsManager : Interfaces.ILotsManager
    {
        public static ILotsStorage iLotStorage;
        
        public void AddLot(Lot lot)
        {
            iLotStorage.AddLot(lot);
        }
        public void DeleteLot(int number)
        {
            iLotStorage.DeleteLot(number);
        }
        public ICollection<Lot> SelectAllLots()
        {
            return iLotStorage.SelectAllLots();
        }

        public ILotsManager()
        {
            iLotStorage = new LotsStorage();
        }
    }
}
