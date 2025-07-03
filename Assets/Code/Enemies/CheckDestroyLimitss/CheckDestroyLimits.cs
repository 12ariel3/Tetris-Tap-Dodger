using UnityEngine;

namespace Assets.Code.Enemies.CheckDestroyLimitss
{
    public interface CheckDestroyLimits
    {
        bool IsInsideTheLimits(Vector3 position);
    }
}