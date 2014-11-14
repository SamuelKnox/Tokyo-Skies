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
        healthBar.valueCurrent = shipSpecs.CurrentHitPoints;
        healthBar.valueMin = shipSpecs.MinimumHitPoints;
        healthBar.valueMax = shipSpecs.MaximumHitPoints;

        EnergyBar weaponPowerBar = GameObject.Find("Weapon Power Bar").GetComponent<EnergyBar>();
        weaponPowerBar.valueCurrent = shipSpecs.CurrentWeapon;
        healthBar.valueMin = shipSpecs.MinimumWeapon;
        weaponPowerBar.valueMax = shipSpecs.MaximumWeapon;

        EnergyBar shieldPowerBar = GameObject.Find("Shield Power Bar").GetComponent<EnergyBar>();
        shieldPowerBar.valueCurrent = shipSpecs.CurrentShield;
        healthBar.valueMin = shipSpecs.MinimumShield;
        shieldPowerBar.valueMax = shipSpecs.MaximumShield;

        EnergyBar speedPowerBar = GameObject.Find("Speed Power Bar").GetComponent<EnergyBar>();
        speedPowerBar.valueCurrent = shipSpecs.CurrentSpeed;
        healthBar.valueMin = shipSpecs.MinimumSpeed;
        speedPowerBar.valueMax = shipSpecs.MaximumSpeed;
    }
}
