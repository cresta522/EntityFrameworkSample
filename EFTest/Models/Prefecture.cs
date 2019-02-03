using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFTest.Models
{
	public class Prefecture
	{
		[Key]
		[MaxLength(5)]
		public string Code { get; set; }

		[Required]
		[MaxLength(10)]
		public string Name { get; set; }

		[MaxLength(10)]
		public string Kana { get; set; }

		//1:Nの実装
		public ICollection<Municipality> Municipalities { get; set; }


	}
}