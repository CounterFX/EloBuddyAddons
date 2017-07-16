using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.Sandbox;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace AbsoluteBravery
{
    class ItemBuilding
    {
        public ItemId result;
        public List<ItemId> components;
        
        public ItemBuilding(ItemId i, List<ItemId> c)
        {
            result = i;
            components = c;
        }

        public ItemBuilding(ItemId i, params ItemId[] c)
        {
            result = i;
            components = c.ToList();
        }
    }
}
