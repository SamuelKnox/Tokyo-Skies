using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class WeaponTrigger : MonoBehaviour
{

    [Tooltip("Ammunition which is fired from this weapon")]
    public GameObject Ammunition;
    [Tooltip("Direction at which this weapon fires")]
    public Vector2 DirectionOfFire;
    [Tooltip("Rate at which this weapon fires")]
    public float RateOfFire = 1;
    [Tooltip("Speed at which the ammunition travels")]
    public float AmmoVelocity = 1;

    private ShipSpecs shipSpecs;
    private float reloadTime;

    // Update is called once per frame
    void Update()
    {
        shipSpecs = GetShipSpecs();
        reloadTime += Time.deltaTime;
        if (Input.GetButton("Fire Primary") && shipSpecs && reloadTime * shipSpecs.CurrentWeapon >= 1 / RateOfFire)
        {
            FirePrimaryWeapon();
            reloadTime = 0;
        }
    }

    private ShipSpecs GetShipSpecs()
    {
        if (!shipSpecs)
        {
            Ship activeShip = GameManager.Instance.GetComponent<ActiveShip>().Ship;
            if (activeShip)
            {
                return activeShip.GetShipSpecs();
            }
        }
        return shipSpecs;
    }

    private void FirePrimaryWeapon()
    {
        GameObject bullet = GameObject.Instantiate(Ammunition, transform.position, transform.rotation) as GameObject;
        bullet.transform.forward = transform.forward;
        float xMomentum = -bullet.transform.forward.x;
        if (xMomentum < 0)
        {
            xMomentum -= 1;
        }
        else if (xMomentum > 0)
        {
            xMomentum += 1;
        }
        float yMomentum = 1.0F;
        Vector2 momentumAdjustment = new Vector2(xMomentum, yMomentum);
        bullet.rigidbody2D.velocity += (DirectionOfFire + momentumAdjustment) * AmmoVelocity * shipSpecs.CurrentWeapon;

        GameObject bullets = GameObject.Find("Bullets");
        if (!bullets)
        {
            bullets = new GameObject("Bullets");
        }
        bullet.transform.parent = bullets.transform;
    }
}
