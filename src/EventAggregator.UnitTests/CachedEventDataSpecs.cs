using NUnit.Framework;
using SpecUnit;

namespace EventAggregator.UnitTests
{
	public class CachedEventDataSpecs
	{

		public class EventData
		{
			public string SomeData { get; set; }

			public EventData(string someData)
			{
				SomeData = someData;
			}
		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_requesting_data_for_a_previously_published_event : ContextSpecification
		{
			private EventData eventData;

			protected override void Context()
			{
				EventPublisher publisher = new EventPublisher();

				publisher.Publish(new EventData("1st"));
				publisher.Publish(new EventData("2nd"));

				eventData = publisher.GetMostRecentPublication<EventData>();
			}

			[Test]
			[Observation]
			public void Should_provide_the_most_recently_published_data()
			{
				eventData.SomeData.ShouldEqual("2nd");
			}
		}

		[TestFixture]
		[Concern("Pub/Sub Events")]
		public class When_requesting_data_for_an_event_that_has_not_been_published : ContextSpecification
		{
			private EventData eventData;

			protected override void Context()
			{
				EventPublisher publisher = new EventPublisher();

				eventData = publisher.GetMostRecentPublication<EventData>();
			}

			[Test]
			[Observation]
			public void Should_not_provide_any_data()
			{
				eventData.ShouldBeNull();
			}
		}

	}
}