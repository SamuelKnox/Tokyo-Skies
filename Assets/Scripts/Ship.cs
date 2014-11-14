using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShipSpecs))]
public class Ship : MonoBehaviour {

    public ShipSpecs GetShipSpecs()
    {
        return GetComponent<ShipSpecs>();
    }
}
