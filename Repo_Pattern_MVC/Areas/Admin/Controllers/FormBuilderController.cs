using Repo_Pattern_MVC.Utility;
using Repo_Pattern_MVC_Model;
using Repo_Pattern_MVC_Model.Model;
using Repo_pattern_MVC_Repository.Service;
using Repo_pattern_MVC_Repository.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repo_Pattern_MVC.Areas.Admin.Controllers
{
	public class FormBuilderController : Controller
	{
		// GET: Admin/FormBuilder
		IHome_Repository _Home_Repository = new Home_Repository(new Repo_Pattern_MVCEntities());

		public ActionResult Index()
		{
			return View();
		}
		[ValidateInput(false)]
		public JsonResult SaveDyanamicForm(string FormName, string Form_Json, string Form_HTML)
		{
			var result = new jsonMessage();
			try
			{
				Form_Master _modal = new Form_Master();
				_modal.Form_Name = FormName;
				_modal.Form_Body_Json = Form_Json;
				_modal.Form_Body_Html = Form_HTML;

				int Issave = _Home_Repository.SaveDynamicForm(_modal);
				if (Issave == 1)
				{
					result.Message = "Form has beed saved successfully.";
					result.Status = true;
				}

			}
			catch (Exception ex)
			{
				//ErrorLogers.ErrorLog(ex);
				result.Message = ex.ToString();
				result.Status = false;
			}
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetDyanamicForm(string id)
		{

			return Json(new { data = _Home_Repository.GetFormNamebyID(Convert.ToInt32(id)) }, JsonRequestBehavior.AllowGet);
		}
		public bool CheckFormnameExist(string FormName)
		{
			var returnval=_Home_Repository.CheckFormnameExist(FormName);
			return returnval;
		}
	}
	}