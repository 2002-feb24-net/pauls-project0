using System;

namespace Library.Models
{
   public class Customer
    {
        //Fields

        private string firstName;
        private string lastName;
        //public Customer(string f, string l)
        //{
        //    firstName = f;
        //    lastName = l;
        //}

        public string FirstName
        {
            get => firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }

                firstName = value;
            }
        }


        public string LastName
        {
            get => lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }

                lastName = value;
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

        string phone;
        public string Phone
        {
            get => phone;
            set
            {
                if (value.Length == 0)
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
