using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WeatherApp
{
       public class WeatherData
        {
            public float Temperature { get; set; }
            private string Condition { get; set; }
           public WeatherData(float temp, string cond)
            {
                this.Temperature = temp;
                this.Condition = cond;

            }
        }
    }
