using System;
using Play.Common;

namespace Play.Catalog.Service.Entities
{

    public class Item : IEntity
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public Decimal Price { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}