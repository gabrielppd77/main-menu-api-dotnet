using main_menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace main_menu.Database.Map
{
	public class Product_Map : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(200);
			builder.Property(x => x.Description).HasMaxLength(500);
			builder.Property(x => x.UrlImage).HasMaxLength(999);
		}
	}
}