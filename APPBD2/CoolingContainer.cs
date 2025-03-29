namespace APPBD2;

public class CoolingContainer : Container, IHazardNotifier
{
    private readonly string product;
    private readonly double temperature;
    
    Dictionary<string, double> productTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    public CoolingContainer(string product, double temperature, double maxLoad, double containerHeight, double containerMass, double containerDepth)
        : base(ContainerType.Cooling, maxLoad, containerHeight, containerMass, containerDepth)
    {
        if (temperature > productTemperatures[$"{product}"])
        {
            this.temperature = temperature;
            this.product = product;
            Console.WriteLine("Creating Gas Container");
            Console.WriteLine($"{getSerialNumber()}");
        }
        else
        {
            Console.WriteLine("Cannot create Cooling Container! temperature is too low to store this product");
        }
    }


    public void setLoad(double load_mass, string product) 
    {
        if (product == this.product)
        {
            base.setLoad(load_mass);
        }
        else
        {
            NotifyHazard();
        }
    }


    public void NotifyHazard()
    {
        Console.WriteLine("@@@ [WARNING] @@@ Dangerous situation occured on: " + this.getSerialNumber());
    }
}