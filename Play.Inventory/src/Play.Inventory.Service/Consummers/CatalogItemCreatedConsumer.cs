using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consummers
{
    public class CatalogItemCreatedConsumer : IConsumer<CatalogItemCreated>
    {
        private readonly IRepository<CatalogItem> repository;

        public CatalogItemCreatedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<CatalogItemCreated> context)
        {
            var messasge = context.Message;

            var item = await repository.GetAsync(messasge.ItemId);

            if (item != null)
            {
                return;
            }

            item = new CatalogItem
            {
                Id = messasge.ItemId,
                Name = messasge.Name,
                Description = messasge.Decription
            };

            await repository.CreateAsync(item);
        }
    }
}