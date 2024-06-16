namespace VehicleRentalSystem
{
	internal class CargoVan : Vehicle
	{
		private int drivingExperience;

		public int DrivingExperience
		{
			get { return drivingExperience; }
			set
			{
				if (value < 0)
					throw new ArgumentException($"DrivingExperience in {this.GetType()} cannot be negative!");
				drivingExperience = value;
			}
		}
		public CargoVan(string brand, string model, decimal value, int drivingExpereience) : base(brand, model, value)
		{
			DrivingExperience = drivingExpereience;
		}
		public override decimal CostPerDay(int rentDays)
		{
			return rentDays <= 7 ? 50 : 40;
		}
		public override decimal InitialInsurancePerDay
		{
			get => 0.0003m * VehicleValue;
		}

		public override decimal InsurancePerDay()
		{
			return 0.0003m * VehicleValue * (DrivingExperience > 5 ? 0.85m : 1m);
		}
	}
}
