using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class CurrentConditionsDisplay : IObserver<WeatherData>
    {
        WeatherData data;
        private IDisposable unsubscriber;
        public CurrentConditionsDisplay()
        {

        }
        public CurrentConditionsDisplay(IObservable<WeatherData> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }
        public void Display()
        {
            
        }

        public void Subscribe(IObservable<WeatherData> provider)
        {
            if (unsubscriber == null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public void OnCompleted()
        {
            Console.WriteLine("Additional temperature data will not be transmitted.");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Some error has occurred..");
        }

        public void OnNext(WeatherData value)
        {
            this.data = value;
            Display();
        }
    }
}

