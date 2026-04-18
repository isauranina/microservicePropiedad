using Moq;
using Propiedad.Domain.Factories;
using Propiedad.Domain.Model.Items;
using Propiedad.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Test.Application.UseCases.Items.EventHandler
{
    internal class ItemMockFactory
    {
        //public static List<Item> items = new List<Item>()
        //{
        //    new ItemFactory().Create("Item 1","I1"),
        //    new ItemFactory().Create("Item 2","I2"),
        //    new ItemFactory().Create("Item 3","I3")

        //};
        public static List<Item> getItems()
        {
            return new List<Item>
            { new ItemFactory().Create("Item 1","I1"),
             new ItemFactory().Create("Item 2","I2"),
              new ItemFactory().Create("Item 3","I3")
            };
        }

        public static ItembRepositoryStub getRepositoryImplementation()
        {

            return new ItembRepositoryStub(getItems());
        }

    }
}
