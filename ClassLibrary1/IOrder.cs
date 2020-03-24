using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
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
