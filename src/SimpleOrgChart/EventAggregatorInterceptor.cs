using System;
using EventAggregator;
using StructureMap;
using StructureMap.Interceptors;

namespace SimpleOrgChart
{
	public class EventAggregatorInterceptor : TypeInterceptor
	{

		public object Process(object target, IContext context)
		{
			IEventPublisher eventPublisher = context.GetInstance<IEventPublisher>();
			eventPublisher.RegisterHandlers(target);
			return target;
		}

		public bool MatchesType(Type type)
		{
			bool matchesType = type.ImplementsInterfaceTemplate(typeof(IEventHandler<>));
			return matchesType;
		}
	}
}