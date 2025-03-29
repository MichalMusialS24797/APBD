namespace APPBD2;

public static class LoadClassifier
{
    public static readonly Dictionary<LoadType, LoadRiskLevel> LoadRiskMap = new()
    {
        { LoadType.Fuel, LoadRiskLevel.Dangerous },
        { LoadType.Food, LoadRiskLevel.Normal }
    };
}
