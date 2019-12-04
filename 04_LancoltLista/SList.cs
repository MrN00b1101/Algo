using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LancoltLista
{
    /* A ListaElem-et és ezt generikussá tenni.
    * tehát használhatom így is: LancoltLista<string> = new LancoltLista<string>();
    * 
    * Műveletek:
    * - Törlés adott pozíción
    * - Contains(érték) megvalósítása (szerepel-e az érték benne, vagy sem)
    * 
    * STRÁZSÁS LISTA:
    * - Ő is legyen generikus
     * 
    * - Ugyanezeket a műveleteket + a fentieket megvalósítani
    * - Contains változik: strázsával oldjuk meg
    * */
    class SList<Type>
    {
        public ListaElem<Type> Fej;
        public ListaElem<Type> Strazsa;

        public void Add(Type adat)
        {
            this.Strazsa.adat = adat;
            ListaElem<Type> newStrasza = new ListaElem<Type>();
            this.Strazsa.kov = newStrasza;
        }
        public void Remove(Type adat)
        {
        }
        public void removeAt(int index)
        {
        }
        public bool contains(Type adat)
        {
            return false;
        }
        public void insert(Type adat, int index)
        {
        }
        public void ForEach(Action<Type> action)
        {
            if (this.Fej != this.Strazsa)
            {
                ListaElem<Type> akt = this.Fej;
                while (akt != null)
                {
                    action(akt.adat);
                    akt = akt.kov;
                }
            }
        }

    }
}
