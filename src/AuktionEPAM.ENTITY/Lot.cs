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
        
        public Lot() { }
    }
}
