namespace Logic_Layer.AlgoritmRatings
{
    public interface IRatingSettings
    {
        double BiggestPercentIAB { get; set; }
        double IabToleranceTier1 { get; set; }
        double IabToleranceTier2 { get; set; }
        int MaximumRatings { get; set; }
        double PadTolerance { get; set; }
    }
}