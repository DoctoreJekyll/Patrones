using UnityEngine;

namespace Ships
{
    [CreateAssetMenu(menuName = "Create Ship", fileName = "ShipId", order = 0)]
    public class ShipId : ScriptableObject
    {
        [SerializeField] private string id;
        public string Id => id;
    }
}
