/*
 * Elternklasse
 * mit objektorientierter Fehlerbehandlung (throw())
 * und Polymorphie (abstrakte Klasse, Methoden)
 * Autor: LG
 * Erstellt: Mai 2023
 */

using System;

namespace Sem6_Polymorphie_PersonenKlassen_AV
{
    public enum Role 
    {
        Student = 0,
        Lecturer = 1,
        StaffMember = 2
    
    }

    public abstract class Person //abstract Class weil wir eine abstracte Methode haben
    {
        private string famName;
        Address adr;

        public Person()
        {
            famName = "not Assigned!";
            adr = new Address();
        }
       
        public Person(string famName, Address adr)
        {
            FamName = famName;
            Adr = adr;
        }

        public Person(
            string famName, 
            string city="", 
            string street="", 
            int cityCode=99999)
        {
            FamName= famName;
            Adr = new Address(city,cityCode,street);    
        }

        public string FamName
        {
            get
            {
                return famName;
            }

            set
            {
                if (value != null && value.Length > 0)
                {
                    famName = value;
                }
                else
                    throw new ArgumentNullException("Der Familienname muss angegeben werden!");
            }
        }

        public Address Adr
        {
            get => adr;
            set
            {
                if (value != null)
                    adr = value;
                else
                    throw new ArgumentNullException("Das Adressobjekt darf nicht leer sein!");
            }
        }

        public abstract Role GetRole(); //Abstrakte Methode
        public abstract int GetIdNumber();
        public virtual int GetAge()
        {
            return DateTime.Now.Year;
        }

        public abstract string GetDepartment();
        public virtual string[] GetTeachingSubjekts()
        {
            return new string[10];
        }

    }
}
