using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Patterns.Adapter
{
    public class Consumer : MonoBehaviour
    {
        private IDataStore dataStore;

        private void Awake()
        {
            //Guardamos datos
            dataStore = GetDataStore();
            Data data = new Data("Dato1", 123);
            dataStore.SetData(data, "Data1");
        }

        private IDataStore GetDataStore()
        {
            return new PlayerPrefsAdapter();
        }

        private void Start()
        {
            //Cargamos datos
            Data data = dataStore.GetData<Data>("Data1");
            Debug.Log(data.dato1);
            Debug.Log(data.dato2);
        }
    }
}
