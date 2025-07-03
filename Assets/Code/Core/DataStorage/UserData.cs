using System;

namespace Assets.Code.Core.DataStorage
{
    [Serializable]
    public class UserData
    {
        public int TotalScore = 0;
        public int TotalGems = 0;
        public float ActualEnergy = 20;
        public float TotalEnergy = 20;
        public int PlayerLevel = 1;
        public int PlayerExp;
        public int PlayerCurrentMaxExp;
        public string SwordEquippedName = "Basic";

        //Settings

        public float MainMenuMusicIntensity = .35f;
        public float GameMusicIntensity = .2f;
        public float SwordIntensity = .3f;
        public float ProjectileIntensity = .4f;
        public float UISoundIntensity = .6f;
        public bool IsVibrationActived = true;


        //Upgrades

        public float UpgradesHp = 0;
        public float UpgradesFire = 0;
        public float UpgradesPoison = 0;
        public float UpgradesIce = 0;
        public float UpgradesWater = 0;
        public float UpgradesElectric = 0;
        public float UpgradesGhost = 0;
        public float UpgradesEnergy = 0;
        public float UpgradesRainbow = 0;

        //Airplanes

        public int BasicSword = 1;
        public int WildSword = 1;
        public int SteelerSword = 1;
        public int WoodenSword = 1;
        public int HypothermiaSword = 1;
        public int GaiaSword = 1;
        public int QuakerSword = 1;
        public int DizzySword = 1;
        public int SanctusSword = 1;
        public int StunnerSword = 1;
        public int FoxgloveSword = 1;
        public int CerberusSword = 1;
        public int DeathsideSword = 1;
        public int MeteorSword = 1;
        public int TornadoSword = 1;
        public int LagoonSword = 1;
        public int RainbowSword = 1;
        public int ThunderboltSword = 1;
        public int BlazeSword = 1;
        public int IrisSword = 1;
       


        public bool BasicSwordIsUnlocked = true;
        public bool WildSwordIsUnlocked = false;
        public bool SteelerSwordIsUnlocked = false;
        public bool WoodenSwordIsUnlocked = false;
        public bool HypothermiaSwordIsUnlocked = false;
        public bool GaiaSwordIsUnlocked = false;
        public bool QuakerSwordIsUnlocked = false;
        public bool DizzySwordIsUnlocked = false;
        public bool SanctusSwordIsUnlocked = false;
        public bool StunnerSwordIsUnlocked = false;
        public bool FoxgloveSwordIsUnlocked = false;
        public bool CerberusSwordIsUnlocked = false;
        public bool DeathsideSwordIsUnlocked = false;
        public bool MeteorSwordIsUnlocked = false;
        public bool TornadoSwordIsUnlocked = false;
        public bool LagoonSwordIsUnlocked = false;
        public bool RainbowSwordIsUnlocked = false;
        public bool ThunderboltSwordIsUnlocked = false;
        public bool BlazeSwordIsUnlocked = false;
        public bool IrisSwordIsUnlocked = false;


        //Nodes

        public bool HpNode0 = false;
        public bool HpNode1 = false;
        public bool HpNode2 = false;
        public bool HpNode3 = false;
        public bool HpNode4 = false;
        public bool HpNode5 = false;
        public bool HpNode6 = false;
        public bool HpNode7 = false;
        public bool HpNode8 = false;
        public bool HpNode9 = false;
        public bool HpNode10 = false;
        public bool HpNode11 = false;
        public bool FireNode0 = false;
        public bool FireNode1 = false;
        public bool FireNode2 = false;
        public bool FireNode3 = false;
        public bool FireNode4 = false;
        public bool FireNode5 = false;
        public bool PoisonNode0 = false;
        public bool PoisonNode1 = false;
        public bool PoisonNode2 = false;
        public bool PoisonNode3 = false;
        public bool PoisonNode4 = false;
        public bool PoisonNode5 = false;
        public bool IceNode0 = false;
        public bool IceNode1 = false;
        public bool IceNode2 = false;
        public bool IceNode3 = false;
        public bool IceNode4 = false;
        public bool IceNode5 = false;
        public bool WaterNode0 = false;
        public bool WaterNode1 = false;
        public bool WaterNode2 = false;
        public bool WaterNode3 = false;
        public bool WaterNode4 = false;
        public bool WaterNode5 = false;
        public bool ElectricNode0 = false;
        public bool ElectricNode1 = false;
        public bool ElectricNode2 = false;
        public bool ElectricNode3 = false;
        public bool ElectricNode4 = false;
        public bool ElectricNode5 = false;
        public bool GhostNode0 = false;
        public bool GhostNode1 = false;
        public bool GhostNode2 = false;
        public bool GhostNode3 = false;
        public bool GhostNode4 = false;
        public bool GhostNode5 = false;
        public bool RainbowNode0 = false;
        public bool RainbowNode1 = false;
        public bool RainbowNode2 = false;
        public bool RainbowNode3 = false;
        public bool RainbowNode4 = false;
        public bool RainbowNode5 = false;
        public bool EnergyNode0 = false;
        public bool EnergyNode1 = false;
        public bool EnergyNode2 = false;
        public bool EnergyNode3 = false;
        public bool EnergyNode4 = false;
        public bool EnergyNode5 = false;


