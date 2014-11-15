using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{
    [Tooltip("Whether or not this missile will track the player's ship until it is destroyed")]
    public bool HomingMissile;
    [Tooltip("The speed at which the missile travels")]
    public float TravelSpeed = 0.1F;
    [Tooltip("The speed at which the missile rotates")]
    public float RotationSpeed = 1;
    [Tooltip("This is the rotation offset to make the missiles forward the same as the direction it is facing")]
    public float RotationOffset = 90;

    private Ship ship;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        ship = GameManager.Instance.GetComponent<ActiveShip>().Ship;
        InitializeRotation();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMissileTrajectory();
    }

    private void InitializeRotation()
    {
        direction = ship.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + RotationOffset, Vector3.forward);
    }

    private void UpdateMissileTrajectory()
    {
        if (HomingMissile && ship)
        {
            direction = ship.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.RotateTowardsOverTime(Quaternion.AngleAxis(angle + RotationOffset, Vector3.forward).eulerAngles, 1 / RotationSpeed);
        }

        rigidbody2D.AddForce(direction * TravelSpeed);
    }
}
