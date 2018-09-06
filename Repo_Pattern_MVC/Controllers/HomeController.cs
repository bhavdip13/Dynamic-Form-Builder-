using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repo_Pattern_MVC.Utility;
using Repo_Pattern_MVC_Model;
using Repo_Pattern_MVC_Model.Model;
using Repo_pattern_MVC_Repository.Service;
using Repo_pattern_MVC_Repository.ServiceContract;

namespace Repo_Pattern_MVC.Controllers
{
	public class HomeController : Controller
	{
		IHome_Repository _Home_Repository = new Home_Repository(new Repo_Pattern_MVCEntities());
		public ActionResult Index()
		{
		ViewBag.FormnameList=	_Home_Repository.GetFormName();
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
	}
}