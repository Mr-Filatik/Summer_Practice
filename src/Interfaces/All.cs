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
        ICollection<Lot> SelectMyLots();
        void DeleteLot(int id_lot);
    }

    public interface ILotsStorage
    {
        void AddLot(Lot lot);
        ICollection<Lot> SelectAllLots();
        ICollection<Lot> SelectMyLots(int id_user);
        void DeleteLot(int id_lot);
    }
}
