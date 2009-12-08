using System;
using NUnit.Framework;
using Rhino.Mocks;
using SpecUnit;

namespace EventAggregator.UnitTests
{
	public class EventAggregatorSpecs
	{

		public class EventData
		{
			public string SomeData { get; set; }

			public EventData(string someData)
			{
				SomeData = someData;
			}
		}

		public class SecondEvent { }

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_publishing_an_event_and_one_handler_for_the_event_is_registered : ContextSpecification
		{

			private IEventHandler<EventData> _handler;
			private string _eventData;

			protected override void Context()
			{
				_handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				_handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						_eventData = data.SomeData;
						return true;
					});

				IEventPublisher eventPublisher = new EventPublisher();
				eventPublisher.RegisterHandler(_handler);
				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_call_registered_handler()
			{
				_handler.AssertWasCalled(h => h.Handle(null), mo => mo.IgnoreArguments().Repeat.Once());
			}

			[Test]
			[Observation]
			public void Should_provide_the_event_data_to_the_handler()
			{
				_eventData.ShouldEqual("My Event Data");
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_publishing_an_event_and_more_than_one_handler_for_the_event_is_registered : ContextSpecification
		{

			private IEventHandler<EventData> _handler1;
			private IEventHandler<EventData> _handler2;

			private string _eventData1;
			private string _eventData2;

			protected override void Context()
			{
				_handler1 = MockRepository.GenerateMock<IEventHandler<EventData>>();
				_handler1.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						_eventData1 = data.SomeData;
						return true;
					});

				_handler2 = MockRepository.GenerateMock<IEventHandler<EventData>>();
				_handler2.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						_eventData2 = data.SomeData;
						return true;
					});

				IEventPublisher eventPublisher = new EventPublisher();
				eventPublisher.RegisterHandler(_handler1);
				eventPublisher.RegisterHandler(_handler2);
				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_call_all_registered_handlers()
			{
				_handler1.AssertWasCalled(h => h.Handle(null), mo => mo.IgnoreArguments().Repeat.Once());
				_handler2.AssertWasCalled(h => h.Handle(null), mo => mo.IgnoreArguments().Repeat.Once());
			}

			[Test]
			[Observation]
			public void Should_provide_the_event_data_to_all_handlers()
			{
				_eventData1.ShouldEqual("My Event Data");
				_eventData2.ShouldEqual("My Event Data");
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_publishing_an_event_and_no_handlers_are_registered : ContextSpecification
		{
			private Exception _caughtException;

			protected override void Context()
			{
				try
				{
					IEventPublisher eventPublisher = new EventPublisher();
					eventPublisher.Publish(new EventData("My Event Data"));
				}
				catch (Exception ex)
				{
					_caughtException = ex;
				}
			}

			[Test]
			[Observation]
			public void Should_not_throw_any_exceptions_or_do_anything_else()
			{
				_caughtException.ShouldBeNull();
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_publishing_an_event_and_a_handler_for_a_different_event_is_registered : ContextSpecification
		{

			private IEventHandler<SecondEvent> _handler1;

			protected override void Context()
			{
				_handler1 = MockRepository.GenerateMock<IEventHandler<SecondEvent>>();
				
				IEventPublisher eventPublisher = new EventPublisher();
				eventPublisher.RegisterHandler(_handler1);
				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_not_call_all_registered_handler()
			{
				_handler1.AssertWasNotCalled(h => h.Handle(null), mo => mo.IgnoreArguments());
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_a_registered_event_handler_publishes_another_event : ContextSpecification
		{

			private IEventHandler<EventData> _handler1;
			private IEventHandler<SecondEvent> _handler2;
			private bool _eventTwoWasHandled;

			protected override void Context()
			{
				IEventPublisher eventPublisher = new EventPublisher();

				_handler1 = MockRepository.GenerateMock<IEventHandler<EventData>>();
				_handler1.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						eventPublisher.Publish(new SecondEvent());
						return true;
					});

				_handler2 = MockRepository.GenerateMock<IEventHandler<SecondEvent>>();
				_handler2.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(SecondEvent data)
					{
						_eventTwoWasHandled = true;
						return true;
					});

				eventPublisher.RegisterHandler(_handler1);
				eventPublisher.RegisterHandler(_handler2);

				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_publish_the_second_event()
			{
				_eventTwoWasHandled.ShouldBeTrue();
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_a_registered_event_handler_publishes_an_event_of_the_same_type : ContextSpecification
		{

			private IEventHandler<EventData> _handler;

			protected override void Context()
			{
				IEventPublisher eventPublisher = new EventPublisher();

				_handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				_handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						eventPublisher.Publish(new EventData("Second Event"));
						return true;
					});

				eventPublisher.RegisterHandler(_handler);
				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_only_publish_the_event_once()
			{
				_handler.AssertWasCalled(h => h.Handle(null), mo => mo.IgnoreArguments().Repeat.Once());
			}

		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_an_event_handler_has_been_unregistered_and_an_event_is_published : ContextSpecification
		{

			private IEventHandler<EventData> _handler;

			protected override void Context()
			{
				_handler = MockRepository.GenerateMock<IEventHandler<EventData>>();

				IEventPublisher eventPublisher = new EventPublisher();

				eventPublisher.RegisterHandler(_handler);
				eventPublisher.UnregisterHandler(_handler);

				eventPublisher.Publish(new EventData("My Event Data"));
			}

			[Test]
			[Observation]
			public void Should_no_longer_call_that_event_hander()
			{
				_handler.AssertWasNotCalled(h => h.Handle(null), mo => mo.IgnoreArguments());
			}

		}

	}
}