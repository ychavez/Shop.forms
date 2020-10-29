using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var mGeneric = new Generico<string[], decimal>();

            string[] generico = mGeneric.PropiedadGenerica;

            decimal generico2 = mGeneric.PropiedadGenerica2;

            var x = mGeneric.GetElements<string>("asdf");

        }
    }
}
