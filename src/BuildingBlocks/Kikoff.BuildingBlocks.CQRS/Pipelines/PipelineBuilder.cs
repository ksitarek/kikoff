using Kikoff.BuildingBlocks.Modules.Extensions;
using Microsoft.Extensions.DependencyInjection;
using ServiceCollectionExtensions = Kikoff.BuildingBlocks.CQRS.Extensions.ServiceCollectionExtensions;

namespace Kikoff.BuildingBlocks.CQRS.Pipelines;

internal class PipelineBuilder<TMessage, TResult>
{
    private readonly string _moduleName;
    private readonly IServiceProvider _serviceProvider;

    private PipelineBuilder(string moduleName, IServiceProvider serviceProvider)
    {
        _moduleName = moduleName;
        _serviceProvider = serviceProvider;
    }

    public static PipelineBuilder<TMessage, TResult> Create(IServiceProvider serviceProvider)
    {
        return new PipelineBuilder<TMessage, TResult>(
            typeof(TMessage).TryGetModuleName(),
            serviceProvider);
    }

    public Pipeline<TMessage, TResult> Build()
    {
        return new Pipeline<TMessage, TResult>(GetModuleBehaviors().Union(GetCommonBehaviors()).Reverse());
    }

    private IEnumerable<IPipelineBehavior<TMessage, TResult>> GetModuleBehaviors()
    {
        return _serviceProvider.GetKeyedServices<IPipelineBehavior<TMessage, TResult>>(_moduleName);
    }

    private IEnumerable<IPipelineBehavior<TMessage, TResult>> GetCommonBehaviors()
    {
        return _serviceProvider.GetKeyedServices<IPipelineBehavior<TMessage, TResult>>(ServiceCollectionExtensions
            .CommonPipelineKey);
    }
}
