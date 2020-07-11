using System;
using System.Collections.Generic;
using System.Text;

namespace AuktionEPAM.ENTITY
{
    public class Lot
    {
        public int Id_lot { get; set; }
        public int Id_creator { get; set; }
        public string Name { get; set; }
        public int Start_price { get; set; }
        public DateTime Start_time { get; set; }
        public bool Status { get; set; }

        public int Finish_price { get; set; }
        public DateTime Finish_time { get; set; }
        public string Name_1 { get; set; }
        public string Surname_1 { get; set; }
        public string Name_2 { get; set; }
        public string Surname_2 { get; set; }

        public Lot(int id_lot, 
                   int id_creator, 
                   string name, 
                   int price, 
                   DateTime start_time, 
                   bool status)
        {
            Id_lot = id_lot;
            Id_creator = id_creator;
            Name = name;
            Start_price = price;
            Start_time = start_time;
            Status = status;
        }

        public Lot(int id_lot, 
                   int id_creator, 
                   string name, 
                   int price, 
                   DateTime start_time, 
                   bool status, 
                   int p, 
                   DateTime s, 
                   string n1, 
                   string sn1, 
                   string n2, 
                   string sn2)
        {
            Id_lot = id_lot;
            Id_creator = id_creator;
            Name = name;
            Start_price = price;
            Start_time = start_time;
            Status = status;
            Finish_price = p;
            Finish_time = s;
            Name_1 = n1;
            Surname_1 = sn1;
            Name_2 = n2;
            Surname_2 = sn2;
    }
    }
}
