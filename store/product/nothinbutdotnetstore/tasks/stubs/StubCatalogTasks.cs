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

        public IEnumerable<ProductItem> get_products_for(DepartmentItem department)
        {
            return Enumerable.Range(1, 100).Select(
                i => new ProductItem {name = i.ToString("Prduct 0")});
        }

        public bool has_any_products(DepartmentItem department)
        {
            Random rand = new Random();
            return rand.Next(10) < 5 ? true : false;
        }
    }
}