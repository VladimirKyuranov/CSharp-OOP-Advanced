// REMOVE any "using" statements, which start with "Travel." BEFORE SUBMITTING
using Travel.Core.Controllers;
using Travel.Entities;
using Travel.Entities.Airplanes;
using Travel.Entities.Items;

namespace Travel.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class FlightControllerTests
    {
        [Test]
        public void SuccesfullFlight()
        {
            var airport = new Airport();
            var flightController = new FlightController(airport);
            var airplane = new LightAirplane();
            var trip = new Trip("Plovdiv", "Las Vegas", airplane);

            List<Passenger> passengers = new List<Passenger>()
            {
                new Passenger("Pesho"),
                new Passenger("Gosho"),
                new Passenger("Ivan"),
                new Passenger("Maria"),
                new Passenger("Stamat"),
                new Passenger("Kiro")
            };

            passengers.ForEach(p => airplane.AddPassenger(p));

            var bag = new Bag(passengers[1], new[] { new Colombian() });
            passengers[1].Bags.Add(bag);

            airport.AddTrip(trip);

            var completedTrip = new Trip("LA", "Sofia", new LightAirplane());
            completedTrip.Complete();

            airport.AddTrip(completedTrip);

            var actualResult = flightController.TakeOff();

            var expectedResult =
                @"PlovdivLas Vegas1:
Overbooked! Ejected Gosho
Confiscated 1 bags ($50000)
Successfully transported 5 passengers from Plovdiv to Las Vegas.
Confiscated bags: 1 (1 items) => $50000";

            Assert.That(actualResult, Is.EqualTo(expectedResult).NoClip);
            Assert.That(trip.IsCompleted, Is.True);
        }
    }
}