using Kikoff.BuildingBlocks.CQRS.Abstractions;
using Kikoff.BuildingBlocks.CQRS.Dispatchers;
using Kikoff.BuildingBlocks.CQRS.Extensions;
using Kikoff.BuildingBlocks.CQRS.Pipelines;
using Microsoft.Extensions.DependencyInjection;

namespace Kikoff.Tests.BuildingBlocks.CQRS.Dispatcher;

[Category("Unit")]
[Category("BuildingBlocks")]
public class DispatchRequestAsyncTests
{
    private readonly ServiceCollection _serviceCollection = new();

    [SetUp]
    public void Setup()
    {
        _serviceCollection.AddTalentFlowMessageDispatcher();
        _serviceCollection.AddKeyedScoped(typeof(IPipelineBehavior<,>), "Common", typeof(PipelineBehavior1<,>));
        _serviceCollection.AddKeyedScoped(typeof(IPipelineBehavior<,>), "Common", typeof(PipelineBehavior2<,>));
        _serviceCollection.AddScoped<IRequestHandler<DummyRequest, Guid>, DummyHandler>();
    }

    [TearDown]
    public void TearDown() => _serviceCollection.Clear();

    [Test]
    public async Task ShouldExecuteRegisteredPipeline()
    {
        // Arrange
        var registry = new Registry();
        _serviceCollection.AddSingleton(registry);
        await using ServiceProvider sp = _serviceCollection.BuildServiceProvider();
        IDispatcher dispatcher = sp.GetRequiredService<IDispatcher>();

        // Act
        var id = Guid.NewGuid();
        var request = new DummyRequest(id);
        Guid result = await dispatcher.DispatchRequestAsync<DummyRequest, Guid>(request);

        // Assert
        Assert.That(result, Is.EqualTo(id));
        Assert.That(registry.PipelineLog, Has.Count.EqualTo(3));
        Assert.That(registry.PipelineLog[0], Is.EqualTo(typeof(PipelineBehavior1<DummyRequest, Guid>)));
        Assert.That(registry.PipelineLog[1], Is.EqualTo(typeof(PipelineBehavior2<DummyRequest, Guid>)));
        Assert.That(registry.PipelineLog[2], Is.EqualTo(typeof(DummyHandler)));
    }

    internal class PipelineBehavior1<T, TResult> : IPipelineBehavior<T, TResult>
    {
        private readonly Registry _registry;

        public PipelineBehavior1(Registry registry) => _registry = registry;

        public Task<TResult> HandleAsync(HandlerContext<T> inputContext, Func<Task<TResult>> next)
        {
            _registry.PipelineLog.Add(GetType());
            return next();
        }
    }

    internal class PipelineBehavior2<T, TResult> : IPipelineBehavior<T, TResult>
    {
        private readonly Registry _registry;

        public PipelineBehavior2(Registry registry) => _registry = registry;

        public Task<TResult> HandleAsync(HandlerContext<T> inputContext, Func<Task<TResult>> next)
        {
            _registry.PipelineLog.Add(GetType());
            return next();
        }
    }

    internal record DummyRequest(Guid Id) : IRequest<Guid>;

    internal class Registry
    {
        public List<Type> PipelineLog { get; } = [];
    }

    internal class DummyHandler : IRequestHandler<DummyRequest, Guid>
    {
        private readonly Registry _registry;

        public DummyHandler(Registry registry) => _registry = registry;

        public async Task<Guid> HandleAsync(HandlerContext<DummyRequest> handlerContext)
        {
            await Task.Delay(1); // Simulate some async work
            _registry.PipelineLog.Add(GetType());
            return handlerContext.Message.Id;
        }
    }
}
