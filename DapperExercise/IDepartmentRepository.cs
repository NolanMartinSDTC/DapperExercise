using System;
using System.Collections.Generic;
namespace DapperExercise
{
	public interface IDepartmentRepository
	{
		public IEnumerable<Department> GetAllDepartments();
		public void InsertDepartment(string newDepartmentName);
	}
}

