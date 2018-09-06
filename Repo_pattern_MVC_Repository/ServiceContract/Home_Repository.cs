
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repo_Pattern_MVC_Model;
using Repo_Pattern_MVC_Model.Model;
using Repo_pattern_MVC_Repository.Service;

namespace Repo_pattern_MVC_Repository.ServiceContract
{

	public class Home_Repository : IHome_Repository
	{
		private Repo_Pattern_MVCEntities context;
		public Home_Repository(Repo_Pattern_MVCEntities _context)
		{
			this.context = _context;
		}
		//start your method here...
		
		public int SaveDynamicForm(Form_Master _modal)
		{

			context.Form_Master.Add(_modal);
			context.SaveChanges();
			return 1;
		}

		public List<Form_Master> GetFormName()
		{
			return context.Form_Master.ToList();

		}
		public List<Form_Master> GetFormNamebyID(int id)
		{
			return context.Form_Master.Where(t => t.id == id).ToList();

		}
		public bool CheckFormnameExist(string FormName)
		{
			try
			{
				return context.Form_Master.Where(t => t.Form_Name == FormName).Any();
				
			}
			catch (Exception Ex)
			{
				return false;
				
			}
			

		}
		

		//------------------------------------
		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}


}
