using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ReflectiveAutoWiringResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<TypeInstanceResolver,
                                            ReflectiveAutoWiringResolver> {}

        [Concern(typeof (ReflectiveAutoWiringResolver))]
        public class when_resolving_a_type_with_dependencies : concern
        {
            context c = () =>
            {
                items = new Dictionary<int, string>();
                connection = new SqlConnection();
                command = connection.CreateCommand();

                container_dependency(connection);
                container_dependency(command);
                container_dependency(items);

                provide_a_basic_sut_constructor_argument(typeof (TypeWithDependencies));
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_return_an_instance_of_the_type_with_all_of_its_dependencies_set = () =>
            {
                var instance = result.should_be_an_instance_of<TypeWithDependencies>();
                instance.command.should_be_equal_to(command);
                instance.connection.should_be_equal_to(connection);
                instance.items.should_be_equal_to(items);
            };

            static object result;
            static IDbCommand command;
            static IDbConnection connection;
            static IDictionary<int, string> items;
        }

        public class TypeWithDependencies
        {
            public IDbConnection connection;
            public IDictionary<int, string> items;
            public IDbCommand command;

            public TypeWithDependencies(IDbConnection connection, IDictionary<int, string> items, IDbCommand command)
            {
                this.connection = connection;
                this.items = items;
                this.command = command;
            }
        }
    }
}