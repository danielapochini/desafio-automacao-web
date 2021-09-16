using DesafioAutomacaoWeb.Utils.Database.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Entities
{
    public class ProjectsEntities
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public ProjectStatus Status { get; set; }
		public bool Enabled { get; set; }
		public ProjectViewState ViewState { get; set; }
		public int AccessMin { get; set; }
		public string FilePath { get; set; }
		public string Description { get; set; }
		public int CategoryId { get; set; }
		public bool InheritGlobal { get; set; }
	}
}
