using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [Tooltip("Current hit points for this gameobject")]
    public float CurrentHitPoints;

    public void DealDamage(float damage)
    {
        if (gameObject.tag == "Ship")
        {
            ShipSpecs shipSpecs = GameManager.Instance.GetComponent<ActiveShip>().Ship.GetShipSpecs();
            float shield = shipSpecs.CurrentShield;
            damage /= shield;
            CurrentHitPoints -= damage;
            shipSpecs.CurrentHitPoints = (int)CurrentHitPoints;
        }
        else
        {
            CurrentHitPoints -= damage;
        }

        if (CurrentHitPoints <= 0)
        {
            if (gameObject.tag == "Ship")
            {
                EnergyBar healthBar = GameObject.Find("Health Bar").GetComponent<EnergyBar>();
                healthBar.valueCurrent = 0;
            }
            Destroy(gameObject);
        }
    }
}
