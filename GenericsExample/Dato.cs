using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    public class Generico<T,TValue> where T :  notnull where TValue : struct 
    {

        public int PropiedadInt { get; set; }
        public T PropiedadGenerica { get; set; }

        public TValue PropiedadGenerica2 { get; set; }
        public List<string> MyProperty { get; set; }

        public Y GetElements<Y>(Y value) {

            return value;
        
        }

    

    }
}
