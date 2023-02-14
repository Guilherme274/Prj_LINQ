using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AluraTunes1
{
     class Program
    {
        static void Main(string[] args)
        {
            XElement root = XElement.Load(@"Data\Automoveis.xml");


            var queryXML =
                from f in root.Elements("Fabricantes").Elements("Fabricante")
                select f;


            foreach ( var fabricante in queryXML ) 
            {
                Console.WriteLine("{0}", fabricante.Element("Nome").Value );
            }



            var query = from f in root.Element("Fabricantes").Elements("Fabricante")
                        join m in root.Element("Modelos").Elements("Modelo")
                        on f.Element("FabricanteId").Value equals m.Element("ModeloId").Value
                        select new
                        {
                            Modelo = m.Element("Nome").Value,
                            Fabricante = f.Element("Nome").Value

                        };

            Console.WriteLine();


            foreach (var fabricanteEmodelo in query)
            {
                Console.WriteLine("{0}\t{1}", fabricanteEmodelo.Modelo, fabricanteEmodelo.Fabricante) ;
            }


            Console.ReadKey();

        }

        

    }
}
