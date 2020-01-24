using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;

    public int Score = 0;
    public GameObject Player;

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

    public void ResetGame()
    {
        print("Game Reset");
        Score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
