 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
 {
    public class ViewMainDepartmentSpecificationSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Specification<ApplicationRequest>,
                                             ViewMainDepartmentSpecification>
         {
        
         }

         [Concern(typeof(ViewMainDepartmentSpecification))]
         public class when_specification_is_given_an_application_request_that_satisfies : concern
         {
             context c = () =>
             {
                 request = an<ApplicationRequest>();
                 request.CommandName = "ViewMainDepartments";
             };

             because b = () =>
             {
                 result = sut.is_satisfied_by(request);
             };

        
             it should_return_true = () =>
             {
                 result.should_be_true();
            
             };

             static ApplicationRequest request;
             static bool result;
         }
     }
 }
