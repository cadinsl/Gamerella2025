using UnityEngine;

public class WalkerGlobal : MonoBehaviour
{
    private static WalkerGlobal _instance;

    public static WalkerGlobal Instance { get { return _instance; } }

    public Transform[] destinationPoints;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public Transform getRandomDestinationPoint()
    {
        return destinationPoints[Random.Range(0, destinationPoints.Length - 1)];
    }
}
