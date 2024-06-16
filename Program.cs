namespace VehicleRentalSystem
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Vehicle car = new Car("Mitsubishi", "Mirage", 15000m, 3);
			Vehicle motorcycle = new Motorcycle("Triumph", "Tiger Sport 660", 10000m,20);
			Vehicle cargoVan = new CargoVan("Citroen", "Jumper", 20000m,8);

			Invoice carInvoice = new Invoice("John doe", car, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
			Invoice motorcycleInvoice = new Invoice("Mary Johnson",motorcycle, new DateTime(2024, 6, 3), new DateTime(2024, 6, 13), new DateTime(2024, 6, 13));
			Invoice cargoVanInvoice = new Invoice("John Markson", cargoVan, new DateTime(2024, 6, 3), new DateTime(2024, 6, 18), new DateTime(2024, 6, 13));

			carInvoice.PrintInvoice();
			motorcycleInvoice.PrintInvoice();
			cargoVanInvoice.PrintInvoice();
		}
	}
}
