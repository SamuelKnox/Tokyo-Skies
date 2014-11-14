using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            LoadGameManager();

            Application.LoadLevel("Garage");
        }
    }

    private void LoadGameManager()
    {
        if (ES2.Exists("GameManager"))
        {
            GameManager.Instance = ES2.Load<GameObject>("GameManager");
        }
    }
}
