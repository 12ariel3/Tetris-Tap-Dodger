namespace Assets.Code.Common.UpgradesData
{
    public interface UpgradesSystem
    {
        float GetUpgradeHp();
        public void SaveUpgradeHp(float upgradeHp);
        float GetUpgradeFire();
        public void SaveUpgradeFire(float upgradeFire);
        float GetUpgradePoison();
        public void SaveUpgradePoison(float upgradePoison);
        float GetUpgradeIce();
        public void SaveUpgradeIce(float upgradeIce);
        float GetUpgradeWater();
        public void SaveUpgradeWater(float upgradeWater);
        float GetUpgradeElectric();
        public void SaveUpgradeElectric(float upgradeElectric);
        float GetUpgradeGhost();
        public void SaveUpgradeGhost(float upgradeGhost);
        float GetUpgradeRainbow();
        public void SaveUpgradeRainbow(float upgradeRainbow);
        float GetUpgradeEnergy();
        public void SaveUpgradeEnergy(float upgradeEnergy);
    }
}