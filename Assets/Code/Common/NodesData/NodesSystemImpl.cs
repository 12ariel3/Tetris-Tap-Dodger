using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.NodesData
{
    public class NodesSystemImpl : NodesSystem
    {
        private readonly DataStore _dataStore;



        public NodesSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }


        public bool GetNodeActivation(string nodeName)
        {
            var userData = _dataStore.GetData<UserData>(nodeName)
                        ?? new UserData();
            switch (nodeName)
            {
                case "Hp0":
                    return userData.HpNode0;

                case "Hp1":
                    return userData.HpNode1;

                case "Hp2":
                    return userData.HpNode2;

                case "Hp3":
                    return userData.HpNode3;

                case "Hp4":
                    return userData.HpNode4;

                case "Hp5":
                    return userData.HpNode5;

                case "Hp6":
                    return userData.HpNode6;

                case "Hp7":
                    return userData.HpNode7;

                case "Hp8":
                    return userData.HpNode8;

                case "Hp9":
                    return userData.HpNode9;

                case "Hp10":
                    return userData.HpNode10;

                case "Hp11":
                    return userData.HpNode11;

                case "Fire0":
                    return userData.FireNode0;

                case "Fire1":
                    return userData.FireNode1;

                case "Fire2":
                    return userData.FireNode2;

                case "Fire3":
                    return userData.FireNode3;

                case "Fire4":
                    return userData.FireNode4;

                case "Fire5":
                    return userData.FireNode5;

                case "Poison0":
                    return userData.PoisonNode0;

                case "Poison1":
                    return userData.PoisonNode1;

                case "Poison2":
                    return userData.PoisonNode2;

                case "Poison3":
                    return userData.PoisonNode3;

                case "Poison4":
                    return userData.PoisonNode4;

                case "Poison5":
                    return userData.PoisonNode5;

                case "Ice0":
                    return userData.IceNode0;

                case "Ice1":
                    return userData.IceNode1;

                case "Ice2":
                    return userData.IceNode2;

                case "Ice3":
                    return userData.IceNode3;

                case "Ice4":
                    return userData.IceNode4;

                case "Ice5":
                    return userData.IceNode5;

                case "Water0":
                    return userData.WaterNode0;

                case "Water1":
                    return userData.WaterNode1;

                case "Water2":
                    return userData.WaterNode2;

                case "Water3":
                    return userData.WaterNode3;

                case "Water4":
                    return userData.WaterNode4;

                case "Water5":
                    return userData.WaterNode5;

                case "Electric0":
                    return userData.ElectricNode0;

                case "Electric1":
                    return userData.ElectricNode1;

                case "Electric2":
                    return userData.ElectricNode2;

                case "Electric3":
                    return userData.ElectricNode3;

                case "Electric4":
                    return userData.ElectricNode4;

                case "Electric5":
                    return userData.ElectricNode5;

                case "Ghost0":
                    return userData.GhostNode0;

                case "Ghost1":
                    return userData.GhostNode1;

                case "Ghost2":
                    return userData.GhostNode2;

                case "Ghost3":
                    return userData.GhostNode3;

                case "Ghost4":
                    return userData.GhostNode4;

                case "Ghost5":
                    return userData.GhostNode5;

                case "Rainbow0":
                    return userData.RainbowNode0;

                case "Rainbow1":
                    return userData.RainbowNode1;

                case "Rainbow2":
                    return userData.RainbowNode2;

                case "Rainbow3":
                    return userData.RainbowNode3;

                case "Rainbow4":
                    return userData.RainbowNode4;

                case "Rainbow5":
                    return userData.RainbowNode5;

                case "Energy0":
                    return userData.EnergyNode0;

                case "Energy1":
                    return userData.EnergyNode1;

                case "Energy2":
                    return userData.EnergyNode2;

                case "Energy3":
                    return userData.EnergyNode3;

                case "Energy4":
                    return userData.EnergyNode4;

                case "Energy5":
                    return userData.EnergyNode5;
                default: return false;
            }
        }

        public bool GetNodeAvailability(string nodeAvailableName)
        {
            var userData = _dataStore.GetData<UserData>(nodeAvailableName)
                        ?? new UserData();
            switch (nodeAvailableName)
            {
                case "HpAvailable0":
                    return userData.HpNodeAvailable0;

                case "HpAvailable1":
                    return userData.HpNodeAvailable1;

                case "HpAvailable2":
                    return userData.HpNodeAvailable2;

                case "HpAvailable3":
                    return userData.HpNodeAvailable3;

                case "HpAvailable4":
                    return userData.HpNodeAvailable4;

                case "HpAvailable5":
                    return userData.HpNodeAvailable5;

                case "HpAvailable6":
                    return userData.HpNodeAvailable6;

                case "HpAvailable7":
                    return userData.HpNodeAvailable7;

                case "HpAvailable8":
                    return userData.HpNodeAvailable8;

                case "HpAvailable9":
                    return userData.HpNodeAvailable9;

                case "HpAvailable10":
                    return userData.HpNodeAvailable10;

                case "HpAvailable11":
                    return userData.HpNodeAvailable11;

                case "FireAvailable0":
                    return userData.FireNodeAvailable0;

                case "FireAvailable1":
                    return userData.FireNodeAvailable1;

                case "FireAvailable2":
                    return userData.FireNodeAvailable2;

                case "FireAvailable3":
                    return userData.FireNodeAvailable3;

                case "FireAvailable4":
                    return userData.FireNodeAvailable4;

                case "FireAvailable5":
                    return userData.FireNodeAvailable5;

                case "PoisonAvailable0":
                    return userData.PoisonNodeAvailable0;

                case "PoisonAvailable1":
                    return userData.PoisonNodeAvailable1;

                case "PoisonAvailable2":
                    return userData.PoisonNodeAvailable2;

                case "PoisonAvailable3":
                    return userData.PoisonNodeAvailable3;

                case "PoisonAvailable4":
                    return userData.PoisonNodeAvailable4;

                case "PoisonAvailable5":
                    return userData.PoisonNodeAvailable5;

                case "IceAvailable0":
                    return userData.IceNodeAvailable0;

                case "IceAvailable1":
                    return userData.IceNodeAvailable1;

                case "IceAvailable2":
                    return userData.IceNodeAvailable2;

                case "IceAvailable3":
                    return userData.IceNodeAvailable3;

                case "IceAvailable4":
                    return userData.IceNodeAvailable4;

                case "IceAvailable5":
                    return userData.IceNodeAvailable5;

                case "WaterAvailable0":
                    return userData.WaterNodeAvailable0;

                case "WaterAvailable1":
                    return userData.WaterNodeAvailable1;

                case "WaterAvailable2":
                    return userData.WaterNodeAvailable2;

                case "WaterAvailable3":
                    return userData.WaterNodeAvailable3;

                case "WaterAvailable4":
                    return userData.WaterNodeAvailable4;

                case "WaterAvailable5":
                    return userData.WaterNodeAvailable5;

                case "ElectricAvailable0":
                    return userData.ElectricNodeAvailable0;

                case "ElectricAvailable1":
                    return userData.ElectricNodeAvailable1;

                case "ElectricAvailable2":
                    return userData.ElectricNodeAvailable2;

                case "ElectricAvailable3":
                    return userData.ElectricNodeAvailable3;

                case "ElectricAvailable4":
                    return userData.ElectricNodeAvailable4;

                case "ElectricAvailable5":
                    return userData.ElectricNodeAvailable5;

                case "GhostAvailable0":
                    return userData.GhostNodeAvailable0;

                case "GhostAvailable1":
                    return userData.GhostNodeAvailable1;

                case "GhostAvailable2":
                    return userData.GhostNodeAvailable2;

                case "GhostAvailable3":
                    return userData.GhostNodeAvailable3;

                case "GhostAvailable4":
                    return userData.GhostNodeAvailable4;

                case "GhostAvailable5":
                    return userData.GhostNodeAvailable5;

                case "RainbowAvailable0":
                    return userData.RainbowNodeAvailable0;

                case "RainbowAvailable1":
                    return userData.RainbowNodeAvailable1;

                case "RainbowAvailable2":
                    return userData.RainbowNodeAvailable2;

                case "RainbowAvailable3":
                    return userData.RainbowNodeAvailable3;

                case "RainbowAvailable4":
                    return userData.RainbowNodeAvailable4;

                case "RainbowAvailable5":
                    return userData.RainbowNodeAvailable5;

                case "EnergyAvailable0":
                    return userData.EnergyNodeAvailable0;

                case "EnergyAvailable1":
                    return userData.EnergyNodeAvailable1;

                case "EnergyAvailable2":
                    return userData.EnergyNodeAvailable2;

                case "EnergyAvailable3":
                    return userData.EnergyNodeAvailable3;

                case "EnergyAvailable4":
                    return userData.EnergyNodeAvailable4;

                case "EnergyAvailable5":
                    return userData.EnergyNodeAvailable5;
                default: return false;
            }
        }


        public void SaveNodeActivation(string nodeName, bool isActived)
        {
            switch (nodeName)
            {
                case "Hp0":
                    var userData = new UserData { HpNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp1":
                    userData = new UserData { HpNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp2":
                    userData = new UserData { HpNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp3":
                    userData = new UserData { HpNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp4":
                    userData = new UserData { HpNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp5":
                    userData = new UserData { HpNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp6":
                    userData = new UserData { HpNode6 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp7":
                    userData = new UserData { HpNode7 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp8":
                    userData = new UserData { HpNode8 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp9":
                    userData = new UserData { HpNode9 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp10":
                    userData = new UserData { HpNode10 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Hp11":
                    userData = new UserData { HpNode11 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire0":
                    userData = new UserData { FireNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire1":
                    userData = new UserData { FireNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire2":
                    userData = new UserData { FireNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire3":
                    userData = new UserData { FireNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire4":
                    userData = new UserData { FireNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Fire5":
                    userData = new UserData { FireNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison0":
                    userData = new UserData { PoisonNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison1":
                    userData = new UserData { PoisonNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison2":
                    userData = new UserData { PoisonNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison3":
                    userData = new UserData { PoisonNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison4":
                    userData = new UserData { PoisonNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Poison5":
                    userData = new UserData { PoisonNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice0":
                    userData = new UserData { IceNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice1":
                    userData = new UserData { IceNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice2":
                    userData = new UserData { IceNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice3":
                    userData = new UserData { IceNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice4":
                    userData = new UserData { IceNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ice5":
                    userData = new UserData { IceNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water0":
                    userData = new UserData { WaterNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water1":
                    userData = new UserData { WaterNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water2":
                    userData = new UserData { WaterNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water3":
                    userData = new UserData { WaterNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water4":
                    userData = new UserData { WaterNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Water5":
                    userData = new UserData { WaterNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric0":
                    userData = new UserData { ElectricNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric1":
                    userData = new UserData { ElectricNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric2":
                    userData = new UserData { ElectricNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric3":
                    userData = new UserData { ElectricNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric4":
                    userData = new UserData { ElectricNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Electric5":
                    userData = new UserData { ElectricNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost0":
                    userData = new UserData { GhostNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost1":
                    userData = new UserData { GhostNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost2":
                    userData = new UserData { GhostNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost3":
                    userData = new UserData { GhostNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost4":
                    userData = new UserData { GhostNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Ghost5":
                    userData = new UserData { GhostNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow0":
                    userData = new UserData { RainbowNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow1":
                    userData = new UserData { RainbowNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow2":
                    userData = new UserData { RainbowNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow3":
                    userData = new UserData { RainbowNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow4":
                    userData = new UserData { RainbowNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Rainbow5":
                    userData = new UserData { RainbowNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy0":
                    userData = new UserData { EnergyNode0 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy1":
                    userData = new UserData { EnergyNode1 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy2":
                    userData = new UserData { EnergyNode2 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;
                case "Energy3":
                    userData = new UserData { EnergyNode3 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy4":
                    userData = new UserData { EnergyNode4 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;

                case "Energy5":
                    userData = new UserData { EnergyNode5 = isActived };
                    _dataStore.SetData(userData, nodeName);
                    return;
                default: return;
            }
        }



        public void SaveNodeAvailability(string nodeAvailableName, bool isAvailable)
        {
            switch (nodeAvailableName)
            {
                case "HpAvailable0":
                    var userData = new UserData { HpNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable1":
                    userData = new UserData { HpNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable2":
                    userData = new UserData { HpNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable3":
                    userData = new UserData { HpNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable4":
                    userData = new UserData { HpNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable5":
                    userData = new UserData { HpNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable6":
                    userData = new UserData { HpNodeAvailable6 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable7":
                    userData = new UserData { HpNodeAvailable7 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable8":
                    userData = new UserData { HpNodeAvailable8 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable9":
                    userData = new UserData { HpNodeAvailable9 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable10":
                    userData = new UserData { HpNodeAvailable10 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "HpAvailable11":
                    userData = new UserData { HpNodeAvailable11 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable0":
                    userData = new UserData { FireNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable1":
                    userData = new UserData { FireNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable2":
                    userData = new UserData { FireNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable3":
                    userData = new UserData { FireNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable4":
                    userData = new UserData { FireNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "FireAvailable5":
                    userData = new UserData { FireNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable0":
                    userData = new UserData { PoisonNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable1":
                    userData = new UserData { PoisonNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable2":
                    userData = new UserData { PoisonNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable3":
                    userData = new UserData { PoisonNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable4":
                    userData = new UserData { PoisonNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "PoisonAvailable5":
                    userData = new UserData { PoisonNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable0":
                    userData = new UserData { IceNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable1":
                    userData = new UserData { IceNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable2":
                    userData = new UserData { IceNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable3":
                    userData = new UserData { IceNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable4":
                    userData = new UserData { IceNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "IceAvailable5":
                    userData = new UserData { IceNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable0":
                    userData = new UserData { WaterNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable1":
                    userData = new UserData { WaterNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable2":
                    userData = new UserData { WaterNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable3":
                    userData = new UserData { WaterNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable4":
                    userData = new UserData { WaterNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "WaterAvailable5":
                    userData = new UserData { WaterNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable0":
                    userData = new UserData { ElectricNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable1":
                    userData = new UserData { ElectricNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable2":
                    userData = new UserData { ElectricNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable3":
                    userData = new UserData { ElectricNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable4":
                    userData = new UserData { ElectricNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "ElectricAvailable5":
                    userData = new UserData { ElectricNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable0":
                    userData = new UserData { GhostNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable1":
                    userData = new UserData { GhostNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable2":
                    userData = new UserData { GhostNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable3":
                    userData = new UserData { GhostNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable4":
                    userData = new UserData { GhostNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "GhostAvailable5":
                    userData = new UserData { GhostNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable0":
                    userData = new UserData { RainbowNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable1":
                    userData = new UserData { RainbowNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable2":
                    userData = new UserData { RainbowNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable3":
                    userData = new UserData { RainbowNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable4":
                    userData = new UserData { RainbowNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "RainbowAvailable5":
                    userData = new UserData { RainbowNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable0":
                    userData = new UserData { EnergyNodeAvailable0 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable1":
                    userData = new UserData { EnergyNodeAvailable1 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable2":
                    userData = new UserData { EnergyNodeAvailable2 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;
                case "EnergyAvailable3":
                    userData = new UserData { EnergyNodeAvailable3 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable4":
                    userData = new UserData { EnergyNodeAvailable4 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                case "EnergyAvailable5":
                    userData = new UserData { EnergyNodeAvailable5 = isAvailable };
                    _dataStore.SetData(userData, nodeAvailableName);
                    return;

                default: return;
            }
        }
    }
}