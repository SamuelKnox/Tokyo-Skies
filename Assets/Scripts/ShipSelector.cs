using UnityEngine;
using System.Collections;

public class ShipSelector : MonoBehaviour
{
    private Transform ships;

    void Start()
    {
        ships = GameManager.Instance.transform.FindDescendent("Ships");
    }

    public void SelectDestroyer()
    {
        ActiveShip activeShip = GameManager.Instance.GetComponent<ActiveShip>();
        activeShip.Ship = ships.Find("Destroyer").gameObject.GetComponent<Ship>();
        Application.LoadLevel("Level 0");
    }

    public void SelectTanker()
    {
        ActiveShip activeShip = GameManager.Instance.GetComponent<ActiveShip>();
        activeShip.Ship = ships.Find("Tanker").gameObject.GetComponent<Ship>();
        Application.LoadLevel("Level 0");
    }
    public void SelectSpeedster()
    {
        ActiveShip activeShip = GameManager.Instance.GetComponent<ActiveShip>();
        activeShip.Ship = ships.Find("Speedster").gameObject.GetComponent<Ship>();
        Application.LoadLevel("Level 0");
    }
    public void SelectUltimate()
    {
        ActiveShip activeShip = GameManager.Instance.GetComponent<ActiveShip>();
        activeShip.Ship = ships.Find("Ultimate").gameObject.GetComponent<Ship>();
        Application.LoadLevel("Level 0");
    }
}
