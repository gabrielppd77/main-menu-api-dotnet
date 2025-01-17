using main_menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace main_menu.Database.Map
{
	public class Company_Map : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(100);
			builder.Property(x => x.Path).HasMaxLength(150);
			builder.Property(x => x.Description).HasMaxLength(500);
			builder.Property(x => x.UrlImage).HasMaxLength(999);
		}
	}
}