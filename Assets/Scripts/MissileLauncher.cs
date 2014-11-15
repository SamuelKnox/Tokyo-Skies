using UnityEngine;
using System.Collections;

public class MissileLauncher : MonoBehaviour
{

    [Tooltip("This is the type of missile to be launched")]
    public Missile Missile;
    [Tooltip("This is the number of times per second for a missile to be launched")]
    public float RateOfFire = 1;

    private float reloadTime;

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
        {
            reloadTime += Time.deltaTime;
            if (reloadTime >= 1 / RateOfFire)
            {
                LaunchMissile();
                reloadTime = 0;
            }
        }
    }

    private void LaunchMissile()
    {
        Missile missile = Instantiate(Missile, transform.position, transform.rotation) as Missile;

        GameObject missiles = GameObject.Find("Missiles");
        if (!missiles)
        {
            missiles = new GameObject("Missiles");
        }
        missile.transform.parent = missiles.transform;
    }
}
