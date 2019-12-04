using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrazsasLista
{
    class StrazssLista<Type>
    {

        public ListaElem<Type> Fej;
        public ListaElem<Type> Strazsa;
        public StrazssLista()
        {
            this.Fej = new ListaElem<Type>();
            this.Strazsa = new ListaElem<Type>();
            this.Fej.kov = this.Strazsa;
            this.Strazsa.kov = null;
        }
        
        public void add(Type adat) {
            ListaElem<Type> ujElem = new ListaElem<Type>();
            
            if (this.Fej.kov == this.Strazsa)
            {
                ujElem.adat = adat;
                this.Fej.kov = ujElem;
                ujElem.kov = this.Strazsa;
                
                
            }
            else
            {
                this.Strazsa.adat = adat;
                this.Strazsa.kov = ujElem;
                ujElem.kov = null;
                this.Strazsa = ujElem;
            }
        }
        public void insert(Type adat, int index)
        {
            index++; //Mivel itt a fej elemben nem tárolok semmit, azzal csak meghatározom a Lista első elemét, így ez a lista 1-től indexel! Mivel a megszokás szerint az indexelés 0tól történik ezért a kapott indexet plusszolom, hogy kimaradjon a Fej elem! 
            ListaElem<Type> ujElem = new ListaElem<Type>();
            ujElem.adat = adat;
            if (this.Fej != this.Strazsa)
            {
                ListaElem<Type> akt = this.Fej;
                int szamlalo = 0;
                while (akt.kov != this.Strazsa && szamlalo < index - 1)
                {
                    akt = akt.kov;
                    szamlalo++;
                }
                if (szamlalo == index - 1)
                {
                    
                    ujElem.kov = akt.kov;
                    akt.kov = ujElem;
                }
            }
            else
            {
                this.Fej = ujElem;
                this.Fej.kov = this.Strazsa;
            }
        }
        public void remove(Type adat)
        {
            if (this.Fej != this.Strazsa)
            {
               
                    ListaElem<Type> akt = this.Fej;
                    int szamlalo = 0;
                    while (akt.kov != this.Strazsa && !akt.kov.adat.Equals(adat))
                    {
                        akt = akt.kov;
                        szamlalo++;
                    }
                    if (akt.kov.adat.Equals(adat))
                    {
                        akt.kov = akt.kov.kov;
                    }
                
            }
        }
        public void removeAt(int index)
        {
            index++; //Mivel itt a fej elemben nem tárolok semmit, azzal csak meghatározom a Lista első elemét, így ez a lista 1-től indexel! Mivel a megszokás szerint az indexelés 0tól történik ezért a kapott indexet plusszolom, hogy kimaradjon a Fej elem! 

            if (this.Fej != this.Strazsa) 
            {
               
                    ListaElem<Type> akt = this.Fej;
                    int szamlalo = 0;
                    while (akt.kov != this.Strazsa && szamlalo < index - 1)
                    {
                        akt = akt.kov;
                        szamlalo++;
                    }
                    if (szamlalo == index - 1)
                    {
                        if (akt.kov == this.Strazsa)
                        {
                            akt.kov = this.Strazsa;
                        }
                        else
                        {
                            akt.kov = akt.kov.kov;
                        }
                    }
                
            }
        }
        public bool contains(Type adat) 
        {
            ListaElem<Type> akt = this.Fej;
            while (akt!= this.Strazsa)
            {
                if (akt.adat.Equals(adat)) return true;
                akt = akt.kov;
            }
            return false;
        }
        public void ForEach(Action<Type> action)
        {
            if (this.Fej != null)
            {
                ListaElem<Type> akt = this.Fej;
                while (akt.kov != this.Strazsa)
                {
                    akt = akt.kov;
                    action(akt.adat);
                    
                }
            }
        }

    }
}
