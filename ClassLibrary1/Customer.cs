using System;

namespace ClassLibrary1
{
   public class Customer
    {
        //Fields

        string name;

        //string firstName;
        //string lastName;
        //public Customer(string f, string l)
        //{
        //    firstName = f;
        //    lastName = l;
        //}

        public string Name
        {
            get => name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }

                name = value;
            }
        }


        string address;
        public string Address
        {
            get => address;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Address must not be empty.", nameof(value));
                }

                address = value;
            }
        }

        int phone;
        public int Phone
        {
            get => phone;
            set
            {
                if (value==0)
                {
                    throw new ArgumentException("Number must not be empty.", nameof(value));
                }
                phone = value;
            }

        }

        string favItem;

        //Methods

        void FavItem(string n)
        {

        }

    }
}
