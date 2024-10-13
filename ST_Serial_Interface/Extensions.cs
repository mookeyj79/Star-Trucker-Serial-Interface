namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static float Map(this float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            // Custom mapping function
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }
    }
}
