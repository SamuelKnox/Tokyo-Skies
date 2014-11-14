using UnityEngine;
using System.Collections;

public class GameObjectRetainer : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
