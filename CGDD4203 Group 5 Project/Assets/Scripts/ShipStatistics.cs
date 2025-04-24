using System;
using UnityEngine;

[Serializable]
public class ShipStatistics
{

    // Caps
    [SerializeField] float shieldPowerMin = 0;
    [SerializeField] float shieldPowerMax = 100;

    [SerializeField] float fireRateMin = 0.1f;

    [SerializeField] float thrustForceMin = 3;

    // Statistics
    [SerializeField] private float shieldPower;
    [SerializeField] private float fireRate;
    [SerializeField] private float thrustForce;


    public float ShieldPower { get => shieldPower; protected set => Mathf.Clamp(value, 0, ShieldPowerMax); }  //0-100
    public float FireRate { get => fireRate; protected set => fireRate = value; } //seconds of cool down between shots
    public float ThrustForce { get => thrustForce; protected set => thrustForce = value; }
    public float ShieldPowerMax { get => shieldPowerMax; protected set => shieldPowerMax = value; }

    //**CONSTRUCTOR**
    public ShipStatistics()
    {

    }

    //**UTILITY METHODS**
    public void ApplyStatisticsMod(ShipStatisticModifierData newStatModData)
    { // TODO: Make this read from a list of power up, and be readable directly from the per
        ShieldPower = Mathf.Max(ShieldPower + newStatModData.ShieldPowerMod, shieldPowerMin);
        FireRate = Mathf.Max(FireRate + newStatModData.FireRateMod, fireRateMin);
        ThrustForce = Mathf.Max(ThrustForce + newStatModData.ThrustForceMod, thrustForceMin);
    }

    public override string ToString()
    {
        return $"Shield Power: {ShieldPower} | Fire Rate: {FireRate}s | ThrustForce: {ThrustForce}";
    }
}


[Serializable]
public struct ShipStatisticModifierData
{
    //**PROPERTIES**
    float shieldPowerMod;
    float fireRateMod;
    float thrustForceMod;

    // **FIELDS**
    public float ShieldPowerMod { get => shieldPowerMod; }
    public float FireRateMod { get => fireRateMod; }
    public float ThrustForceMod { get => thrustForceMod; }

    //**CONSTRUCTOR**  
    public ShipStatisticModifierData(float shipPowerModIn, float fireRateModIn, float thrustForceModIn)
    {
        shieldPowerMod = shipPowerModIn;
        fireRateMod = fireRateModIn;
        thrustForceMod = thrustForceModIn;
    }
}
