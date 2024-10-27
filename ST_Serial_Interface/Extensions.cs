namespace ST_Serial_Interface
{
    public static class MyExtensions
    {
        public static float Map(this float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            // Custom mapping function
            return (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow) + toLow;
        }

        public static float ToFahrenheit(this float value)
        {
            return (value * 9) / 5 + 32;
        }

        public static float ToKPH(this float value)
        {
            return value * 1.60934f;
        }
    }
}
