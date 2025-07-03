using Assets.Code.Common.Events;
using Assets.Code.Core.DataStorage;
using Assets.Code.Core;

namespace Assets.Code.Common.Level
{
    public class SwordsLevelSystemImpl : EventObserver, SwordsLevelSystem
    {
        private readonly DataStore _dataStore;
        private const string _basicAirplaneLevelData = "BasicAirplaneLevelData";
        private const string _wildAirplaneLevelData = "WildAirplaneLevelData";
        private const string _steelerAirplaneLevelData = "SteelerAirplaneLevelData";
        private const string _woodenAirplaneLevelData = "WoodenAirplaneLevelData";
        private const string _hypothermiaAirplaneLevelData = "HypothermiaAirplaneLevelData";
        private const string _gaiaAirplaneLevelData = "GaiaAirplaneLevelData";
        private const string _quakerAirplaneLevelData = "QuakerAirplaneLevelData";
        private const string _dizzyAirplaneLevelData = "DizzyAirplaneLevelData";
        private const string _sanctusAirplaneLevelData = "SanctusAirplaneLevelData";
        private const string _stunnerAirplaneLevelData = "StunnerAirplaneLevelData";
        private const string _foxgloveAirplaneLevelData = "FoxgloveAirplaneLevelData";
        private const string _cerberusAirplaneLevelData = "CerberusAirplaneLevelData";
        private const string _deathsideAirplaneLevelData = "DeathsideAirplaneLevelData";
        private const string _meteorAirplaneLevelData = "MeteorAirplaneLevelData";
        private const string _tornadoAirplaneLevelData = "TornadoAirplaneLevelData";
        private const string _lagoonAirplaneLevelData = "LagoonAirplaneLevelData";
        private const string _rainbowAirplaneLevelData = "RainbowAirplaneLevelData";
        private const string _thunderboltAirplaneLevelData = "ThunderboltAirplaneLevelData";
        private const string _blazeAirplaneLevelData = "BlazeAirplaneLevelData";
        private const string _irisAirplaneLevelData = "IrisAirplaneLevelData";


        private const string _basicAirplaneIsUnlockedData = "BasicAirplaneIsUnlockedData";
        private const string _wildAirplaneIsUnlockedData = "WildAirplaneIsUnlockedData";
        private const string _steelerAirplaneIsUnlockedData = "SteelerAirplaneIsUnlockedData";
        private const string _woodenAirplaneIsUnlockedData = "WoodenAirplaneIsUnlockedData";
        private const string _hypothermiaAirplaneIsUnlockedData = "HypothermiaAirplaneIsUnlockedData";
        private const string _gaiaAirplaneIsUnlockedData = "GaiaAirplaneIsUnlockedData";
        private const string _quakerAirplaneIsUnlockedData = "QuakerAirplaneIsUnlockedData";
        private const string _dizzyAirplaneIsUnlockedData = "DizzyAirplaneIsUnlockedData";
        private const string _sanctusAirplaneIsUnlockedData = "SanctusAirplaneIsUnlockedData";
        private const string _stunnerAirplaneIsUnlockedData = "StunnerAirplaneIsUnlockedData";
        private const string _foxgloveAirplaneIsUnlockedData = "FoxgloveAirplaneIsUnlockedData";
        private const string _cerberusAirplaneIsUnlockedData = "CerberusAirplaneIsUnlockedData";
        private const string _deathsideAirplaneIsUnlockedData = "DeathsideAirplaneIsUnlockedData";
        private const string _meteorAirplaneIsUnlockedData = "MeteorAirplaneIsUnlockedData";
        private const string _tornadoAirplaneIsUnlockedData = "TornadoAirplaneIsUnlockedData";
        private const string _lagoonAirplaneIsUnlockedData = "LagoonAirplaneIsUnlockedData";
        private const string _rainbowAirplaneIsUnlockedData = "RainbowAirplaneIsUnlockedData";
        private const string _thunderboltAirplaneIsUnlockedData = "ThunderboltAirplaneIsUnlockedData";
        private const string _blazeAirplaneIsUnlockedData = "BlazeAirplaneIsUnlockedData";
        private const string _irisAirplaneIsUnlockedData = "IrisAirplaneIsUnlockedData";



