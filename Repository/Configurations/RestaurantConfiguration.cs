using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;

namespace Repository.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("Restaurant");
        builder.Property(x => x.Address).HasMaxLength(255);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Phone).HasMaxLength(20);
    }
}