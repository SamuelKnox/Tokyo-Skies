using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public static GameObject Instance { get; set; }

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
            Instance = gameObject;
            DontDestroyOnLoad(gameObject);
    }
}
