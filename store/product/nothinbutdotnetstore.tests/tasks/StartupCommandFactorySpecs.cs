using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks.startup;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupCommandFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<StartupCommandFactory,
                                            BasicStartupCommandFactory>
        {
            context c = () =>
            {
                configuration = the_dependency<ContainerConfiguration>();
                convention_specification = the_dependency<Specification<Type>>();
            };

            static protected ContainerConfiguration configuration;
            static protected Specification<Type> convention_specification;
        }

        [Concern(typeof (BasicStartupCommandFactory))]
        public class when_creating_a_startup_command_from_a_type_that_is_following_the_convention : concern
        {
            context c = () =>
            {
                convention_specification.Stub(specification => specification.is_satisfied_by(typeof (OurCommand)))
                    .Return(true);
            };

            because b = () =>
            {
                result = sut.create_from(typeof (OurCommand));
            };


            it should_return_the_instance_of_the_startup_command_with_the_configuration = () =>
            {
                result.should_be_an_instance_of<OurCommand>()
                    .configuration.should_be_equal_to(configuration);
            };

            static StartupCommand result;
        }

        [Concern(typeof (BasicStartupCommandFactory))]
        public class when_creating_a_startup_command_from_a_type_that_is_not_following_the_convention : concern
        {
            because b = () =>
            {
                doing(() => sut.create_from(typeof (OurBadCommand)));
            };


            it should_throw_a_convention_not_followed_exception = () =>
            {
                exception_thrown_by_the_sut.should_be_an_instance_of<StartupCommandConventionViolationExceptionation>();
            };
        }

        class OurCommand : StartupCommand
        {
            public void run() {}

            public OurCommand(ContainerConfiguration configuration)
            {
                this.configuration = configuration;
            }

            public ContainerConfiguration configuration { get; set; }
        }

        class OurBadCommand : StartupCommand
        {
            public void run() {}
        }
    }
}