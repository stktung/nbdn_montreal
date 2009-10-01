using developwithpassion.bdd.core.commands;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.tests.web
{
    public interface CommandRegistry
    {
        ApplicationRequestCommand find_command_that_can_process(ApplicationRequest request);
    }
}