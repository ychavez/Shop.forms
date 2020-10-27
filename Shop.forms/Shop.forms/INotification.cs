using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.forms
{
    public interface INotification
    {
        void CreateNotification(string title, string message);
    }
}
