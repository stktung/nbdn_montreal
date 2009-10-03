using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.dsl;

namespace nothinbutdotnetstore.tasks.startup
{
    public class ConfigureRequestToCommandRouting : StartupCommand
    {
        public ContainerConfiguration container_configuration { get; set; }

        public ConfigureRequestToCommandRouting(ContainerConfiguration container_configuration)
        {
            this.container_configuration = container_configuration;
        }

        public void run()
        {
            var routes = IOC.resolve.instance_of<ApplicationRoutes>();

            routes.add_route(
                Request.has_a_url_that_contains_the_command<ViewMainDepartments>(),
                IOC.resolve.instance_of<ViewMainDepartments>());

            routes.add_route(Request.compound_specification(
                                 Request.has_a_url_that_contains_the_command<ViewProductBrowser>(),
                                 IOC.resolve.instance_of<DepartmentHasProducts>()),
                             IOC.resolve.instance_of<ViewProductBrowser>());     

            routes.add_route(Request.has_a_url_that_contains_the_command<ViewSubDepartments>(),
                IOC.resolve.instance_of<ViewSubDepartments>());
        }
    }
}