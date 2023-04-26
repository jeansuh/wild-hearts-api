using System;

namespace WildHeartsAPI.Models
{
	public class Response
	{
		public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public List<Kemono>? KemonoDatas { get; set; }
        public Kemono? KemonoData { get; set; }
        public List<Material>? MaterialDatas { get; set; }
        public Material? MaterialData { get; set; }
    }
}

