using System;
using System.Collections.Generic;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class ViewDepartmentsCommand : ApplicationWebCommand
    {
        readonly Service service;
        readonly DepartmentView view;
        public ViewDepartmentsCommand() : this(new ConcreteService(), new DepartmentView()) {}

        public ViewDepartmentsCommand(Service service, DepartmentView view)
        {
            this.service = service;
            this.view = view;
        }


        public void process(ApplicationRequest request)
        {
            view.Departments = service.GetDepartments();
        }
    }

    public class ConcreteService : Service {
        public List<string> GetDepartments()
        {
            return new List<string> { "foo" };
        }
    }

    public class DepartmentView : WebView
    {
        List<string> departments;

        public List<string> Departments
        {
            set
            {
                departments = value;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.Server.Transfer("DepartmentBrowser.aspx");
                }
            }
            get { return departments; }
        }
    }

    public interface Service
    {
        List<string> GetDepartments();
    }

    public interface WebView { }
}