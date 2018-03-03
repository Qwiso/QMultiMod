using Oculus.Newtonsoft.Json;
using System;
using System.IO;

namespace QMultiMod
{
    class QMultiModSettings
    {
        public float AttackLastTargetSwimVelocity = 2f;
        public float AttackLastTargetCrawlVelocity = 2f;
        public float SpotlightPowerPerSecond = 0.05f;
        public float SpotlightUpdateInterval = 20f;
        public float TechlightPowerPerSecond = 0.05f;
        public float TechlightUpdateInterval = 20f;
        public int MinDrillableAmount = 2;
        public int MaxDrillableAmount = 5;
        public float DrillableSpawnChanceMultiplier = 2f;
        public float ExosuitThrustConsumption = 0.04f;
        public float ExosuitClawDamageToLiving = 100f;
        public float ExosuitDrillDamageToLiving = 16f;
        public float ExosuitGrapplingArmRange = 70f;
        public int GravsphereMaxTrapped = 24;
        public float GravsphereMaxForce = 30f;
        public int PlayerInventoryWidth = 8;
        public int PlayerInventoryHeight = 8;
        public bool PlayerAvoidDamageMultiplier = false;
        public float PlayerDamageTakenMultiplier = 2f;
        public bool PlayerVehicleAvoidDamageMultiplier = true;
        public float VehicleDamageTakenMultiplier = 2f;
        public bool PlayerSubAvoidDamageMultiplier = true;
        public float SubDamageTakenMultiplier = 2f;
        public bool StorageContainersStack = true;
        public float SeaMothReinforcementModuleDepth = 1600f;
        public float SeaMothHullMarkOneDepth = 100f;
        public float SeaMothHullMarkTwoDepth = 300f;
        public float SeaMothHullMarkThreeDepth = 1500f;
        public int SeamothStorageContainerWidth = 6;
        public int SeamothStorageContainerHeight = 6;
        public float CyclopsThermalReactorEfficiency = 2.0f;
        public float CyclopsTurningTorqueMultiplier = 1.5f;
        public float CyclopsForwardAccelMultiplier = 1.5f;
        public float CyclopsVerticalAccelMultiplier = 1.0f;
        public float SwimToMeatVelocity = 8f;
        public float VehicleForwardForceMultiplier = 1.5f;
        public bool VendingMachineAlsoGivesCoffee = true;
        public float ScannerBlipRange = 1000f;
        public float ScannerMinRange = 600f;
        public float ScannerUpgradeAddedRange = 100f;
        public float ScannerCameraRange = 1000f;
        public bool NitrogenEnabled = false;


        private static readonly string configPath = Environment.CurrentDirectory + @"\QMods\QMultiMod\config.json";
        private static readonly QMultiModSettings instance = new QMultiModSettings();


        static QMultiModSettings()
        {
        }


        private QMultiModSettings()
        {
        }


        public static QMultiModSettings Instance
        {
            get
            {
                return instance;
            }
        }


        public static void Load()
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, JsonConvert.SerializeObject(Instance));
                return;
            }

            var json = File.ReadAllText(configPath);
            var userSettings = JsonConvert.DeserializeObject<QMultiModSettings>(json);

            var fields = typeof(QMultiModSettings).GetFields();

            foreach (var field in fields)
            {
                var userValue = field.GetValue(userSettings);
                field.SetValue(Instance, userValue);
            }
        }
    }
}
