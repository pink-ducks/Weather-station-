using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class StatisticsDisplay : Observer, DisplayElement
    {
        private float maxTemp;
        private float minTemp;
        private WeatherData weatherDate;
        public StatisticsDisplay(WeatherData wd)
        {
            weatherDate = wd;
            wd.registerObserver(this);
        }
        public void display()
        {
            Console.Out.WriteLine("Temp:" );
        }

        public void update(float temp, string condition)
        {
            if(temp > maxTemp)
            {
                maxTemp = temp;
            }
            if(temp < minTemp)
            {
                minTemp = temp;
            }
            display();
        }
    }
}
