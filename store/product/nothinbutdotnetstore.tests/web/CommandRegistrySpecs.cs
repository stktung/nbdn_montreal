using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using developwithpassion.bdd.core.extensions;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                            BasicCommandRegistry> {

            context c = () =>
            {
                all_commands = new List<ApplicationRequestCommand>();
                request = an<ApplicationRequest>();

                Enumerable.Range(1,10).each(i => all_commands.Add(an<ApplicationRequestCommand>()));

                provide_a_basic_sut_constructor_argument<IEnumerable<ApplicationRequestCommand>>(all_commands);
            };

            static protected IList<ApplicationRequestCommand> all_commands;
            static protected ApplicationRequest request;
                                            }

        [Concern(typeof (BasicCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                command_that_can_handle_request = an<ApplicationRequestCommand>();
                command_that_can_handle_request.Stub(command => command.can_handle(request)).Return(true);
                all_commands.Add(command_that_can_handle_request);

            };

            because b = () =>
            {
                result = sut.find_command_that_can_process(request);
            };


            it should_return_a_command = () =>
            {
                result.should_be_equal_to(command_that_can_handle_request);
            };

            static ApplicationRequestCommand result;
            static ApplicationRequestCommand command_that_can_handle_request;
        }

        [Concern(typeof (BasicCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_does_not_have_a_command_that_can_handle_the_request : concern
        {

            because b = () =>
            {
                result = sut.find_command_that_can_process(request);
            };

            it should_return_a_missing_command = () =>
            {
                result.should_be_an_instance_of<MissingCommand>();
            };


            static ApplicationRequestCommand result;
        }

        [Concern(typeof (BasicCommandRegistry))]
        public class when_getting_a_command_and_there_are_no_commands : concern
        {
            context c = () =>
            {
                all_commands.Clear();
            };

            because b = () =>
            {
                result = sut.find_command_that_can_process(request);
            };

            it should_return_a_missing_command = () =>
            {
                result.should_be_an_instance_of<MissingCommand>();
            };


            static ApplicationRequestCommand result;
        }
    }
}