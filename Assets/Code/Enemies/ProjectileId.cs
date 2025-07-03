using UnityEngine;

namespace Assets.Code.Enemies
{
    [CreateAssetMenu(menuName = "Projectile/ProjectileId", fileName = "ProjectileId", order = 0)]
    public class ProjectileId : ScriptableObject
    {
        [SerializeField] private string _value;

        public string Value => _value;
    }
}