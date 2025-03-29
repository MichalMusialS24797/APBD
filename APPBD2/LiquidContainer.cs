using System.Transactions;

namespace APPBD2;

public class LiquidContainer : Container, IHazardNotifier
{

    public LiquidContainer(double maxLoad, double containerHeight, double containerMass, double containerDepth)
        : base(ContainerType.Liquid, maxLoad, containerHeight, containerMass, containerDepth)
    {
        Console.WriteLine("Creating Liquid Container");
        Console.WriteLine($"{getSerialNumber()}");
    }
    
    public void setLoad(double load_mass, LoadType loadType)
    {
        var risk = LoadClassifier.LoadRiskMap[loadType];

        if (risk == LoadRiskLevel.Dangerous && (load_mass/getMaxLoad()) * 100 > 50)
        {
            Console.WriteLine("Cannot Load Dangerous Liquid Container");
            NotifyHazard();
        } else if(risk == LoadRiskLevel.Normal && (load_mass / getMaxLoad()) * 100 > 90)
        {
            Console.WriteLine("Cannot Load Normal Liquid Container");
            NotifyHazard();
        } else
        {
            Console.WriteLine("Loading Liquid Container");
            base.setLoad(load_mass);
        }
        
        
    }

    public void NotifyHazard()
    {
        Console.WriteLine("@@@ [WARNING] @@@ Dangerous situation occured on: " + this.getSerialNumber());
    }
}