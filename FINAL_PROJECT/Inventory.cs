using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FINAL_PROJECT
{
    public class Inventory
    {

        private int itemId;
        private string itemName;
        private int quantity;
        public int iId { get => itemId; set => itemId = value; }
        public string iName { get => itemName; set => itemName = value; }
        public int qty { get => quantity; set => quantity = value; }
    }
}
