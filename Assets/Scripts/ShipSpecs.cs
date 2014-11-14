using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ship))]
public class ShipSpecs : MonoBehaviour {

    [Tooltip("Ship's current hit points")]
    public int CurrentHitPoints = 10;
    [Tooltip("Ship's minimum hit points")]
    public int MinimumHitPoints = 0;
    [Tooltip("Ship's maximum hit points")]
    public int MaximumHitPoints = 10;

    [Tooltip("Ship's current primary weapon level")]
    public int CurrentWeapon = 1;
    [Tooltip("Ship's minimum primary weapon level")]
    public int MinimumWeapon = 1;
    [Tooltip("Ship's maximum primary weapon level")]
    public int MaximumWeapon = 10;

    [Tooltip("Ship's current shield level")]
    public int CurrentShield = 1;
    [Tooltip("Ship's minimum shield level")]
    public int MinimumShield = 1;
    [Tooltip("Ship's maximum shield level")]
    public int MaximumShield = 10;

    [Tooltip("Ship's current speed")]
    public int CurrentSpeed = 1;
    [Tooltip("Ship's minimum speed")]
    public int MinimumSpeed = 1;
    [Tooltip("Ship's maximum speed")]
    public int MaximumSpeed = 10;
}
