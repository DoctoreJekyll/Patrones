using UnityEngine;

namespace Ships.Weapons
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private string id;
        public string Id => id;
    }
}
