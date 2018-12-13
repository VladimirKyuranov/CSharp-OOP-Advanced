namespace Travel.Entities.Airplanes
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // migrated from java. please do the needful kind sir
    public abstract class Airplane : IAirplane {
		private List<IBag> baggageCompartment;
        private List<IPassenger> passengers;
        public Airplane(int seats, int bagsCount) {
			this.passengers = new List<IPassenger>();
			this.Seats = seats;
			this.BaggageCompartments = bagsCount;
			this.baggageCompartment = new List<IBag>();
		}
		public int Seats { get; }
		public int BaggageCompartments { get; }
		public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();
        public IReadOnlyCollection<IPassenger> Passengers => this.passengers.AsReadOnly();
		public bool IsOverbooked => this.Passengers.Count() > this.Seats;
        public void AddPassenger(IPassenger passenger) {
			this.passengers.Add(passenger);
		}
		public IPassenger RemovePassenger(int seat) {
			// mdrchd
			var passenger = this.passengers[seat];

			this.passengers.RemoveAt(seat);

			return passenger;
		}

		public IEnumerable<IBag>EjectPassengerBags(IPassenger passenger) {
			var passengerBags = this.baggageCompartment
                .Where(b => b.Owner == passenger)
				.ToArray();

            foreach (var bag in passengerBags)
            {
                this.baggageCompartment.Remove(bag);
            }

			return passengerBags;
		}

		public void LoadBag(IBag bag) {
			var isBaggageCompartmentFull = this.baggageCompartment.Count() > this.BaggageCompartments;
			if (isBaggageCompartmentFull)
				throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");

			this.baggageCompartment.Add(bag);
		}
	}
}