using System;
using System.ComponentModel.DataAnnotations;
namespace WildHeartsAPI.Models
{
	public class Material
	{
		[Key]
		public int MaterialId { get; set; }
		public string MaterialName { get; set; }
		public int KemonoId { get; set; }
		public int MaterialValue { get; set; }
		public string? MaterialPart { get; set; }

        public static implicit operator List<object>(Material? v)
        {
            throw new NotImplementedException();
        }
    }

}

