using  Propiedad.Domain.Model.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public interface IItemFactory 
    {
        Item Create(string nombre, string codigo);
    }
}
