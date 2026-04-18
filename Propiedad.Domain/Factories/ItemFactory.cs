using  Propiedad.Domain.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item Create(string nombre, string codigo)
        {
            return new Item(nombre, codigo);
        }
    }
}
