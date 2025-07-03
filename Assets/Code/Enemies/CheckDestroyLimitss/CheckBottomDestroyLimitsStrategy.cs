using UnityEngine;

namespace Assets.Code.Enemies.CheckDestroyLimitss
{
    public class CheckBottomDestroyLimitsStrategy : CheckDestroyLimits
    {
        public bool IsInsideTheLimits(Vector3 position)
        {
            if (position.y < -12)
            {
                return false;
            }
            return true;
        }
    }
}