using UnityEngine;
using System.Collections;

public class OffCameraDestroyer : MonoBehaviour {
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
