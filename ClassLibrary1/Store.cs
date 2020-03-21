using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Store
    {
        //Fields
        string storeName;
        public string StoreName 
        {
            get => storeName;
            set => storeName = value;
        }

        string location;
        public string Location
        {
            get => location;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Location must not be empty.", nameof(value));
                }

                location = value;
            }
        }

        public List<Reviews> Reviews { get; set; } = new List<Reviews>();

        public double? Score
        {
            get
            {
                if (Reviews?.Count > 0)
                {
                    return Reviews.Average(r => r.Score);
                }
                return null;
            }
        }

        //Methods

   
    }
}
