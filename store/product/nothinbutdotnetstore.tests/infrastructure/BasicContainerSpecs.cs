using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class BasicContainerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Container,
                                            BasicContainer>
        {
            context c = () =>
            {
                types = new Dictionary<Type, TypeInstanceResolver>();
                provide_a_basic_sut_constructor_argument(types);
            };

            static protected IDictionary<Type, TypeInstanceResolver> types;
        }

        [Concern(typeof (BasicContainer))]
        public class when_resolving_an_implementation_of_an_dependency_and_the_dependency_has_been_configured : concern
        {
            context c = () =>
            {
                resolver= an<TypeInstanceResolver>();

                resolver.Stub(instance_resolver => instance_resolver.resolve())
                    .Return(new MyImplementation());

                types.Add(typeof (MyInterface), resolver);
            };

            because b = () =>
            {
                result = sut.instance_of<MyInterface>();
            };


            it should_should_give_back_an_implementation_of_the_dependency = () =>
            {
                result.should_be_an_instance_of<MyImplementation>();
            };

            static MyInterface result;
            static TypeInstanceResolver resolver;
        }

        [Concern(typeof (BasicContainer))]
        public class when_resolving_an_implementation_by_requesting_its_type : concern
        {
            context c = () =>
            {
                resolver= an<TypeInstanceResolver>();

                resolver.Stub(instance_resolver => instance_resolver.resolve())
                    .Return(new MyImplementation());

                types.Add(typeof (MyInterface), resolver);
            };

            because b = () =>
            {
                result = sut.instance_of(typeof (MyInterface));
            };


            it should_should_give_back_an_implementation_of_the_dependency = () =>
            {
                result.should_be_an_instance_of<MyImplementation>();
            };

            static object result;
            static TypeInstanceResolver resolver;
        }

        [Concern(typeof (BasicContainer))]
        public class when_resolving_an_implementation_of_a_dependency_and_there_is_no_dependency : concern
        {
            because b = () =>
            {
                doing(() => sut.instance_of<MyImplementation>());
            };


            it should_throw_a_dependency_not_registered_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<DependencyNotRegisteredException>()
                    .type_that_could_not_be_resolved.should_be_equal_to(typeof (MyImplementation));
            };
        }

        [Concern(typeof (BasicContainer))]
        public class when_the_type_resolver_for_a_type_throws_an_error_trying_to_resolve_a_dependency : concern
        {
            context c = () =>
            {
                exception = new Exception();
                resolver=an<TypeInstanceResolver>();

                resolver.Stub(instance_resolver => instance_resolver.resolve())
                    .Throw(exception);

                types.Add(typeof(MyInterfaceWithDependencies),resolver);
            };

            because b = () =>
            {
                doing(() => sut.instance_of<MyInterfaceWithDependencies>());
            };


            it should_throw_an_type_resolution_exception_with_access_to_the_inner_exception = () =>
            {
                var exception_thrown = exception_thrown_by_the_sut.should_be_an_instance_of<TypeResolutionException>();
                exception_thrown.type_that_could_not_be_resolved.should_be_equal_to(typeof(MyInterfaceWithDependencies));
                exception_thrown.InnerException.should_be_equal_to(exception);
            };

            static TypeInstanceResolver resolver;
            static Exception exception;
        }
    }

public interface  MyInterfaceWithDependencies {}

    public class MyInterfaceWithDependenciesImpl : MyInterfaceWithDependencies {
        IDbConnection first_dependency;
        ConnectionStringSettings second_dependency;
        IList<int> third_dependency;
        public MyInterfaceWithDependenciesImpl(IDbConnection first_dependency, ConnectionStringSettings second_dependency, IList<int> third_dependency)
        {
            this.first_dependency = first_dependency;
            this.second_dependency = second_dependency;
            this.third_dependency = third_dependency;
        }
    }

    class MyImplementation : MyInterface {}

    interface MyInterface {}
}