using main_menu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace main_menu.Database.Map
{
	public class Option_Map : IEntityTypeConfiguration<Option>
	{
		public void Configure(EntityTypeBuilder<Option> builder)
		{
			builder.Property(x => x.Title).HasMaxLength(100);
			builder.Property(x => x.Subtitle).HasMaxLength(100);
		}
	}
}