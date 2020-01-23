using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DIRECTION { Forward,Backward,Left,Right};

public class ChildSpawning : MonoBehaviour
{
    public enum ENTRANCES{ ClimbThroughWindow, ClimbBuilding, Fall};
    


    public int SectionNumber = -1;
    public ENTRANCES Entrance;
    public DIRECTION Direction;

    RaycastHit Hit;

    private void Start()
    {
        LookInCorrectDirection();
    }



    void LookInCorrectDirection()
    {
        if(Physics.Raycast(transform.position, transform.forward, out Hit, 1.5f))
        {
            Direction = DIRECTION.Forward;
        }
        else if (Physics.Raycast(transform.position, -transform.forward, out Hit, 1.5f))
        {
            Direction = DIRECTION.Backward;
        }
        else if (Physics.Raycast(transform.position, transform.right, out Hit, 1.5f))
        {
            Direction = DIRECTION.Right;
        }
        else if (Physics.Raycast(transform.position, -transform.right, out Hit, 1.5f))
        {
            Direction = DIRECTION.Left;
        }
    }
}
