using main_menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace main_menu.Database.Map
{
	public class OptionDivider_Map : IEntityTypeConfiguration<OptionDivider>
	{
		public void Configure(EntityTypeBuilder<OptionDivider> builder)
		{
			builder.Property(x => x.Title).HasMaxLength(100);
		}
	}
}