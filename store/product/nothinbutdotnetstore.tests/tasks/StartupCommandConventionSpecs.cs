using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.tasks.startup;

namespace nothinbutdotnetstore.tests.tasks
{
    public class StartupCommandConventionSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Specification<Type>,
                                            StartupCommandConvention> {}

        [Concern(typeof (StartupCommandConvention))]
        public class when_determining_whether_a_types_matches_the_startup_command_convention : concern
        {
            it should_only_be_satisfied_by_startup_commands_that_have_the_expected_constructor = () =>
            {
                sut.is_satisfied_by(typeof (GoodCommand)).should_be_true();
                sut.is_satisfied_by(typeof (BadCommand)).should_be_false();
            };
        }

        class GoodCommand : StartupCommand
        {
            ContainerConfiguration config;

            public GoodCommand(ContainerConfiguration config)
            {
                this.config = config;
            }

            public void run()
            {
                throw new NotImplementedException();
            }
        }

        class BadCommand : StartupCommand
        {
            public void run()
            {
                throw new NotImplementedException();
            }
        }
    }
}