using System;
using System.Collections.Generic;
using Ships.Weapons.Projectiles;
using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Factory/Create ShipConfiguration", fileName = "ShipConfiguration", order = 1)]
    public class ShipConfiguration : ScriptableObject
    {
        //Esto es un factory relativamente funcional pero para generar OPCLO un diccionario donde el string sea la id y el objeto sea el prefab que instanciamos nos puede ayidar
        [SerializeField] private ShipMediator[] ships;
        private Dictionary<string, ShipMediator> shipDictionary;

        private void Awake()
        {
            //Inicializamos diccionario
            shipDictionary = new Dictionary<string, ShipMediator>();
            //Recorremos la lista y asignamos el id de cada projectil y el objeto projectil(Donde hablo de projectil esto puede ser "Objeto")
            foreach (ShipMediator ship in ships)
            {
                shipDictionary.Add(ship.ShipId.Id, ship);
            }
        }

        public ShipMediator GetShipUpByID(string id)
        {
            if (!shipDictionary.TryGetValue(id, out ShipMediator ship))
            {
                throw new Exception($"Projectile with {id} does not exist");
            }

            return ship;
        }
    }
}