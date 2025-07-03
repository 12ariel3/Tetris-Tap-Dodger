namespace Assets.Code.Common.EnergyData
{
    public interface EnergySystem
    {
        float GetTotalEnergy();
        public void SaveTotalEnergy(float totalEnergy);
        float GetActualEnergy();
        public void SaveActualEnergy(float actualEnergy);

        void SetEnergyValues();
        void SaveLastDateEnergyRecovered(string dateEnergyRecoveredToSave);
        string GetLastDateEnergyRecovered();
    }
}