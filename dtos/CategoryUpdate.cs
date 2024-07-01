using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace main_menu.dtos
{
	public class CategoryUpdate
	{
		public required string Name { get; set; }
		public int Order { get; set; }
	}
}