## Vehicle Rental System 

## Approach
I applied the principles of Object-Oriented Programming and SOLID to ensure good design. I began by making the abstract vehicle class so it can centralize common functionality and provide flexibility about the type of vehicle used in Invoice.
Then I implemented each of the Car,MotorCycle and CargoVan classes by inheriting the vehicle class while adding speicific attributes and behaviour. Then finally I created the invoice class 
that has several methods for calculations and print method that displays all the data needed for invoice.

### Classes

1.Vehicle Class (Abstract)
   - This is a class that serves as a base class for the different type of vehicles
   - It contains common properties with validation and constructor.
   - Declares abstract methods which are implemented in the child classes

2. Car, Motorcycle, CargoVan Classes
   - Inherit from the Vehicle class.
   - Implement the methods delcared in the parent class following the specific reuqirments.
   - Each of these classes has specific property that is added.

3. Invoice Class
   - Contains method for printing invoices for vehicle rentals.
   - Calculates total rental and insurance costs, including potential early return discounts.
