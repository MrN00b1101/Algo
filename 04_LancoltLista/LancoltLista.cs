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
     * - Ugyanezeket a műveleteket + a fentieket megvalósítani
     * - Contains változik: strázsával oldjuk meg
     * */
    class LancoltLista<Type>
    {
        public ListaElem<Type> Fej;

        public void Add(Type adat)
        {
            if (this.Fej == null)
            {
                this.Fej = new ListaElem<Type>();
                this.Fej.adat = adat;
            }
            else
            {
                ListaElem<Type> akt = this.Fej;
                while (akt.kov != null)
                {
                    akt = akt.kov; // LÉPTETÉS
                }
                
                akt.kov = new ListaElem<Type>();
                akt.kov.adat = adat;
            }
        }

        public void Remove(Type adat)
        {
            if (this.Fej != null)
            {
                if (this.Fej.adat.Equals(adat))
                {
                    this.Fej = this.Fej.kov;
                }
                else
                {
                    ListaElem<Type> akt = this.Fej;
                    while (akt.kov != null && !akt.kov.adat.Equals(adat))
                    {
                        akt = akt.kov;
                    }

                    if (akt.kov != null)
                    {
                        akt.kov = akt.kov.kov;
                    }
                }
            }
        }
        public void RemoveAt(int index)
        {
            if (this.Fej != null)
            {
                if(index == 0)
                {
                    this.Fej = this.Fej.kov;
                }else
                {
                    ListaElem<Type> akt = this.Fej;
                    int szamlalo = 0;
                    while (akt != null && szamlalo < index - 1)
                    {
                        akt = akt.kov;
                        szamlalo++;  
                    }
                    if (akt.kov != null)
                    {
                        akt.kov = akt.kov.kov;
                    }
                    
                }
            }
        }
        public bool contains(Type adat)
        {
            ListaElem<Type> akt = this.Fej;
            while (akt != null)
            {
                if (akt.adat.Equals(adat)) return true;
                akt = akt.kov;
            }
            return false;
        }
        public void Insert(Type adat, int index)
        {
            if (this.Fej != null)
            {
                if (index == 0)
                {
                    ListaElem<Type> uj = new ListaElem<Type>();
                    uj.adat = adat;
                    uj.kov = this.Fej;
                    this.Fej = uj;
                }
                else
                {
                    ListaElem<Type> akt = this.Fej;
                    int szamlalo = 0;
                    while (akt.kov != null && szamlalo < index - 1)
                    {
                        akt = akt.kov;
                        szamlalo++;
                    }

                    ListaElem<Type> uj = new ListaElem<Type>();
                    uj.adat = adat;
                    uj.kov = akt.kov;
                    akt.kov = uj;
                }
            }
            else if (index == 0)
            {
                this.Fej = new ListaElem<Type>();
                this.Fej.adat = adat;
            }
        }

        public void ForEach(Action<Type> action)
        {
            if (this.Fej != null)
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
