using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherForecast : Observer, DisplayElement
    {
        private float currentTemp = 0;
        private float lastTemp;
        private WeatherData weatherData;

        public WeatherForecast(WeatherData wd)
        {
            weatherData = wd;
            weatherData.registerObserver(this);
        }
        public void display()
        {
            Console.Out.WriteLine("Forecast: ");
            if(currentTemp > lastTemp)
            {
                Console.Out.WriteLine("Improving weather on the way");
            }
            else if (currentTemp< lastTemp)
            {
                Console.Out.WriteLine("Watch out cooler weather");
            }
            else
            {
                Console.Out.WriteLine("Temp more of the same");
            }
        }

        public void update(float temperature, string condition)
        {
            lastTemp = currentTemp;
            currentTemp = temperature;
        }
    }
}
