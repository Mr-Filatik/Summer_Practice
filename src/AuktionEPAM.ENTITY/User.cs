using System;
using System.Collections.Generic;
using System.Text;

namespace AuktionEPAM.ENTITY
{
    public class User
    {
        public int Id_user { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public User() { }
    }
}
