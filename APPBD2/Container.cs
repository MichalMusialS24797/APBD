namespace APPBD2;

public class Container
{
    private double load_mass = 0.0; 
    private double container_height, container_mass, container_depth, max_load;
    private string serial_number;
    private static int counter = 1;
    private ContainerType container_type;
    
    public Container(ContainerType containerType, double maxLoad, double containerHeight, double containerMass, double containerDepth)
    {
        this.container_type = containerType;
        this.max_load = maxLoad;
        this.container_height = containerHeight;
        this.container_mass = containerMass;
        this.container_depth = containerDepth;

        char typeCode = (char)containerType;
        serial_number = $"KON-{typeCode}-{counter++}";
    }
    
    public virtual void setLoad(double load_mass)
    {
        if (load_mass > max_load)
        {
            throw new OverfillException($"za duzy ladunek {load_mass}. Max load to {max_load}.");
        }
        
        this.load_mass = load_mass;
    }

    public double getLoad()
    {
        return this.load_mass;
    }
    
    public double getMaxLoad()
    {
        return this.max_load;
    }
    
    public void setMaxLoad(double max_load)
    {
        this.max_load = max_load;
    }
    
    public virtual void emptyLoad()
    {
        setLoad(0);
    }
    
    public String getSerialNumber()
    {
        return this.serial_number;
    }
    public override string ToString()
    {
        return $"Container {{ " +
               $"LoadMass = {load_mass}, " +
               $"ContainerHeight = {container_height}, " +
               $"ContainerMass = {container_mass}, " +
               $"ContainerDepth = {container_depth}, " +
               $"SerialNumber = '{serial_number}', " +
               $"MaxLoad = {max_load}, " +
               $"ContainerType = {container_type} " +
               $"}}";
    }

    public void showInfo()
    {
        Console.WriteLine(this.ToString());
    }

}