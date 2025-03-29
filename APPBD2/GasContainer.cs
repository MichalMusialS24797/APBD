namespace APPBD2;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double maxLoad, double containerHeight, double containerMass, double containerDepth)
        : base(ContainerType.Gas, maxLoad, containerHeight, containerMass, containerDepth)
    {
        Console.WriteLine("Creating Gas Container");
        Console.WriteLine($"{getSerialNumber()}");
    }
    
    public override void emptyLoad()
    {
        setLoad(getMaxLoad() * 0.05); 
        Console.WriteLine("Empty gas container");
    }
    
    public void setLoad(double load_mass)
    {
        if (load_mass + getLoad() > (getMaxLoad() * 0.90))
        {
            NotifyHazard();
        }
        else
        {
            // To dziala, ale ma problem taki, ze mamy tu doczynienia z walidacja na podstawie wartosci a nie typu operacji. Jesli bedziemy chcieli dopelnic koneneter iloscia odpoiwadajaca getMaxLoad() * 0.05 to wtedy oprozni kontener.. 
            if (load_mass == getMaxLoad() * 0.05)
            {
                base.setLoad(load_mass);
            }
            else
            {
                base.setLoad(load_mass + getLoad());
            }
        }
    }


    public void NotifyHazard()
    {
        Console.WriteLine("@@@ [WARNING] @@@ Dangerous situation occured on: " + this.getSerialNumber());
    }
}