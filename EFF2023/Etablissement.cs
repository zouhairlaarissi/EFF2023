using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFF2023
{
    public class Etablissement
    {
        public int Code { get; set; }
        public string Nom { get; set; }
        public string Ville { get; set; }

        // Constructor with parameters  
        public Etablissement(int code, string nom, string ville)
        {
            Code = code;
            Nom = nom;
            Ville = ville;
        }

        // Default constructor  
        public Etablissement() { }
    }

}