        public SwordsLevelSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.SwordLevelUp, this);
        }


        public int GetLevel(string swordId)
        {
            switch (swordId)
            {
                case "Basic":
                    return GetBasicCurrentLevel();

                case "Wild":
                    return GetWildCurrentLevel();
                
                case "Steeler":
                    return GetSteelerCurrentLevel();

                case "Wooden":
                    return GetWoodenCurrentLevel();
                    
                case "Hypothermia":
                    return GetHypothermiaCurrentLevel();

                case "Gaia":
                    return GetGaiaCurrentLevel();
                    
                case "Quaker":
                    return GetQuakerCurrentLevel();

                case "Dizzy":
                    return GetDizzyCurrentLevel();
                    
                case "Sanctus":
                    return GetSanctusCurrentLevel();

                case "Stunner":
                    return GetStunnerCurrentLevel();
                    
                case "Foxglove":
                    return GetFoxgloveCurrentLevel();

                case "Cerberus":
                    return GetCerberusCurrentLevel();
                    
                case "Deathside":
                    return GetDeathsideCurrentLevel();

                case "Meteor":
                    return GetMeteorCurrentLevel();
                    
                case "Tornado":
                    return GetTornadoCurrentLevel();

                case "Lagoon":
                    return GetLagoonCurrentLevel();
                    
                case "Rainbow":
                    return GetRainbowCurrentLevel();

                case "Thunderbolt":
                    return GetThunderboltCurrentLevel();

                case "Blaze":
                    return GetBlazeCurrentLevel();
                    
                case "Iris":
                    return GetIrisCurrentLevel();

                default: return 1;
            }
        }
        public int GetBasicCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_basicAirplaneLevelData)
                        ?? new UserData();
            return userData.BasicSword;
        }
        public int GetWildCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_wildAirplaneLevelData)
                        ?? new UserData();
            return userData.WildSword;
        }
        
        public int GetSteelerCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_steelerAirplaneLevelData)
                        ?? new UserData();
            return userData.SteelerSword;
        }

        public int GetWoodenCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_woodenAirplaneLevelData)
                        ?? new UserData();
            return userData.WoodenSword;
        }
        
        public int GetHypothermiaCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_hypothermiaAirplaneLevelData)
                        ?? new UserData();
            return userData.HypothermiaSword;
        }

        public int GetGaiaCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaAirplaneLevelData)
                        ?? new UserData();
            return userData.GaiaSword;
        }
        
        public int GetQuakerCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_quakerAirplaneLevelData)
                        ?? new UserData();
            return userData.QuakerSword;
        }

        public int GetDizzyCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_dizzyAirplaneLevelData)
                        ?? new UserData();
            return userData.DizzySword;
        }
        
        public int GetSanctusCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_sanctusAirplaneLevelData)
                        ?? new UserData();
            return userData.SanctusSword;
        }

        public int GetStunnerCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_stunnerAirplaneLevelData)
                        ?? new UserData();
            return userData.StunnerSword;
        }
        
        public int GetFoxgloveCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_foxgloveAirplaneLevelData)
                        ?? new UserData();
            return userData.FoxgloveSword;
        }

        public int GetCerberusCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_cerberusAirplaneLevelData)
                        ?? new UserData();
            return userData.CerberusSword;
        }

        public int GetDeathsideCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_deathsideAirplaneLevelData)
                        ?? new UserData();
            return userData.DeathsideSword;
        }

        public int GetMeteorCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_meteorAirplaneLevelData)
                        ?? new UserData();
            return userData.MeteorSword;
        }
        
        public int GetTornadoCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_tornadoAirplaneLevelData)
                        ?? new UserData();
            return userData.TornadoSword;
        }

        public int GetLagoonCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_lagoonAirplaneLevelData)
                        ?? new UserData();
            return userData.LagoonSword;
        }
        
        public int GetRainbowCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_rainbowAirplaneLevelData)
                        ?? new UserData();
            return userData.RainbowSword;
        }

        public int GetThunderboltCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_thunderboltAirplaneLevelData)
                        ?? new UserData();
            return userData.ThunderboltSword;
        }

        public int GetBlazeCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_blazeAirplaneLevelData)
                        ?? new UserData();
            return userData.BlazeSword;
        }
        
        public int GetIrisCurrentLevel()
        {
            var userData = _dataStore.GetData<UserData>(_irisAirplaneLevelData)
                        ?? new UserData();
            return userData.IrisSword;
        }
        


        public void SaveLevel(string swordId, int swordLevel)
        {
            switch (swordId)
            {
                case "Basic":
                    SaveBasicCurrentLevel(swordLevel); break;

                case "Wild":
                    SaveWildCurrentLevel(swordLevel); break;
                    
                case "Steeler":
                    SaveSteelerCurrentLevel(swordLevel); break;

                case "Wooden":
                    SaveWoodenCurrentLevel(swordLevel); break;
                    
                case "Hypothermia":
                    SaveHypothermiaCurrentLevel(swordLevel); break;

                case "Gaia":
                    SaveGaiaCurrentLevel(swordLevel); break;
                    
                case "Quaker":
                    SaveQuakerCurrentLevel(swordLevel); break;

                case "Dizzy":
                    SaveDizzyCurrentLevel(swordLevel); break;
                    
                case "Sanctus":
                    SaveSanctusCurrentLevel(swordLevel); break;

                case "Stunner":
                    SaveStunnerCurrentLevel(swordLevel); break;
                    
                case "Foxglove":
                    SaveFoxgloveCurrentLevel(swordLevel); break;

                case "Cerberus":
                    SaveCerberusCurrentLevel(swordLevel); break;
                    
                case "Deathside":
                    SaveDeathsideCurrentLevel(swordLevel); break;

                case "Meteor":
                    SaveMeteorCurrentLevel(swordLevel); break;
                    
                case "Tornado":
                    SaveTornadoCurrentLevel(swordLevel); break;

                case "Lagoon":
                    SaveLagoonCurrentLevel(swordLevel); break;
                    
                case "Rainbow":
                    SaveRainbowCurrentLevel(swordLevel); break;

                case "Thunderbolt":
                    SaveThunderboltCurrentLevel(swordLevel); break;

                case "Blaze":
                    SaveBlazeCurrentLevel(swordLevel); break;
                    
                case "Iris":
                    SaveIrisCurrentLevel(swordLevel); break;

                default:
                    break;
            }
        }


        public void SaveBasicCurrentLevel(int level)
        {
            var userData = new UserData { BasicSword = level };
            _dataStore.SetData(userData, _basicAirplaneLevelData);
        }

        public void SaveWildCurrentLevel(int level)
        {
            var userData = new UserData { WildSword = level };
            _dataStore.SetData(userData, _wildAirplaneLevelData);
        }
        
        public void SaveSteelerCurrentLevel(int level)
        {
            var userData = new UserData { SteelerSword = level };
            _dataStore.SetData(userData, _steelerAirplaneLevelData);
        }

        public void SaveWoodenCurrentLevel(int level)
        {
            var userData = new UserData { WoodenSword = level };
            _dataStore.SetData(userData, _woodenAirplaneLevelData);
        }
        
        public void SaveHypothermiaCurrentLevel(int level)
        {
            var userData = new UserData { HypothermiaSword = level };
            _dataStore.SetData(userData, _hypothermiaAirplaneLevelData);
        }

        public void SaveGaiaCurrentLevel(int level)
        {
            var userData = new UserData { GaiaSword = level };
            _dataStore.SetData(userData, _gaiaAirplaneLevelData);
        }
        
        public void SaveQuakerCurrentLevel(int level)
        {
            var userData = new UserData { QuakerSword = level };
            _dataStore.SetData(userData, _quakerAirplaneLevelData);
        }

        public void SaveDizzyCurrentLevel(int level)
        {
            var userData = new UserData { DizzySword = level };
            _dataStore.SetData(userData, _dizzyAirplaneLevelData);
        }
        
        public void SaveSanctusCurrentLevel(int level)
        {
            var userData = new UserData { SanctusSword = level };
            _dataStore.SetData(userData, _sanctusAirplaneLevelData);
        }

        public void SaveStunnerCurrentLevel(int level)
        {
            var userData = new UserData { StunnerSword = level };
            _dataStore.SetData(userData, _stunnerAirplaneLevelData);
        }
        
        public void SaveFoxgloveCurrentLevel(int level)
        {
            var userData = new UserData { FoxgloveSword = level };
            _dataStore.SetData(userData, _foxgloveAirplaneLevelData);
        }

        public void SaveCerberusCurrentLevel(int level)
        {
            var userData = new UserData { CerberusSword = level };
            _dataStore.SetData(userData, _cerberusAirplaneLevelData);
        }
        
        public void SaveDeathsideCurrentLevel(int level)
        {
            var userData = new UserData { DeathsideSword = level };
            _dataStore.SetData(userData, _deathsideAirplaneLevelData);
        }

        public void SaveMeteorCurrentLevel(int level)
        {
            var userData = new UserData { MeteorSword = level };
            _dataStore.SetData(userData, _meteorAirplaneLevelData);
        }
        
        public void SaveTornadoCurrentLevel(int level)
        {
            var userData = new UserData { TornadoSword = level };
            _dataStore.SetData(userData, _tornadoAirplaneLevelData);
        }
        
        public void SaveLagoonCurrentLevel(int level)
        {
            var userData = new UserData { LagoonSword = level };
            _dataStore.SetData(userData, _lagoonAirplaneLevelData);
        }
        
        public void SaveRainbowCurrentLevel(int level)
        {
            var userData = new UserData { RainbowSword = level };
            _dataStore.SetData(userData, _rainbowAirplaneLevelData);
        }

        public void SaveThunderboltCurrentLevel(int level)
        {
            var userData = new UserData { ThunderboltSword = level };
            _dataStore.SetData(userData, _thunderboltAirplaneLevelData);
        }

        public void SaveBlazeCurrentLevel(int level)
        {
            var userData = new UserData { BlazeSword = level };
            _dataStore.SetData(userData, _blazeAirplaneLevelData);
        }
        
        public void SaveIrisCurrentLevel(int level)
        {
            var userData = new UserData { IrisSword = level };
            _dataStore.SetData(userData, _irisAirplaneLevelData);
        }




        public bool GetIfIsSwordUnlocked(string swordId)
        {
            switch (swordId)
            {
                case "Basic":
                    return GetBasicIfIsUnlocked();

                case "Wild":
                    return GetWildIfIsUnlocked();
                    
                case "Steeler":
                    return GetSteelerIfIsUnlocked();

                case "Wooden":
                    return GetWoodenIfIsUnlocked();
                    
                case "Hypothermia":
                    return GetHypothermiaIfIsUnlocked();

                case "Gaia":
                    return GetGaiaIfIsUnlocked();
                    
                case "Quaker":
                    return GetQuakerIfIsUnlocked();

                case "Dizzy":
                    return GetDizzyIfIsUnlocked();
                    
                case "Sanctus":
                    return GetSanctusIfIsUnlocked();

                case "Stunner":
                    return GetStunnerIfIsUnlocked();
                    
                case "Foxglove":
                    return GetFoxgloveIfIsUnlocked();

                case "Cerberus":
                    return GetCerberusIfIsUnlocked();
                    
                case "Deathside":
                    return GetDeathsideIfIsUnlocked();

                case "Meteor":
                    return GetMeteorIfIsUnlocked();
                    
                case "Tornado":
                    return GetTornadoIfIsUnlocked();

                case "Lagoon":
                    return GetLagoonIfIsUnlocked();
                    
                case "Rainbow":
                    return GetRainbowIfIsUnlocked();

                case "Thunderbolt":
                    return GetThunderboltIfIsUnlocked();

                case "Blaze":
                    return GetBlazeIfIsUnlocked();
                    
                case "Iris":
                    return GetIrisIfIsUnlocked();

                default: return false;
            }
        }


        public bool GetBasicIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_basicAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.BasicSwordIsUnlocked;
        }
        public bool GetWildIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_wildAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.WildSwordIsUnlocked;
        }
        public bool GetSteelerIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_steelerAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.SteelerSwordIsUnlocked;
        }
        public bool GetWoodenIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_woodenAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.WoodenSwordIsUnlocked;
        }
        public bool GetHypothermiaIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_hypothermiaAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.HypothermiaSwordIsUnlocked;
        }
        public bool GetGaiaIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_gaiaAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.GaiaSwordIsUnlocked;
        }     
        public bool GetQuakerIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_quakerAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.QuakerSwordIsUnlocked;
        }
        public bool GetDizzyIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_dizzyAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.DizzySwordIsUnlocked;
        }
        public bool GetSanctusIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_sanctusAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.SanctusSwordIsUnlocked;
        }
        public bool GetStunnerIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_stunnerAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.StunnerSwordIsUnlocked;
        }
        public bool GetFoxgloveIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_foxgloveAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.FoxgloveSwordIsUnlocked;
        }
        public bool GetCerberusIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_cerberusAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.CerberusSwordIsUnlocked;
        }
        public bool GetDeathsideIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_deathsideAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.DeathsideSwordIsUnlocked;
        }
        public bool GetMeteorIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_meteorAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.MeteorSwordIsUnlocked;
        }
        public bool GetTornadoIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_tornadoAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.TornadoSwordIsUnlocked;
        }
        public bool GetLagoonIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_lagoonAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.LagoonSwordIsUnlocked;
        }
        public bool GetRainbowIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_rainbowAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.RainbowSwordIsUnlocked;
        }
        public bool GetThunderboltIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_thunderboltAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.ThunderboltSwordIsUnlocked;
        }
        public bool GetBlazeIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_blazeAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.BlazeSwordIsUnlocked;
        }
        public bool GetIrisIfIsUnlocked()
        {
            var userData = _dataStore.GetData<UserData>(_irisAirplaneIsUnlockedData)
                        ?? new UserData();
            return userData.IrisSwordIsUnlocked;
        }



        public void SaveIfIsSwordUnlocked(string swordId, bool isSwordUnlocked)
        {
            switch (swordId)
            {
                case "Basic":
                    SaveBasicIfIsUnlocked(isSwordUnlocked); break;

                case "Wild":
                    SaveWildIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Steeler":
                    SaveSteelerIfIsUnlocked(isSwordUnlocked); break;

                case "Wooden":
                    SaveWoodenIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Hypothermia":
                    SaveHypothermiaIfIsUnlocked(isSwordUnlocked); break;

                case "Gaia":
                    SaveGaiaIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Quaker":
                    SaveQuakerIfIsUnlocked(isSwordUnlocked); break;

                case "Dizzy":
                    SaveDizzyIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Sanctus":
                    SaveSanctusIfIsUnlocked(isSwordUnlocked); break;

                case "Stunner":
                    SaveStunnerIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Foxglove":
                    SaveFoxgloveIfIsUnlocked(isSwordUnlocked); break;

                case "Cerberus":
                    SaveCerberusIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Deathside":
                    SaveDeathsideIfIsUnlocked(isSwordUnlocked); break;

                case "Meteor":
                    SaveMeteorIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Tornado":
                    SaveTornadoIfIsUnlocked(isSwordUnlocked); break;

                case "Lagoon":
                    SaveLagoonIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Rainbow":
                    SaveRainbowIfIsUnlocked(isSwordUnlocked); break;

                case "Thunderbolt":
                    SaveThunderboltIfIsUnlocked(isSwordUnlocked); break;

                case "Blaze":
                    SaveBlazeIfIsUnlocked(isSwordUnlocked); break;
                    
                case "Iris":
                    SaveIrisIfIsUnlocked(isSwordUnlocked); break;

                default:
                    break;
            }
        }


        public void SaveBasicIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BasicSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _basicAirplaneIsUnlockedData);
        }

        public void SaveWildIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { WildSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _wildAirplaneIsUnlockedData);
        }
        
        public void SaveSteelerIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { SteelerSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _steelerAirplaneIsUnlockedData);
        }

        public void SaveWoodenIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { WoodenSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _woodenAirplaneIsUnlockedData);
        }
        
        public void SaveHypothermiaIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { HypothermiaSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _hypothermiaAirplaneIsUnlockedData);
        }

        public void SaveGaiaIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { GaiaSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _gaiaAirplaneIsUnlockedData);
        }
        
        public void SaveQuakerIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { QuakerSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _quakerAirplaneIsUnlockedData);
        }

        public void SaveDizzyIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { DizzySwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _dizzyAirplaneIsUnlockedData);
        }
        
        public void SaveSanctusIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { SanctusSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _sanctusAirplaneIsUnlockedData);
        }

        public void SaveStunnerIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { StunnerSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _stunnerAirplaneIsUnlockedData);
        }
        
        public void SaveFoxgloveIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { FoxgloveSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _foxgloveAirplaneIsUnlockedData);
        }

        public void SaveCerberusIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { CerberusSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _cerberusAirplaneIsUnlockedData);
        }
        
        public void SaveDeathsideIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { DeathsideSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _deathsideAirplaneIsUnlockedData);
        }

        public void SaveMeteorIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { MeteorSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _meteorAirplaneIsUnlockedData);
        }
        
        public void SaveTornadoIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { TornadoSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _tornadoAirplaneIsUnlockedData);
        }

        public void SaveLagoonIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { LagoonSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _lagoonAirplaneIsUnlockedData);
        }
        
        public void SaveRainbowIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { RainbowSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _rainbowAirplaneIsUnlockedData);
        }

        public void SaveThunderboltIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { ThunderboltSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _thunderboltAirplaneIsUnlockedData);
        }

        public void SaveBlazeIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { BlazeSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _blazeAirplaneIsUnlockedData);
        }
        public void SaveIrisIfIsUnlocked(bool isUnlocked)
        {
            var userData = new UserData { IrisSwordIsUnlocked = isUnlocked };
            _dataStore.SetData(userData, _irisAirplaneIsUnlockedData);
        }



        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordLevelUp)
            {
                var swordLevelUpEventData = (SwordLevelUpEventData)eventData;
                SaveLevel(swordLevelUpEventData.SwordId, swordLevelUpEventData.SwordLevel);

                return;
            }
        }
    }
}