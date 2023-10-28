using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab1.Model
{
    public class User 
    {
        public User(int id, string name, string lastname, string? email)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string? Email { get; set; }

        public string FullName => $"{Name} {Lastname}";
    }
  
    

}