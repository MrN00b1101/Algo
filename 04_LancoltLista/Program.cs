using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LancoltLista
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

            Console.WriteLine(elso.adat);
            Console.WriteLine(elso.kov.adat);
            Console.WriteLine(elso.kov.kov.adat);

            LancoltLista<int> lista = new LancoltLista<int>();
            lista.Add(32);
            lista.Add(42);
            lista.Add(11);
            
            // Bejárás:
            //ListaElem<int> akt = lista.Fej;
            //while (akt != null)
            //{
            //    Console.WriteLine(akt.adat);
            //    akt = akt.kov;
            //}

            // ...vagy:

            lista.ForEach((adat) =>
            {
                Console.WriteLine(adat);
            });

            Console.WriteLine();
            lista.Insert(10, 0);
            lista.Insert(99, 1);
            lista.Insert(55, 0);
            lista.ForEach(Console.WriteLine);
            Console.WriteLine();
            lista.RemoveAt(2);
            lista.ForEach(Console.WriteLine);
            Console.WriteLine(lista.contains(11));
            Console.ReadLine();
 
        }
    }
}
