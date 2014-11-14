using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Shaker : MonoBehaviour
{
    [Tooltip("Intensity at which the object shakes")]
    public float Intensity = 1.0F;
    [Tooltip("Whether or not to shake the game object's position")]
    public bool ShakePosition = true;
    [Tooltip("Whether or not to shake the game object's rotation")]
    public bool ShakeRotation = true;

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
        {
            Shake();
            IncreaseIntensity();
        }
    }

    private void Shake()
    {
        if (ShakePosition)
        {
            float xShake = Random.Range(-1.0F, 1.0F) * Intensity;
            float yShake = Random.Range(-1.0F, 1.0F) * Intensity;
            rigidbody2D.AddForce(new Vector2(xShake, yShake));
        }

        if (ShakeRotation)
        {
            float rotationShake = Random.Range(-1.0F, 1.0F) * Intensity;
            rigidbody2D.AddTorque(rotationShake);
        }
    }

    private void IncreaseIntensity()
    {
        Intensity += Time.deltaTime;
    }
}
