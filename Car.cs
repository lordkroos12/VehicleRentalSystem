namespace VehicleRentalSystem
{
	internal class Car : Vehicle
	{
		private int safetyRating;

		public int SafetyRating
		{
			get { return safetyRating; }
			set
			{
				if (value < 1 || value > 5)
					throw new ArgumentException($"The safety rating of {this.GetType()} has to be between 1 and 5!");
				safetyRating = value;
			}
		}


		public override decimal InitialInsurancePerDay
		{
			get => 0.0001m * VehicleValue;
		}

		public Car(string brand, string model, decimal value, int safetyRating) : base(brand, model, value)
		{
			this.SafetyRating = safetyRating;
		}
		public override decimal CostPerDay(int rentDays)
		{
			return rentDays <= 7 ? 20 : 15;
		}

		public override decimal InsurancePerDay()
		{
			return 0.0001m * VehicleValue * (SafetyRating >= 4 ? 0.9m : 1m);
		}
	}
}
