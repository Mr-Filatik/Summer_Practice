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
        void DeleteLot(int id_lot);
    }

    public interface ILotsStorage
    {
        void AddLot(Lot shop);
        ICollection<Lot> SelectAllLots();
        void DeleteLot(int id_lot);
    }
}
