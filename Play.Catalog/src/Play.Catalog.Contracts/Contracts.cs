using System;

namespace Play.Catalog.Contracts
{
    public record CatalogItemCreated(Guid ItemId, string Name, string Decription);
    public record CatalogItemUpdated(Guid ItemId, string Name, string Decription);
    public record CatalogItemDeleted(Guid ItemId);
}