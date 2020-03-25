using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    interface IOrder
    {

        void GetInput();
        void SendOrder();
        void CustomerSearch();
        void OrderDetails();
        void StoreHistory();
        void CustomerHistory();
        void HistorySort();
        void OrderSuggestion();
        void HistoryStats();
    }
}
