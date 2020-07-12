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
        public User Creator { get; set; }
        // 1 убрать кто последний поставил на покупку (отдельную функцию для этого)
        // 3 отдельно доставать имена пользователей (желательно)
        // 4 юзеров отдельной сущностью
        // 5 вынести инттерфейсы в отдельные проекты bll.interface и для dal 
        // 6 сделать повышение цены на лоты

        /*public int Finish_price { get; set; }
        public DateTime Finish_time { get; set; }
        public string Name_1 { get; set; }
        public string Surname_1 { get; set; }
        public string Name_2 { get; set; }
        public string Surname_2 { get; set; }
        */
        public Lot() { }

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

            /*Finish_price = price;
            Finish_time = start_time;
            Name_1 = null;
            Surname_1 = null;
            Name_2 = null;
            Surname_2 = null;*/
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
            /*Finish_price = p;
            Finish_time = s;
            Name_1 = n1;
            Surname_1 = sn1;
            Name_2 = n2;
            Surname_2 = sn2;*/
    }
    }
}
