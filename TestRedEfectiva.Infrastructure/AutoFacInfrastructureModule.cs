using System.Reflection;
using Autofac;
using Ardalis.SharedKernel;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;
using TestRedAfectiva.Infrastructure.Data;
using TestRedAfectiva.Infrastructure.Data.Queries;
using TestRedAfectiva.UseCases.Person.Create;
using TestRedAfectiva.UseCases.Person;


namespace TestRedAfectiva.Infrastructure;

public class AutofacInfrastructureModule : Module
{
    private readonly bool _isDevelopment = false;
    private readonly List<Assembly> _assemblies = [];

    public AutofacInfrastructureModule(bool isDevelopment, Assembly? callingAssembly = null)
    {
        _isDevelopment = isDevelopment;
        AddToAssembliesIfNotNull(callingAssembly);
    }

    private void AddToAssembliesIfNotNull(Assembly? assembly)
    {
        if (assembly != null)
        {
            _assemblies.Add(assembly);
        }
    }

    private void LoadAssemblies()
    {

        var infrastructureAssembly = Assembly.GetAssembly(typeof(AutofacInfrastructureModule));
        var useCasesAssembly = Assembly.GetAssembly(typeof(CreatePersonCommand));

        AddToAssembliesIfNotNull(infrastructureAssembly);
        AddToAssembliesIfNotNull(useCasesAssembly);
    }

    protected override void Load(ContainerBuilder builder)
    {
        LoadAssemblies();
        if (_isDevelopment)
        {
            RegisterDevelopmentOnlyDependencies(builder);
        }
        else
        {
            RegisterProductionOnlyDependencies(builder);
        }
        RegisterEF(builder);
        RegisterMediatR(builder);
    }

    private void RegisterEF(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(EfRepository<>))
          .As(typeof(IRepository<>))
          .As(typeof(IReadRepository<>))
          .InstancePerLifetimeScope();
    }

    private void RegisterMediatR(ContainerBuilder builder)
    {
        builder
          .RegisterType<Mediator>()
          .As<IMediator>()
          .InstancePerLifetimeScope();

        builder
          .RegisterGeneric(typeof(LoggingBehavior<,>))
          .As(typeof(IPipelineBehavior<,>))
          .InstancePerLifetimeScope();

        builder
          .RegisterType<MediatRDomainEventDispatcher>()
          .As<IDomainEventDispatcher>()
          .InstancePerLifetimeScope();

        var mediatrOpenTypes = new[]
        {
      typeof(IRequestHandler<,>),
      typeof(IRequestExceptionHandler<,,>),
      typeof(IRequestExceptionAction<,>),
      typeof(INotificationHandler<>),
    };

        foreach (var mediatrOpenType in mediatrOpenTypes)
        {
            builder
              .RegisterAssemblyTypes([.. _assemblies])
              .AsClosedTypesOf(mediatrOpenType)
              .AsImplementedInterfaces();
        }
    }

    private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
    {
       
        builder.RegisterType<ListPersonsQueryService>()
          .As<IListPersonQueryService>()
          .InstancePerLifetimeScope();

    }

    private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
    {
        
    }
}
