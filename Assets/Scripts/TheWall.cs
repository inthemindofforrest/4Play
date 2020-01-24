using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWall : MonoBehaviour
{
    public GameObject Wall;
    public GameManager Manger;
    public int scoreThreshold;
    private float wallStartY;
    public bool lifted = false;
    public bool slam = false;
    public bool slamed = false;
    // Start is called before the first frame update
    void Start()
    {
        wallStartY = Wall.transform.position.y;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Manger.Score >= scoreThreshold && !lifted)
        {
            Wall.transform.position += new Vector3(0, 0.2f, 0);
            if (Wall.transform.position.y >= Wall.transform.localScale.y + wallStartY)
            {
                lifted = true;
            }
        }
        if (slam && !slamed)
        {
            Wall.transform.position -= new Vector3(0, 1, 0);
            if (Wall.transform.position.y <= wallStartY)
            {
                slamed = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("ahhhhhhhhhhhhhhhhhhhhhh");
        if (other.gameObject.tag == "Player" && lifted)
        {
            slam = true;
        }
    }
  
}
