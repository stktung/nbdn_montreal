 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using developwithpassion.commons.core.infrastructure.containers;
 using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class BasicContainerSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Container,
                                             BasicContainer>
         {
        
         }

         [Concern(typeof(BasicContainer))]
         public class when_resolving_an_implementation_of_an_dependency : concern
         {
             context c = () =>
             {
            
             };

             because b = () =>
             {
        
             };

        
             it should = () =>
             {
                 
            
            
             };
         }
     }
 }
