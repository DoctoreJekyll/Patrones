using UnityEngine;
using System;
using System.Collections.Generic;

namespace Ships.Weapons
{
    public class ProjectileFactory : MonoBehaviour
    {
        
        //Esto es un factory relativamente funcional pero para generar OPCLO un diccionario donde el string sea la id y el objeto sea el prefab que instanciamos nos puede ayidar
        [SerializeField] private Projectile[] projectiles;
        private Dictionary<string, Projectile> projectileDictionary;

        private void Awake()
        {
            //Inicializamos diccionario
            projectileDictionary = new Dictionary<string, Projectile>();
            //Recorremos la lista y asignamos el id de cada projectil y el objeto projectil(Donde hablo de projectil esto puede ser "Objeto")
            foreach (Projectile projectile in projectiles)
            {
                projectileDictionary.Add(projectile.Id, projectile);
            }
        }

        public Projectile Create(string id, Transform initTransform, Quaternion rotation)
        {
            if (!projectileDictionary.TryGetValue(id, out Projectile projectile))
            {
                throw new Exception($"Projectile with {id} does not exist");
            }
            
            return Instantiate(projectile, initTransform.position ,rotation);
        }



    }
}
