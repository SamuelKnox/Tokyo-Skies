using UnityEngine;
using System.Collections;
using EnergyBarToolkit;

public class PowerShifter : MonoBehaviour
{

    [Tooltip("Speed at which Power can be shifted")]
    public float ShiftSpeed = 1.0F;
    [Tooltip("Percentage of Power put into Weapons")]
    public float WeaponPower = 0.4F;
    [Tooltip("Percentage of Power put into Shields")]
    public float ShieldPower = 0.4F;
    [Tooltip("Percentage of Power put into Speed")]
    public float SpeedPower = 0.4F;

    private ShipSpecs shipSpecs;
    private EnergyBar healthBar;
    private EnergyBar weaponPowerBar;
    private EnergyBar shieldPowerBar;
    private EnergyBar speedPowerBar;

    void Start()
    {
        shipSpecs = GameManager.Instance.GetComponent<ActiveShip>().Ship.GetShipSpecs();

        healthBar = GameObject.Find("Health Bar").GetComponent<EnergyBar>();
        weaponPowerBar = GameObject.Find("Weapon Power Bar").GetComponent<EnergyBar>();
        shieldPowerBar = GameObject.Find("Shield Power Bar").GetComponent<EnergyBar>();
        speedPowerBar = GameObject.Find("Speed Power Bar").GetComponent<EnergyBar>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButton("Weapon Shift"))
        {
            ShiftToWeaponPower();
        }
        if (Input.GetButton("Shield Shift"))
        {
            ShiftToShieldPower();
        }
        if (Input.GetButton("Speed Shift"))
        {
            ShiftToSpeedPower();
        }
        UpdateShipPower();
    }

    void Update()
    {
        UpdateStatusBars();
    }

    private void ShiftToWeaponPower()
    {
        if (WeaponPower < 1)
        {
            if (ShieldPower > 0.1)
            {
                WeaponPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumWeapon);
                ShieldPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumWeapon);
            }
            if (SpeedPower > 0.1)
            {
                WeaponPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumWeapon);
                SpeedPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumWeapon);
            }
        }
    }
    private void ShiftToShieldPower()
    {
        if (ShieldPower < 1)
        {
            if (WeaponPower > 0.1)
            {
                ShieldPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumShield);
                WeaponPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumShield);
            }
            if (SpeedPower > 0.1)
            {
                ShieldPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumShield);
                SpeedPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumShield);
            }
        }
    }
    private void ShiftToSpeedPower()
    {
        if (SpeedPower < 1)
        {
            if (WeaponPower > 0.1)
            {
                SpeedPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumSpeed);
                WeaponPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumSpeed);
            }
            if (ShieldPower > 0.1)
            {
                SpeedPower += 0.05F * (ShiftSpeed / shipSpecs.MaximumSpeed);
                ShieldPower -= 0.05F * (ShiftSpeed / shipSpecs.MaximumSpeed);
            }
        }
    }

    private void UpdateShipPower()
    {
        if (shipSpecs.MinimumWeapon <= (int)(shipSpecs.MaximumWeapon * WeaponPower))
        {
            shipSpecs.CurrentWeapon = (int)(shipSpecs.MaximumWeapon * WeaponPower);
        }

        if (shipSpecs.MinimumShield <= (int)(shipSpecs.MaximumShield * ShieldPower))
        {
            shipSpecs.CurrentShield = (int)(shipSpecs.MaximumShield * ShieldPower);
            EnergyBar shieldPowerBar = GameObject.Find("Shield Power Bar").GetComponent<EnergyBar>();
            shieldPowerBar.valueCurrent = shipSpecs.CurrentShield;
            RepeatedRenderer3D barRenderer = shieldPowerBar.GetComponent<RepeatedRenderer3D>();
            barRenderer.repeatCount = shipSpecs.MaximumShield;
        }

        if (shipSpecs.MinimumSpeed <= (int)(shipSpecs.MaximumSpeed * SpeedPower))
        {
            shipSpecs.CurrentSpeed = (int)(shipSpecs.MaximumSpeed * SpeedPower);
            EnergyBar speedPowerBar = GameObject.Find("Speed Power Bar").GetComponent<EnergyBar>();
            speedPowerBar.valueCurrent = shipSpecs.CurrentSpeed;
            RepeatedRenderer3D barRenderer = speedPowerBar.GetComponent<RepeatedRenderer3D>();
            barRenderer.repeatCount = shipSpecs.MaximumSpeed;
        }
    }

    private void UpdateStatusBars()
    {
        healthBar.valueCurrent = shipSpecs.CurrentHitPoints;

        weaponPowerBar.valueCurrent = shipSpecs.CurrentWeapon;
        RepeatedRenderer3D weaponPowerBarRenderer = weaponPowerBar.GetComponent<RepeatedRenderer3D>();
        weaponPowerBarRenderer.repeatCount = shipSpecs.MaximumWeapon;

        shieldPowerBar.valueCurrent = shipSpecs.CurrentShield;
        RepeatedRenderer3D shieldPowerBarRenderer = shieldPowerBar.GetComponent<RepeatedRenderer3D>();
        shieldPowerBarRenderer.repeatCount = shipSpecs.MaximumShield;

        speedPowerBar.valueCurrent = shipSpecs.CurrentSpeed;
        RepeatedRenderer3D speedPowerBarRenderer = speedPowerBar.GetComponent<RepeatedRenderer3D>();
        speedPowerBarRenderer.repeatCount = shipSpecs.MaximumSpeed;
    }
}
