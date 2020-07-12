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
        //private static int id_user = 1;
        
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
        public ICollection<Lot> SelectMyLots(int id_user)
        {
            return iLotStorage.SelectMyLots(id_user);
        }
        public void AddBindLot(int id_user, int number, int price)
        {
            iLotStorage.AddBindLot(id_user, number, price);
        }


        public ILotsManager()
        {
            iLotStorage = new LotsStorage();
        }
    }
}
