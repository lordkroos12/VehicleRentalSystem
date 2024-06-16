using System.Globalization;

namespace VehicleRentalSystem
{
	internal abstract class Vehicle
	{
		private string brand;

		public string Brand
		{
			get { return brand; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException($"Brand in {this.GetType} cannot be empty!");
				brand = value;
			}
		}


		private string model;

		public string Model
		{
			get { return model; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException($"Model in {this.GetType} cannot be empty!");
				model = value;
			}
		}


		private decimal vehicleValue;

		public decimal VehicleValue
		{
			get { return vehicleValue; }
			set
			{
				if (value <= 0)
					throw new ArgumentException($"VehicleValue in {this.GetType} cannot be less or equal to 0!");
				vehicleValue = value;
			}
		}

        public Vehicle(string brand, string model,decimal vehicleValue)
        {
			this.Brand = brand;
			this.Model = model;
			this.VehicleValue = vehicleValue;
        }
        public abstract decimal InitialInsurancePerDay { get; }

        public abstract decimal CostPerDay(int rentDays);
		public abstract decimal InsurancePerDay();
	}
}
