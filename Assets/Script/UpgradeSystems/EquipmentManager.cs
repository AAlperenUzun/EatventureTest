using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour, IGeneralUpgradeManager
{
    public Dictionary<GeneralUpgradeType, Upgrade>  OwnedEquipments;
    private void Start()
    {
        InitializeUpgrades();
    }

    void InitializeUpgrades()
    {
        OwnedEquipments = new Dictionary<GeneralUpgradeType, Upgrade>();


        AddUpgrade(new Upgrade { generalType = GeneralUpgradeType.AllMultiplier, StandType = StandType.All, Value = 2f, Description = "All Profit x2" });
        AddUpgrade(new Upgrade { generalType = GeneralUpgradeType.AllStandSpeedUp, StandType = StandType.All, Value = 1.3f, Description = "+%30 Food made faster" });
    }

    public void AddUpgrade( Upgrade upgrade)
    {
        if (OwnedEquipments == null)
            OwnedEquipments = new Dictionary<GeneralUpgradeType, Upgrade>();

        OwnedEquipments[upgrade.generalType] = upgrade;
    }

    public float CalculateTotalMultiplier(GeneralUpgradeType _gUpgradeType)
    {
        float multiplier = 1f;

        foreach (var gUpgradeType in OwnedEquipments.Keys)
        {
            if (gUpgradeType==_gUpgradeType)
                multiplier *= OwnedEquipments[gUpgradeType].Value;
        }

        return multiplier;
    }

    public float GetValue(GeneralUpgradeType generalUpgradeType, float value)
    {
        return value * CalculateTotalMultiplier(generalUpgradeType);
    }
}