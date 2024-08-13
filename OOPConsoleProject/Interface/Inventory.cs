using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConsoleProject.Interface
{
    public interface Inventory
    {
        void AddItem(Item item);
        void ShowInventory();
    }
}
