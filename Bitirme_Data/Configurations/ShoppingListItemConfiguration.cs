using Bitirme_Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Data.Configurations
{
    public class ShoppingListItemConfiguration : IEntityTypeConfiguration<ShoppingListItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingListItem> builder)
        {
            builder.HasOne(a => a.ShoppingList)
                .WithMany(a => a.Products)
                .HasForeignKey(a => a.ShoppingListId);

            builder.HasOne(a => a.Product)
                .WithMany(a => a.ShoppingLists)
                .HasForeignKey(a => a.ProductId);

            builder.HasKey(a => new { a.ShoppingListId, a.ProductId });

            builder.Property(a => a.Description)
                .HasMaxLength(200);

            builder.Property(a => a.Amount)
                .IsRequired();
        }
    }
}
