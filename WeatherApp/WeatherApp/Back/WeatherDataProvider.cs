using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class WeatherDataProvider : IObservable<WeatherData>
    {
        List<IObserver<WeatherData>> observers;
        public WeatherDataProvider()
        {
            observers = new List<IObserver<WeatherData>>();
        }
        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new UnSubscriber(observers, observer);
        }
        private class UnSubscriber : IDisposable
        {
            private List<IObserver<WeatherData>> lstObservers;
            private IObserver<WeatherData> observer;

            public UnSubscriber(List<IObserver<WeatherData>> ObserversCollection,
                                IObserver<WeatherData> observer)
            {
                this.lstObservers = ObserversCollection;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (this.observer != null)
                {
                    lstObservers.Remove(this.observer);
                }
            }
        }

        private void MeasurementsChanged(float temp, string cond)
        {
            foreach (var obs in observers)
            {
                obs.OnNext(new WeatherData(temp, cond));
            }
        }

        public void SetMeasurements(float temp, string cond)
        {
            MeasurementsChanged(temp,cond);
        }
    }

}
