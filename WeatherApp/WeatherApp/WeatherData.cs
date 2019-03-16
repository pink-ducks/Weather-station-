namespace WeatherApp
{
    public partial class MainWindow
    {
        class WeatherData 
        {
            public int Temperature { get; set; }
            private string Condition { get; set; }
            int GetTemperature()
            { return 0; }
            string GetConidtion()
            { return ""; }

        }
    }
}
