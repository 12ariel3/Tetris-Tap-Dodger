using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerConfiguration
    {
        public readonly PlayerId PlayerId;

        //Player base stats
        public readonly int Level;
        public readonly int BaseHp;
        public readonly float BaseFire;
        public readonly float BasePoison;
        public readonly float BaseIce;
        public readonly float BaseWater;
        public readonly float BaseElectric;
        public readonly float BaseGhost;
        public readonly float BaseRainbow;

        //Trail stats
        public readonly int TrailHp;
        public readonly float TrailFire;
        public readonly float TrailPoison;
        public readonly float TrailIce;
        public readonly float TrailWater;
        public readonly float TrailElectric;
        public readonly float TrailGhost;
        public readonly float TrailRainbow;
        public readonly Sprite UnevolvedSprite;
        public readonly Sprite EvolvedSprite;
        public readonly float TrailLevel;

        //Upgrades stats
        public readonly float UpgradesHp;
        public readonly float UpgradesFire;
        public readonly float UpgradesPoison;
        public readonly float UpgradesIce;
        public readonly float UpgradesWater;
        public readonly float UpgradesElectric;
        public readonly float UpgradesGhost;
        public readonly float UpgradesRainbow;



        public PlayerConfiguration(int level, int baseHp,
                                   float baseFire, float basePoison, float baseIce,
                                   float baseWater, float baseElectric, float baseGhost,
                                   float baseRainbow, PlayerId playerId,


                                   int trailHp,
                                   float trailFire, float trailPoison, float trailIce,
                                   float trailWater, float trailElectric, float trailGhost,
                                   float trailRainbow, Sprite unevolvedSprite, Sprite evolvedSprite, float trailLevel,


                                   float upgradesHp,
                                   float upgradesFire, float upgradesPoison, float upgradesIce,
                                   float upgradesWater, float upgradesElectric, float upgradesGhost,
                                   float upgradesRainbow)
        {
            Level = level;
            BaseHp = baseHp;
            BaseFire = baseFire;
            BasePoison = basePoison;
            BaseIce = baseIce;
            BaseWater = baseWater;
            BaseElectric = baseElectric;
            BaseGhost = baseGhost;
            BaseRainbow = baseRainbow;
            PlayerId = playerId;


            TrailHp = trailHp;
            TrailFire = trailFire;
            TrailPoison = trailPoison;
            TrailIce = trailIce;
            TrailWater = trailWater;
            TrailGhost = trailGhost;
            TrailElectric = trailElectric;
            TrailRainbow = trailRainbow;
            UnevolvedSprite = unevolvedSprite;
            EvolvedSprite = evolvedSprite;
            TrailLevel = trailLevel;


            UpgradesHp = upgradesHp;
            UpgradesFire = upgradesFire;
            UpgradesPoison = upgradesPoison;
            UpgradesIce = upgradesIce;
            UpgradesWater = upgradesWater;
            UpgradesGhost = upgradesGhost;
            UpgradesElectric = upgradesElectric;
            UpgradesRainbow = upgradesRainbow;
        }
    }
}