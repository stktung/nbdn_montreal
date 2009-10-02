using System;
using System.Collections.Generic;
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
                                            BasicContainer> {}

        [Concern(typeof (BasicContainer))]
        public class when_resolving_an_implementation_of_an_dependency : concern
        {
            context c = () =>
            {
                types = new Dictionary<Type, object>();

                implementation = new MyImplementation();

                types.Add(typeof(MyInterface), implementation);
                
                provide_a_basic_sut_constructor_argument<IDictionary<Type, object>>(types);
            };

            because b = () =>
            {
                result = sut.instance_of<MyInterface>();
            };


            it should_should_give_back_an_implementation_of_the_dependency = () => 
            {
                result.should_be_equal_to(implementation);
            };

            static MyInterface result;
            static Dictionary<Type, object> types;
            static object implementation;
        }
    }

    class MyImplementation : MyInterface {}

    interface MyInterface {}
}