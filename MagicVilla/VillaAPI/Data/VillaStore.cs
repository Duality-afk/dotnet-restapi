using VillaAPI.Models.Dto;

namespace VillaAPI.Data
{
	public class VillaStore
	{
		public static List<VillaDTO> VillaList = new List<VillaDTO>
		{
			new VillaDTO { Id = 1, Name="Pool View"},
			new VillaDTO { Id = 2,Name = "Beach View"}
		};
	}
}
