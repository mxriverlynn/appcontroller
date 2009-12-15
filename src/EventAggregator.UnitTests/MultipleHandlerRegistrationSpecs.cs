using System;
using NUnit.Framework;
using SpecUnit;

namespace EventAggregator.UnitTests
{
	public class MultipleHandlerRegistrationSpecs
	{

		public class FirstEvent { }

		public class SecondEvent { }

		[TestFixture]
		public class Given_a_class_that_implements_multiple_event_handlers
		{

			public class MultipleHandlerClass : IEventHandler<FirstEvent>, IEventHandler<SecondEvent>
			{
				public bool Handler1WasCalled;
				public bool Handler2WasCalled;
				public int Handler1Count;
				public int Handler2Count;

				public void Handle(FirstEvent eventData)
				{
					Handler1WasCalled = true;
					Handler1Count += 1;
				}

				public void Handle(SecondEvent eventData)
				{
					Handler2WasCalled = true;
					Handler2Count += 1;
				}
			}

			[TestFixture]
			[Concern("Registering Multiple Event Handlers")]
			public class When_registering_that_class_and_publishing_the_events_it_handles : ContextSpecification
			{

				MultipleHandlerClass multipleHandlers;

				protected override void Context()
				{
					multipleHandlers = new MultipleHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandlers(multipleHandlers);

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());
				}

				[Test]
				[Observation]
				public void Should_be_able_to_publish_events_to_all_handlers_in_that_class()
				{
					multipleHandlers.Handler1WasCalled.ShouldBeTrue();
					multipleHandlers.Handler2WasCalled.ShouldBeTrue();
				}

			}

			[TestFixture]
			[Concern("Unregistering Multiple Event Handlers")]
			public class When_unregistering_that_class_and_publishing_the_events_that_it_handled : ContextSpecification
			{

				MultipleHandlerClass multipleHandlers;

				protected override void Context()
				{
					multipleHandlers = new MultipleHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandlers(multipleHandlers);

					eventPublisher.UnregisterHandlers(multipleHandlers);

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());
				}

				[Test]
				[Observation]
				public void Should_no_longer_handle_the_published_events()
				{
					multipleHandlers.Handler1WasCalled.ShouldBeFalse();
					multipleHandlers.Handler2WasCalled.ShouldBeFalse();
				}

			}

			[TestFixture]
			[Concern("Registering And Unregistering Handlers")]
			public class When_registering_one_handler_explicitly_and_then_unregistering_all_handlers_for_the_class : ContextSpecification
			{

				MultipleHandlerClass multipleHandlers;
				private Exception unregisteringException;

				protected override void Context()
				{
					multipleHandlers = new MultipleHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandler<FirstEvent>(multipleHandlers);

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());

					try
					{
						eventPublisher.UnregisterHandlers(multipleHandlers);
					}
					catch (Exception ex)
					{
						unregisteringException = ex;
					}

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());
				}

				[Test]
				[Observation]
				public void Should_only_register_the_one_handler()
				{
					multipleHandlers.Handler1WasCalled.ShouldBeTrue();
					multipleHandlers.Handler2WasCalled.ShouldBeFalse();
				}

				[Test]
				[Observation]
				public void Should_not_throw_any_exceptions_when_unregistering()
				{
					unregisteringException.ShouldBeNull();
				}

				[Test]
				[Observation]
				public void Should_unregister_the_handler()
				{
					multipleHandlers.Handler1Count.ShouldEqual(1);
					multipleHandlers.Handler2Count.ShouldEqual(0);
				}

			}

		}

		[TestFixture]
		public class Given_a_class_that_implements_multiple_event_handlers_as_explicit_interfaces
		{

			public class MultipleHandlerClass : IEventHandler<FirstEvent>, IEventHandler<SecondEvent>
			{
				public bool Handler1WasCalled;
				public bool Handler2WasCalled;

				void IEventHandler<FirstEvent>.Handle(FirstEvent eventData)
				{
					Handler1WasCalled = true;
				}

				void IEventHandler<SecondEvent>.Handle(SecondEvent eventData)
				{
					Handler2WasCalled = true;
				}
			}

			[TestFixture]
			[Concern("Registering Multiple Event Handlers")]
			public class When_registering_that_class_and_publishing_the_events_it_handles : ContextSpecification
			{

				MultipleHandlerClass multipleHandlers;

				protected override void Context()
				{
					multipleHandlers = new MultipleHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandlers(multipleHandlers);

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());
				}

				[Test]
				[Observation]
				public void Should_be_able_to_publish_events_to_all_handlers_in_that_class()
				{
					multipleHandlers.Handler1WasCalled.ShouldBeTrue();
					multipleHandlers.Handler2WasCalled.ShouldBeTrue();
				}

			}

			[TestFixture]
			[Concern("Unregistering Multiple Event Handlers")]
			public class When_unregistering_that_class_and_publishing_the_events_that_it_handled : ContextSpecification
			{

				MultipleHandlerClass multipleHandlers;

				protected override void Context()
				{
					multipleHandlers = new MultipleHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandlers(multipleHandlers);

					eventPublisher.UnregisterHandlers(multipleHandlers);

					eventPublisher.Publish(new FirstEvent());
					eventPublisher.Publish(new SecondEvent());
				}

				[Test]
				[Observation]
				public void Should_no_longer_handle_the_published_events()
				{
					multipleHandlers.Handler1WasCalled.ShouldBeFalse();
					multipleHandlers.Handler2WasCalled.ShouldBeFalse();
				}

			}

		}

		[TestFixture]
		public class Given_multiple_classes_registering_for_the_same_event
		{

			public class FirstHandlerClass : IEventHandler<FirstEvent>
			{
				public bool HandlerWasCalled;
				public int HandlerCount;

				public void Handle(FirstEvent eventData)
				{
					HandlerWasCalled = true;
					HandlerCount += 1;
				}
			}

			public class SecondHandlerClass : IEventHandler<FirstEvent>
			{
				public bool HandlerWasCalled;
				public int HandlerCount;

				public void Handle(FirstEvent eventData)
				{
					HandlerWasCalled = true;
					HandlerCount += 1;
				}
			}

			[TestFixture]
			[Concern("Registering Multiple Event Handlers")]
			public class When_unregistering_one_event_handler_and_then_publishing_the_event : ContextSpecification
			{

				FirstHandlerClass firstHandler;
				SecondHandlerClass secondHandler;

				protected override void Context()
				{
					firstHandler = new FirstHandlerClass();
					secondHandler = new SecondHandlerClass();

					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.RegisterHandlers(firstHandler);
					eventPublisher.RegisterHandlers(secondHandler);

					eventPublisher.UnregisterHandler(firstHandler);

					eventPublisher.Publish(new FirstEvent());
				}

				[Test]
				[Observation]
				public void Should_not_be_handled_by_the_removed_event_handler()
				{
					firstHandler.HandlerWasCalled.ShouldBeFalse();
				}

				[Test]
				[Observation]
				public void Should_be_handled_by_the_remaining_event_handler()
				{
					secondHandler.HandlerWasCalled.ShouldBeTrue();
				}

			}
		}
	}
}