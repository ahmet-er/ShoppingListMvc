using Bitirme_Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bitirme_Data.Configurations
{
    public class ShoppingListConfiguration : IEntityTypeConfiguration<ShoppingList>
    {
        public void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            builder.HasKey(s => s.ShoppingListID);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(s => s.User)
                .WithMany(s => s.ShoppingLists)
                .HasForeignKey(s => s.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
