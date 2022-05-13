using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class QuestCompletItem
    {
        public Item Details { get; set; }
        public int Quantity { get; set; }

        public QuestCompletItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
