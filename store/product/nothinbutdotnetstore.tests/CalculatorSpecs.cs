using System;
using System.Data;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;

namespace nothinbutdotnetstore.tests
{
    public class CalculatorSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Calculator,BasicCalculator> {}

        public class when_adding_two_positive_numbers : concern
        {
            because b = () =>
            {
                result = sut.add(1, 3);
            };

            it should_return_the_sum_of_the_numbers = () =>
            {
                result.should_be_equal_to(4);
            };

            static int result;
            static IDbConnection connection;
        }
    }

    public interface Calculator {
        int add(int first, int second);
    }

    public class BasicCalculator : Calculator
    {
        IDbConnection connection;

        public BasicCalculator(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            return first + second;
        }

    }
}