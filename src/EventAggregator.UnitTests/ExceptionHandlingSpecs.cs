using System;
using NUnit.Framework;
using Rhino.Mocks;
using SpecUnit;

namespace EventAggregator.UnitTests
{
	public class ExceptionHandlingSpecs
	{

		public class EventData { }

		[TestFixture]
		[Concern("General Exception Handling")]
		public class When_an_eventhandler_throws_an_exception_and_a_general_error_handler_is_registered : ContextSpecification
		{

			private IEventHandler<EventData> _handler;
			private string errorMessage = "Testing exception handling";
			private Exception caughtException;
			private bool handlerExecuted;

			private IEventHandler<EventData> SetupHandlerToThrowException()
			{
				IEventHandler<EventData> handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						throw new Exception(errorMessage);
					});
				return handler;
			}

			protected override void Context()
			{
				_handler = SetupHandlerToThrowException();

				IEventPublisher eventPublisher = new EventPublisher();

				eventPublisher.OnHandlerError(ex =>
					{
						handlerExecuted = true;
						caughtException = ex;
					});
				
				eventPublisher.RegisterHandler(_handler);
				eventPublisher.Publish(new EventData());
			}


			[Test]
			[Observation]
			public void Should_execute_the_configured_root_level_exception_handler_for_the_event_aggreator()
			{
				handlerExecuted.ShouldBeTrue();
			}

			[Test]
			[Observation]
			public void Should_provide_the_exception_to_the_error_handler()
			{
				caughtException.Message.ShouldEqual(errorMessage);
			}

		}

		[TestFixture]
		[Concern("General Exception Handling")]
		public class When_multiple_exceptions_are_thrown_from_multiple_handlers_and_a_general_error_handler_is_registered : ContextSpecification
		{

			private IEventHandler<EventData> _handler;
			private IEventHandler<EventData> _handler2;
			private string errorMessage = "Testing exception handling";
			private int handlerExecutedCount;

			private IEventHandler<EventData> SetupHandlerToThrowException()
			{
				IEventHandler<EventData> handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						throw new Exception(errorMessage);
					});
				return handler;
			}

			protected override void Context()
			{
				handlerExecutedCount = 0;
				_handler = SetupHandlerToThrowException();
				_handler2 = SetupHandlerToThrowException();

				IEventPublisher eventPublisher = new EventPublisher();

				eventPublisher.OnHandlerError(ex =>
					{
						handlerExecutedCount += 1;
					});

				eventPublisher.RegisterHandler(_handler);
				eventPublisher.RegisterHandler(_handler2);
				eventPublisher.Publish(new EventData());
			}


			[Test]
			[Observation]
			public void Should_handle_all_thrown_exceptions()
			{
				handlerExecutedCount.ShouldEqual(2);
			}

		}

		[TestFixture]
		[Concern("General Exception Handling")]
		public class When_an_eventhandler_throws_an_exception_and_no_error_handlers_are_configured : ContextSpecification
		{

			private IEventHandler<EventData> _handler;
			private string errorMessage = "Testing exception handling";
			private Exception caughtException;

			private IEventHandler<EventData> SetupHandlerToThrowException()
			{
				IEventHandler<EventData> handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						throw new Exception(errorMessage);
					});
				return handler;
			}

			protected override void Context()
			{
				_handler = SetupHandlerToThrowException();

				IEventPublisher eventPublisher = new EventPublisher();
				eventPublisher.RegisterHandler(_handler);
				
				try
				{
					eventPublisher.Publish(new EventData());
				}
				catch(Exception ex)
				{
					caughtException = ex;
				}
			}

			[Test]
			[Observation]
			public void Should_not_rethrow_or_bubble_up_the_exception()
			{
				caughtException.ShouldBeNull();
			}

		}

		[TestFixture]
		[Concern("Specific Event Handler, Exception Handling")]
		public class When_an_event_handler_has_an_associated_exception_handler_and_the_throws_an_exception : ContextSpecification
		{

			private IEventHandler<EventData> _handler;
			private string errorMessage = "Testing exception handling";
			private bool errorHandled;
			private Exception caughtException;

			private IEventHandler<EventData> SetupHandlerToThrowException()
			{
				IEventHandler<EventData> handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						throw new Exception(errorMessage);
					});
				return handler;
			}

			protected override void Context()
			{
				_handler = SetupHandlerToThrowException();

				IEventPublisher eventPublisher = new EventPublisher();
				eventPublisher.RegisterHandler(_handler)
					.WithErrorHandler(ex =>
						{
							errorHandled = true;
							caughtException = ex;
						});

				eventPublisher.Publish(new EventData());
			}

			[Test]
			[Observation]
			public void Should_handle_the_error_with_the_specified_error_handler()
			{
				errorHandled.ShouldBeTrue();	
			}

			[Test]
			[Observation]
			public void Should_provide_the_exception_to_the_error_handler()
			{
				caughtException.Message.ShouldEqual(errorMessage);
			}

		}

		[TestFixture]
		[Concern("Specific Event Handler, Exception Handling")]
		public class when_one_event_handler_throws_an_exception : ContextSpecification
		{

			private IEventHandler<EventData> throwingHandler;
			private IEventHandler<EventData> catchingHandler;
			
			private string errorMessage = "Testing exception handling";
			private Exception caughtException;

			private IEventHandler<EventData> SetupHandlerToThrowException()
			{
				IEventHandler<EventData> handler = MockRepository.GenerateMock<IEventHandler<EventData>>();
				handler.Stub(h => h.Handle(null)).IgnoreArguments().Callback(delegate(EventData data)
					{
						throw new Exception(errorMessage);
					});
				return handler;
			}

			protected override void Context()
			{
				throwingHandler = SetupHandlerToThrowException();
				catchingHandler = MockRepository.GenerateMock<IEventHandler<EventData>>();

				IEventPublisher eventPublisher = new EventPublisher();

				eventPublisher.RegisterHandler(throwingHandler);
				eventPublisher.RegisterHandler(catchingHandler)
					.WithErrorHandler(ex =>
						{
							caughtException = ex;
						});				

				eventPublisher.Publish(new EventData());
			}

			[Test]
			[Observation]
			public void Another_event_handlers_error_handler_should_not_catch_it()
			{
				caughtException.ShouldBeNull();
			}

		}

	}
}