 using System;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.tasks.startup;
 using developwithpassion.bdd.mocking.rhino;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.tasks
 {   
     public class StartupCommandPipeSpecs
     {
         public abstract class concern : observations_for_a_sut_without_a_contract<StartupCommandPipe>
         {

             context c = () =>
             {
                 factory = the_dependency<StartupCommandFactory>();
             };

             static protected StartupCommandFactory factory;
         }

         public abstract class concern_for_pipeline_that_has_been_created_with_initial_command : concern {

             context c = () =>
             {
                provide_a_basic_sut_constructor_argument(typeof(FirstCommand));
                 factory.Stub(command_factory => command_factory.create_from(typeof (FirstCommand)))
                     .Return(new FirstCommand());
             };
         }

         [Concern(typeof(StartupCommandPipe))]
         public class when_created_with_the_type_of_its_initial_command_to_run : concern
         {
             context c = () =>
             {
                 provide_a_basic_sut_constructor_argument(typeof(FirstCommand));
             };
        
             it should_use_the_command_factory_to_create_the_appropriate_startup_command = () =>
             {
                 factory.received(command_factory => command_factory.create_from(typeof (FirstCommand)));
             };
         }

         [Concern(typeof(StartupCommandPipe))]
         public class when_finished_the_pipeline : concern_for_pipeline_that_has_been_created_with_initial_command
         {
             context c = () =>
             {
                 factory.Stub(command_factory => command_factory.create_from(typeof (SecondCommand)))
                     .Return(new SecondCommand());
             };

             because b = () =>
             {
                 sut.finished_by<SecondCommand>();
             };
        
             it should_run_all_of_the_commands_that_make_up_the_pipeline = () =>
             {
                FirstCommand.ran.should_be_true(); 
                SecondCommand.ran.should_be_true(); 
             };
         }

         [Concern(typeof(StartupCommandPipe))]
         public class when_adding_a_command_to_the_pipeline : concern_for_pipeline_that_has_been_created_with_initial_command
         {
             context c = () =>
             {
                 factory.Stub(command_factory => command_factory.create_from(typeof (SecondCommand)))
                     .Return(new SecondCommand());
             };

             because b = () =>
             {
                 sut.followed_by<SecondCommand>();
                 sut.finished_by<SecondCommand>(); 
             };
        
             it should_be_appending_commands_to_run_correctly = () =>
             {
                FirstCommand.ran.should_be_true(); 
                SecondCommand.ran.should_be_true(); 
             };
         }
     }

     class FirstCommand : StartupCommand {
         static public bool ran = false;
         public void run()
         {
             ran = true;
         }
     }
     class SecondCommand : StartupCommand {
         static public bool ran = false;
         public void run()
         {
             ran = true;
         }
     }
 }
