using System;
using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.tasks.startup
{
    public class BasicStartupCommandFactory : StartupCommandFactory
    {
        ContainerConfiguration configuration;
        Specification<Type> startup_type_convention;

        public BasicStartupCommandFactory() : this(new BasicContainerConfiguration(),
                                                   new StartupCommandConvention()) {}

        public BasicStartupCommandFactory(ContainerConfiguration configuration, Specification<Type> startup_type_convention)
        {
            this.configuration = configuration;
            this.startup_type_convention = startup_type_convention;
        }

        public StartupCommand create_from(Type type)
        {
            ensure_startup_pipeline_convention_is_followed_by(type);

            return (StartupCommand) Activator.CreateInstance(type, configuration);
        }

        void ensure_startup_pipeline_convention_is_followed_by(Type type)
        {
            if (!startup_type_convention.is_satisfied_by(type)) throw new StartupCommandConventionViolationExceptionation();
        }
    }
}