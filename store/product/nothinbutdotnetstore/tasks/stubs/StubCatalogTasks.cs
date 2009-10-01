using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.dto;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_all_main_departments()
        {
            return Enumerable.Range(1, 100).Select(
                i => new DepartmentItem {name = i.ToString("Main Department 0")});
        }

        public IEnumerable<DepartmentItem> get_sub_departments_for(DepartmentItem department)
        {
            return Enumerable.Range(1, 100).Select(
                i => new DepartmentItem {name = i.ToString("Sub Department 0")});
        }
    }
}