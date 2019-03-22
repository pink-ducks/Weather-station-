using System.Collections;

namespace WeatherApp
{
    public class WeatherData : Subject
    {
        private ArrayList observers;
        private float temperature;
        private string condition;
        public WeatherData()
        {
            observers = new ArrayList();
        }
        public void registerObserver(Observer o)
        {
            observers.Add(o);
        }
        public void removeObserver(Observer o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.Remove(i);
            }
        }
        public void notifyObservers()
        {
            for (int i = 0; i < observers.Count; i++)
            {
                Observer observer = (Observer)observers[i];
                observer.update(temperature, condition);
            }
        }
        public void measurementsChanged()
        {
            notifyObservers();
        }
        public void setMeasurements(float temp, string condition)
        {
            temperature = temp;
            this.condition = condition;
            measurementsChanged();
        }
    }
}