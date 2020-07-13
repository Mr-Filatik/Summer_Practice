using AuktionEPAM.ENTITY;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    class All
    {

    }

    public interface ILotsManager
    {
        void AddLot(Lot lot);
        ICollection<Lot> SelectAllLots();
        ICollection<Lot> SelectMyLots(int id_user);
        void DeleteLot(int id_lot);
        void AddBindLot(int id_user, int number, int price);
        int GetCreator(int number);
        Lot SelectLot(int id_lot);

        int GetLog(string id);
        int GetPas(string log, string id);

    }


    public interface ILotsStorage
    {
        void AddLot(Lot lot);
        ICollection<Lot> SelectAllLots();
        ICollection<Lot> SelectMyLots(int id_user);
        void DeleteLot(int id_lot);
        void AddBindLot(int id_user, int number, int price);
        int GetCreator(int number);
        Lot SelectLot(int id_lot);

        int GetLog(string id);
        int GetPas(string log, string id);

    }
}
