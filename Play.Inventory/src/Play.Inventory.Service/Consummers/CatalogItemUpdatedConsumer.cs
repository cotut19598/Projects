using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Contracts;
using Play.Common;
using Play.Inventory.Service.Entities;

namespace Play.Inventory.Service.Consummers
{
    public class CatalogItemUpdatedConsumer : IConsumer<CatalogItemUpdated>
    {
        private readonly IRepository<CatalogItem> repository;

        public CatalogItemUpdatedConsumer(IRepository<CatalogItem> repository)
        {
            this.repository = repository;
        }

        public async Task Consume(ConsumeContext<CatalogItemUpdated> context)
        {
            var messasge = context.Message;

            var item = await repository.GetAsync(messasge.ItemId);

            if (item == null)
            {
                item = new CatalogItem
                {
                    Id = messasge.ItemId,
                    Name = messasge.Name,
                    Description = messasge.Decription
                };

                await repository.CreateAsync(item);
            }
            else
            {
                item.Name = messasge.Name;
                item.Description = messasge.Decription;
            }
            await repository.UpdateAsync(item);
        }
    }
}