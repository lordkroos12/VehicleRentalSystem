namespace VehicleRentalSystem
{
	internal class Motorcycle : Vehicle
	{
		private int age;

		public int Age
		{
			get { return age; }
			set
			{
				if (value < 0)
					throw new ArgumentException($"The age of {this.GetType()} cannot be negative!");
				age = value;
			}
		}
		public Motorcycle(string brand, string model, decimal value, int age) : base(brand, model, value)
		{
			this.Age = age;
		}
		public override decimal InitialInsurancePerDay
		{
			get => 0.0002m * VehicleValue;
		}
		public override decimal CostPerDay(int rentDays)
		{
			return rentDays <= 7 ? 15 : 10;
		}

		public override decimal InsurancePerDay()
		{
			return 0.0002m * VehicleValue * (Age < 25 ? 1.2m : 1m);
		}
	}
}
