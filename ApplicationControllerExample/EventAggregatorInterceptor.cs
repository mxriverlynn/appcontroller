using System;
using EventAggregator;
using StructureMap;
using StructureMap.Interceptors;

namespace ApplicationControllerExample
{

	public class EventAggregatorInterceptor : TypeInterceptor
	{

		public object Process(object target, IContext context)
		{
			context.GetInstance<IEventPublisher>().RegisterHandlers(target);
			return target;
		}

		public bool MatchesType(Type type)
		{
			return type.ImplementsInterfaceTemplate(typeof(IEventHandler<>));
		}


	}

}