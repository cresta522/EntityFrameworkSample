using EFTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFTest.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public ActionResult Sample()
		{
			using (var context = new EFTestDbContext()) {

				//自治体コード 13101 の検索
				//自治体情報１件を取得する場合。
				var entity1 = context.Municipalities.Where(m => m.Code == "13101").FirstOrDefault();

				//自治体コード 13101 の都道府県 N県を取得する場合
				//パターン1
				var entity2 = context.Municipalities
					.Where(m => m.Code == "13101")
					.Join(context.Prefectures, m => m.PrefectureCode, p => p.Code, (m, p) => p)
					.FirstOrDefault();

				//パターン2
				//モデルでJoinしたほうがスッキリする。
				var entity3 = context.Municipalities
					.Where(m => m.Code == "13101")
					.Select(m => m.Prefecture)
					.FirstOrDefault();

				// 静岡に該当する自治体一覧を取得
				// CodeでJoinする場合
				var list1 = context.Prefectures
					.Where(p => p.Name == "静岡県")
					.Join(context.Municipalities, p => p.Code, m => m.PrefectureCode, (p, m) => m)
					.ToList();

				// ModelでJoinする場合
				var list2 = context.Prefectures
					.Where(p => p.Name == "静岡県")
					.SelectMany(p => p.Municipalities).ToList();
			}

			return View();
		}

	}
}