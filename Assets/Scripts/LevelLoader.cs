using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    private Ship ship;

	// Use this for initialization
	void Start () {
        LoadShip();
        SetUpStatusBars();
        Destroy(gameObject);
	}

    private void LoadShip()
    {
        ship = GameManager.Instance.GetComponent<ActiveShip>().Ship;

        ship.gameObject.SetActive(true);

        TargetFollower targetFollower = ship.GetComponent<TargetFollower>();
        targetFollower.Target = Camera.main.transform;
    }

    private void SetUpStatusBars()
    {
        ShipSpecs shipSpecs = ship.GetComponent<ShipSpecs>();

        EnergyBar healthBar = GameObject.Find("Health Bar").GetComponent<EnergyBar>();
        healthBar.valueMin = shipSpecs.MinimumHitPoints;
        healthBar.valueMax = shipSpecs.MaximumHitPoints;
        healthBar.valueCurrent = shipSpecs.CurrentHitPoints;

        EnergyBar weaponPowerBar = GameObject.Find("Weapon Power Bar").GetComponent<EnergyBar>();
        healthBar.valueMin = shipSpecs.MinimumWeapon;
        weaponPowerBar.valueMax = shipSpecs.MaximumWeapon;
        weaponPowerBar.valueCurrent = shipSpecs.CurrentWeapon;

        EnergyBar shieldPowerBar = GameObject.Find("Shield Power Bar").GetComponent<EnergyBar>();
        healthBar.valueMin = shipSpecs.MinimumShield;
        shieldPowerBar.valueMax = shipSpecs.MaximumShield;
        shieldPowerBar.valueCurrent = shipSpecs.CurrentShield;

        EnergyBar speedPowerBar = GameObject.Find("Speed Power Bar").GetComponent<EnergyBar>();
        healthBar.valueMin = shipSpecs.MinimumSpeed;
        speedPowerBar.valueMax = shipSpecs.MaximumSpeed;
        speedPowerBar.valueCurrent = shipSpecs.CurrentSpeed;
    }
}
