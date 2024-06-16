namespace VehicleRentalSystem
{
	internal class Invoice
	{
		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException($"The name of {this.GetType()} cannot be empty!");
				name = value;
			}
		}
		public Vehicle Vehicle { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public DateTime ActualReturnDate { get; set; }
		public int RentDays => (EndDate - StartDate).Days;
		public int ActualRentDays => (ActualReturnDate - StartDate).Days;
		public int DaysEarly => RentDays - ActualRentDays;
		public Invoice(string name, Vehicle vehicle, DateTime startDate, DateTime endDate, DateTime actualReturnDate)
		{
			Name = name;
			Vehicle = vehicle;
			StartDate = startDate;
			EndDate = endDate;
			ActualReturnDate = actualReturnDate;
		}
		public void PrintInvoice()
		{
			decimal rentalCost = GetRentalCost();
			decimal insuranceCost = GetInsuranceCost();
			decimal totalCost = rentalCost + insuranceCost;

			Console.WriteLine("XXXXXXXXXX");
			Console.WriteLine($"Date: {DateTime.Now:yyyy-MM-dd}");
			Console.WriteLine($"Customer Name: {Name}");
			Console.WriteLine($"Rented Vehicle: {Vehicle.Brand} {Vehicle.Model}");
			Console.WriteLine();

			Console.WriteLine($"Reservation start date: {StartDate:yyyy-MM-dd}");
			Console.WriteLine($"Reservation end date: {EndDate:yyyy-MM-dd}");
			Console.WriteLine($"Reserved rental days: {RentDays} days");
			Console.WriteLine();

			Console.WriteLine($"Actual return date: {ActualReturnDate:yyyy-MM-dd}");
			Console.WriteLine($"Actual rental days: {ActualRentDays} days");
			Console.WriteLine();

			Console.WriteLine($"Rental cost per day: ${Vehicle.CostPerDay(RentDays).ToString("F2")}");
			InsurancePrint(Vehicle.InitialInsurancePerDay, Vehicle.InsurancePerDay());
			Console.WriteLine();

			if (RentDays - ActualRentDays > 0)
			{
				Console.WriteLine($"Early return discount for rent: ${GetEarlyDiscountRent().ToString("F2")}");
				Console.WriteLine($"Early return discount for insurance: ${GetEarlyDiscountInsurance().ToString("F2")}");
				Console.WriteLine();
			}

			Console.WriteLine($"Total rent: ${rentalCost.ToString("F2")}");
			Console.WriteLine($"Total insurance: ${insuranceCost.ToString("F2")}");
			Console.WriteLine($"Total: ${totalCost.ToString("F2")}");
			Console.WriteLine("XXXXXXXXXX");
			Console.WriteLine();
		}
		public void InsurancePrint(decimal initialInsurancePerDay, decimal insurancePerDay)
		{
			if (initialInsurancePerDay != insurancePerDay)
			{
				Console.WriteLine($"Initial insurance per day: ${initialInsurancePerDay.ToString("F2")}");
				decimal difference = Math.Abs(initialInsurancePerDay - insurancePerDay);
				Console.WriteLine($"Insurance {(initialInsurancePerDay > insurancePerDay ? "discount" : "addition")} per day: ${difference.ToString("F2")}");
			}

			Console.WriteLine($"Insurance per day: ${insurancePerDay.ToString("F2")}");
		}
		public decimal GetRentalCost()
		{
			return Vehicle.CostPerDay(ActualRentDays) * ActualRentDays + (Vehicle.CostPerDay(ActualRentDays) / 2) * DaysEarly;
		}

		public decimal GetInsuranceCost()
		{
			return Vehicle.InsurancePerDay() * ActualRentDays;
		}

		public decimal GetEarlyDiscountRent()
		{
			return (Vehicle.CostPerDay(ActualRentDays) / 2) * DaysEarly;
		}
		public decimal GetEarlyDiscountInsurance()
		{
			return Vehicle.InsurancePerDay() * DaysEarly;
		}
	}
}
