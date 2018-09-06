using Repo_Pattern_MVC_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_pattern_MVC_Repository.Service
{
	public interface IHome_Repository : IDisposable
	{
		
		int SaveDynamicForm(Form_Master _modal);
		List<Form_Master> GetFormName();
		List<Form_Master> GetFormNamebyID(int id);
		bool CheckFormnameExist(string FormName);
	}
}
