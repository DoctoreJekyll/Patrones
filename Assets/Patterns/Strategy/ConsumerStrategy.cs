using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class ConsumerStrategy
    {

        private IDataStore dataStore;

        public ConsumerStrategy(IDataStore data)
        {
            this.dataStore = data;
        }

        public void Save()
        {
            Data data = new Data("Holi", 100);
            dataStore.SetData(data, "Dato00");
        }

        public void Load()
        {
            Data data = dataStore.GetData<Data>("Dato00");
            Debug.Log(data.dato2);
        }

    }
}
