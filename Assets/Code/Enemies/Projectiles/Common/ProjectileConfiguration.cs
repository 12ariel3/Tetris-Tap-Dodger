using Assets.Code.Enemies.CheckDestroyLimitss;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles.Common
{
    public class ProjectileConfiguration
    {
        public readonly CheckDestroyLimits CheckDestroyLimits;

        public readonly ProjectileId ProjectileId;
        public readonly Transform DirectionPosition;
        public readonly string Name;
        public readonly string ExplosionName;
        public readonly int Score;
        public readonly int Gems;
        public readonly int GemsProbability;
        public readonly int Experience;
        public readonly bool IsSpecial;
       
        public readonly int Level;
        public readonly int MaxHp;
        public readonly int Attack;
        public readonly int ColorAndType;
        public readonly float ProjectileSpeed;


        public ProjectileConfiguration(string name, string explosionName, int score, int gems, int gemsProbability, int experience, int level,
                                       int maxHp, int attack, ProjectileId projectileId, Transform directionPosition,
                                       CheckDestroyLimits checkDestroyLimits,
                                       bool isSpecial, int colorAndType, float projectileSpeed)
        {
            Name = name;
            ExplosionName = explosionName;
            Score = score;
            Gems = gems;
            GemsProbability = gemsProbability;
            Experience = experience;
            Level = level;
            MaxHp = maxHp;
            Attack = attack;
            ProjectileId = projectileId;
            DirectionPosition = directionPosition;
            CheckDestroyLimits = checkDestroyLimits;
            IsSpecial = isSpecial;
            ColorAndType = colorAndType;
            ProjectileSpeed = projectileSpeed;
        }
    }
}