using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
	public class Municipality
	{
		[Key]
		[MaxLength(6)]
		public string Code { get; set; }

		[MaxLength(20)]
		public string Name { get; set; }

		[MaxLength(40)]
		public string Kana { get; set; }

		[MaxLength(5)]
		public string PrefectureCode { get; set; }

		/*
		という Foregin Keyの代わりに以下のプロパティでコードが短くなる。
		上のコードでJoinするのか、下のモデルでJoinするのかの違い
		 */

		public Prefecture Prefecture { get; set; }
	
	}
}