        public bool HpNodeAvailable0 = true;
        public bool HpNodeAvailable1 = false;
        public bool HpNodeAvailable2 = false;
        public bool HpNodeAvailable3 = false;
        public bool HpNodeAvailable4 = false;
        public bool HpNodeAvailable5 = false;
        public bool HpNodeAvailable6 = false;
        public bool HpNodeAvailable7 = false;
        public bool HpNodeAvailable8 = false;
        public bool HpNodeAvailable9 = false;
        public bool HpNodeAvailable10 = false;
        public bool HpNodeAvailable11 = false;
        public bool FireNodeAvailable0 = false;
        public bool FireNodeAvailable1 = false;
        public bool FireNodeAvailable2 = false;
        public bool FireNodeAvailable3 = false;
        public bool FireNodeAvailable4 = false;
        public bool FireNodeAvailable5 = false;
        public bool PoisonNodeAvailable0 = false;
        public bool PoisonNodeAvailable1 = false;
        public bool PoisonNodeAvailable2 = false;
        public bool PoisonNodeAvailable3 = false;
        public bool PoisonNodeAvailable4 = false;
        public bool PoisonNodeAvailable5 = false;
        public bool IceNodeAvailable0 = false;
        public bool IceNodeAvailable1 = false;
        public bool IceNodeAvailable2 = false;
        public bool IceNodeAvailable3 = false;
        public bool IceNodeAvailable4 = false;
        public bool IceNodeAvailable5 = false;
        public bool WaterNodeAvailable0 = false;
        public bool WaterNodeAvailable1 = false;
        public bool WaterNodeAvailable2 = false;
        public bool WaterNodeAvailable3 = false;
        public bool WaterNodeAvailable4 = false;
        public bool WaterNodeAvailable5 = false;
        public bool ElectricNodeAvailable0 = false;
        public bool ElectricNodeAvailable1 = false;
        public bool ElectricNodeAvailable2 = false;
        public bool ElectricNodeAvailable3 = false;
        public bool ElectricNodeAvailable4 = false;
        public bool ElectricNodeAvailable5 = false;
        public bool GhostNodeAvailable0 = false;
        public bool GhostNodeAvailable1 = false;
        public bool GhostNodeAvailable2 = false;
        public bool GhostNodeAvailable3 = false;
        public bool GhostNodeAvailable4 = false;
        public bool GhostNodeAvailable5 = false;
        public bool RainbowNodeAvailable0 = false;
        public bool RainbowNodeAvailable1 = false;
        public bool RainbowNodeAvailable2 = false;
        public bool RainbowNodeAvailable3 = false;
        public bool RainbowNodeAvailable4 = false;
        public bool RainbowNodeAvailable5 = false;
        public bool EnergyNodeAvailable0 = false;
        public bool EnergyNodeAvailable1 = false;
        public bool EnergyNodeAvailable2 = false;
        public bool EnergyNodeAvailable3 = false;
        public bool EnergyNodeAvailable4 = false;
        public bool EnergyNodeAvailable5 = false;


        // Maps And Levels

        public string MaxMapReached = "Moon Walker";
        public string LastMapPlayed = "Moon Walker";
        public int MaxLevelReached = 1;
        public int LastLevelPlayed = 1;
        public bool IsNewLevelPlayed = false;
        public bool IsLastMapLevelPlayed = false;
        public bool IsFirstUpdate = true;

        public bool IsMoonWalkerPassed = false;
        public bool IsAtlansAbyssPassed = false;
        public bool IsVillaSoldatiPassed = false;
        public bool IsRaklionPassed = false;
        public bool IsAcheronPassed = false;

        public bool IsGameReviewed = false;
        public bool IsCongratulationsViewed = false;



        public string LastDateEnergyRecovered = "None";

        public bool AdsWereRemoved = false;

        public int LocaleSelector = 0;
    }
}