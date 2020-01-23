using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    public int Score;

    int HiddenNum = 0;
    public int CameraLocationPoint
    {
        set
        {
            HiddenNum = (value < 0) ? 0 : (value > CameraLocations.Count - 1) ? CameraLocations.Count - 1 : value;
        }
        get
        {
            return HiddenNum;
        }
    }
    public List<Transform> CameraLocations;

    private void Start()
    {
        if (Manager == null)
            Manager = this;
        else
            Destroy(gameObject);
    }
}
