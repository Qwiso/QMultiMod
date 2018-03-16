﻿using Oculus.Newtonsoft.Json;
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
        public float PlayerDamageTakenMultiplier = 1f;
        public float VehicleDamageTakenMultiplier = 2f;
        public float SubDamageTakenMultiplier = 2f;
        public bool StorageContainersStack = true;
        public float SeamothReinforcementModuleDepth = 1600f;
        public float SeamothHullMarkOneDepth = 100f;
        public float SeamothHullMarkTwoDepth = 300f;
        public float SeamothHullMarkThreeDepth = 1500f;
        public float CyclopsThermalReactorEfficiency = 2.0f;
        public float CyclopsTurningTorqueMultiplier = 1.5f;
        public float CyclopsForwardAccelMultiplier = 1.5f;
        public float CyclopsVerticalAccelMultiplier = 1.0f;
        public float SwimToMeatVelocity = 8f;
        public float VehicleForwardForceMultiplier = 1.5f;
        public float ScannerSpeedNormalInterval = 14f;
        public float ScannerSpeedMinimumInterval = 1f;
        public float ScannerSpeedIntervalPerModule = 3f;
        public float ScannerBlipRange = 1000f;
        public float ScannerMinRange = 600f;
        public float ScannerUpgradeAddedRange = 100f;
        public float ScannerCameraRange = 1000f;
        public bool NitrogenEnabled = false;
        public bool UnlockHullPlates = false;
        public bool AllowAchievementsWithConsole = false;
        public float SwimChargeFinsModifier = 0.005f;
        public float FireExtinguisherHolderRechargeValue = 0f;


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
                File.WriteAllText(configPath, JsonConvert.SerializeObject(Instance, Formatting.Indented));
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
