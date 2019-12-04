using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrazsasLista
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ListaElem<int> elso = new ListaElem<int>();
            elso.adat = 10;

            ListaElem<int> masodik = new ListaElem<int>();
            masodik.adat = 15;
            elso.kov = masodik;

            ListaElem<int> harmadik = new ListaElem<int>();
            harmadik.adat = 23;
            masodik.kov = harmadik;

            /*Console.WriteLine(elso.adat);
            Console.WriteLine(elso.kov.adat);
            Console.WriteLine(elso.kov.kov.adat);*/

            StrazssLista<int> lista = new StrazssLista<int>();
            lista.add(32);
            lista.add(42);
            lista.add(11);
            lista.add(12);
            lista.add(13);
            lista.add(14);
            lista.add(15);
            lista.add(16);
            lista.ForEach(Console.WriteLine);

            lista.remove(14);
            lista.remove(16);
            lista.remove(32);

            lista.removeAt(0);
            lista.removeAt(5);
           
            lista.insert(10, 0);
            lista.insert(99, 1);
            lista.insert(55, 0);
            
            lista.removeAt(7);

            Console.WriteLine();
            lista.ForEach(Console.WriteLine);

            Console.WriteLine(lista.contains(15));
            Console.WriteLine(lista.contains(55));
            Console.WriteLine(lista.contains(13));
            Console.WriteLine(lista.contains(16));


            Console.ReadLine();
        }
    }
}
