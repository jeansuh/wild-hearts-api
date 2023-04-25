using System;
using System.ComponentModel.DataAnnotations;
namespace WildHeartsAPI.Models
{
	public class Kemono
	{
		[Key]
		public int KemonoId { get; set; }
		public string KemonoName { get; set; }
		public int Chapter { get; set; }
		public string Attribute { get; set; }
		public string Habitat { get; set; }
		public Material[] MaterialId { get; set; }
	}
}

