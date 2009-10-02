using System;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class TypeInstanceResolverSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<TypeInstanceResolver,
                                            BasicTypeInstanceResolver> {}

        [Concern(typeof (BasicTypeInstanceResolver))]
        public class when_resolving_an_item : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                factory = () => sql_connection;

                provide_a_basic_sut_constructor_argument(factory);
            };

            because b = () =>
            {
                result = sut.resolve();
            };


            it should_return_the_item_created_using_the_the_factory = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static object result;
            static SqlConnection sql_connection;
            static Func<object> factory;
        }
    }
}