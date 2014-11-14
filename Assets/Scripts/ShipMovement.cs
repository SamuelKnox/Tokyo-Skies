using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    [Tooltip("Speed at which the ship moves relative to its current speed")]
    public float MovementSpeedMultiplier = 2.5F;
    [Tooltip("Rate at which ship's velocity returns to zero relative to its current speed")]
    public float DragMultipler = 1;
    [Tooltip("Rate at which the ship rotates while turning")]
    public float RotationSpeed = 5;
    [Tooltip("The maximum rotation for the ship while moving horizontally")]
    public float MaximumHorizontalRotation = 30.0F;
    [Tooltip("The maximum rotation for the ship while moving vertically")]
    public float MaximumVerticalRotation = 30.0F;

    private ShipSpecs shipSpecs;

    // Use this for initialization
    void Start()
    {
        shipSpecs = gameObject.GetComponent<ShipSpecs>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        float movementSpeed = shipSpecs.CurrentSpeed * shipSpecs.CurrentSpeed * MovementSpeedMultiplier;
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed;
        gameObject.rigidbody2D.AddForce(new Vector2(horizontalMovement, verticalMovement));
        float drag = shipSpecs.CurrentSpeed * DragMultipler;
        gameObject.rigidbody2D.drag = drag;
    }

    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Horizontal") * MaximumHorizontalRotation;
        float verticalRotation = Input.GetAxis("Vertical") * MaximumVerticalRotation;
        Vector3 rotation = new Vector3(-verticalRotation, -horizontalRotation, -horizontalRotation);
        transform.localEulerAngles = rotation;
    }
}