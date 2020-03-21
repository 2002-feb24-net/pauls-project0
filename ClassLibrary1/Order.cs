using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Order 
    {
        //Fields
        string store;
        public string Store => $"{store}";

        string customer;
        public string Customer => $"{customer}";

        int orderHr;
        int orderMn;
        public string OrderTime => $"{orderHr}:{orderMn}";

        // if order burger plain, comes with bun alone.
        // for items besides burger and bun: 0 is none, 
        //     1 is light, 2 is normal, and 3 is extra.
        int burgers = 0;
        int buns = 2;
        int lettuce = 0;
        int onions = 0;
        int cheese = 0;
        int ketchup = 0;
        int mayo = 0;
        int mustard = 0;
        int edSauce = 0;

        int fries = 0;

        int soda = 0;


        //Methods
        public void AddBurger()
        {
            burgers++;
        }

        public void AddLettuce(char x)
        {
            if (x == 'l')
            {
                lettuce++;
            }
            else if (x == 'n')
            {
                lettuce = 2;
            }
            else if (x == 'x')
            {
                lettuce = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddOnions(char x)
        {
            if (x == 'l')
            {
                onions++;
            }
            else if (x == 'n')
            {
                onions = 2;
            }
            else if (x == 'x')
            {
                onions = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddCheese(char x)
        {
            if (x == 'l')
            {
                cheese++;
            }
            else if (x == 'n')
            {
                cheese = 2;
            }
            else if (x == 'x')
            {
                cheese = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddKetchup(char x)
        {
            if (x == 'l')
            {
                ketchup++;
            }
            else if (x == 'n')
            {
                ketchup = 2;
            }
            else if (x == 'x')
            {
                ketchup = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddMayo(char x)
        {
            if (x == 'l')
            {
                mayo++;
            }
            else if (x == 'n')
            {
                mayo = 2;
            }
            else if (x == 'x')
            {
                mayo = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddMustard(char x)
        {
            if (x == 'l')
            {
                mustard++;
            }
            else if (x == 'n')
            {
                mustard = 2;
            }
            else if (x == 'x')
            {
                mustard = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddEdSauce(char x)
        {
            if (x == 'l')
            {
                edSauce++;
            }
            else if (x == 'n')
            {
                edSauce = 2;
            }
            else if (x == 'x')
            {
                edSauce = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddFries(char x)
        {
            if (x == 'l')
            {
                fries++;
            }
            else if (x == 'n')
            {
                fries = 2;
            }
            else if (x == 'x')
            {
                fries = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }

        public void AddSoda(char x)
        {
            if (x == 'l')
            {
                soda++;
            }
            else if (x == 'n')
            {
                soda = 2;
            }
            else if (x == 'x')
            {
                soda = 3;
            }
            else
                Console.WriteLine("Please enter either 'l', 'n', or 'x'");
        }


    }
}
