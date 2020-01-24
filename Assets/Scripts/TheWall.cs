using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour
{
    public GameObject Wall;
    public GameManager Manger;
    public int scoreThreshold;
    private float wallStartY;
    // Start is called before the first frame update
    void Start()
    {
        wallStartY = Wall.transform.position.y;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manger.Score >= scoreThreshold && Wall != null)
        {
            Wall.transform.position += new Vector3(0, 0.2f, 0);
            if (Wall.transform.position.y >= Wall.transform.localScale.y + wallStartY)
            {
                Destroy(Wall);
            }
        }
    }
}
