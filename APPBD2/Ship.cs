namespace APPBD2;

public class Ship
{
    private string name { get; set; }
    private double maxSpeedInKnots { get; set; }
    private int maxContainersCount { get; set; }
    private double maxWeightInTons { get; set; }

    private double ActuallContainerWeight { get; set; }
    
    private List<Container> containers = new List<Container>();

    public Ship(string name, double maxSpeedInKnots, int maxContainersCount, double maxWeightInTons)
    {
        this.name = name;
        this.maxSpeedInKnots = maxSpeedInKnots;
        this.maxContainersCount = maxContainersCount;
        this.maxWeightInTons = maxWeightInTons;
    }

    public void AddContainer(Container container)
    {
        if (containers.Count < this.maxContainersCount && ActuallContainerWeight + container.getLoad() < this.maxWeightInTons * 1000)
        {
            this.containers.Add(container);
            ActuallContainerWeight += container.getLoad();
        }
        else
        { 
            Console.WriteLine("Failed to add container [" + container.getSerialNumber() + "] There is too many containers or max weight threshold is exceeded");
        }
    }
    
    public void  AddContainer(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (containers.Count < this.maxContainersCount && ActuallContainerWeight + container.getLoad() < this.maxWeightInTons * 1000)
            {
                this.containers.Add(container);
                ActuallContainerWeight += container.getLoad();
            }
            else
            {
                Console.WriteLine("Failed to add container [" + container.getSerialNumber() + "] There is too many containers or max weight threshold is exceeded");
            }
        }
    }

    public void unloadContainer(Container container)
    {
        container.emptyLoad();
    }
    
    public void DropContainer(string serialNumber)
    {
        int index = findContainerSerialNumber(serialNumber);
        if (index != -1)
        {
            this.containers.RemoveAt(index);
        } else
        {
            Console.WriteLine("No container with the serial number " + serialNumber);
        }
        
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = findContainerSerialNumber(serialNumber);
        if (index != -1)
        {
            if (containers.Count < this.maxContainersCount &&
                ActuallContainerWeight + newContainer.getLoad() < this.maxWeightInTons * 1000)
            {
                this.containers.RemoveAt(index);
                this.containers.Add(newContainer);
            }
        } else
        {
            Console.WriteLine("No container with the serial number " + serialNumber);
        }
    }

    public void MoveContainer(Container sourceContainer, Ship targetShip)
    {
        bool flag = false;
        if (targetShip.containers.Count < targetShip.maxContainersCount &&
            ActuallContainerWeight + sourceContainer.getLoad() < targetShip.maxWeightInTons * 1000)
        {
            foreach (Container container in this.containers)
            {
                if (container == sourceContainer)
                {
                    targetShip.AddContainer(container);
                    flag = true;
                    Console.WriteLine("Moved container " + sourceContainer.getSerialNumber());
                }
            }
        
            if (flag == false)
            {
                Console.WriteLine("No container on this ship with the serial number " + sourceContainer.getSerialNumber());
            }
            else
            {
                this.containers.Remove(sourceContainer);
            }
        }
    }

    public List<Container> getContainers()
    {
        return this.containers;
    }

    public override string ToString()
    {
        return $"Name: {name}\n" +
               $"Max Speed (knots): {maxSpeedInKnots}\n" +
               $"Max Containers Count: {maxContainersCount}";
    }


    public void showInfo()
    {
        Console.WriteLine(this.ToString());
    }

    public void showFullInfo()
    {
        Console.WriteLine(this.ToString());

        foreach (Container container in this.containers)
        {
            Console.WriteLine(container.ToString());
        }
    }

    public int findContainerSerialNumber(string serialNumber)
    {
        for (int i = 0; i < this.containers.Count; i++)
        {
            if (this.containers[i].getSerialNumber() == serialNumber)
            {
                return i;
            }
        }
        return -1;
    }
    
}