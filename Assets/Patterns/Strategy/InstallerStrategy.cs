using System;
using Patterns.Adapter;
using UnityEngine;

namespace Patterns.Strategy
{
    public class InstallerStrategy : MonoBehaviour
    {
        private void Awake()
        {
            ConsumerStrategy consumer = new ConsumerStrategy(GetDataStore());
            consumer.Save();
            consumer.Load();
        }
        
        private IDataStore GetDataStore()
        {
            return new PlayerPrefsAdapter();
        }
    }
}