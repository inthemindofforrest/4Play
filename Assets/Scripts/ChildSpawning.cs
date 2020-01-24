using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum DIRECTION { Forward,Backward,Left,Right};

public class ChildSpawning : MonoBehaviour
{
    public enum ENTRANCES{ ClimbThroughWindow, ClimbBuilding, Fall};
    GameManager Manager;

    public GameObject ToSpawn;

    public int SectionNumber = -1;
    public ENTRANCES Entrance;
    public DIRECTION Direction;

    RaycastHit Hit;

    private void Start()
    {
        Manager = GameManager.Manager;
        LookInCorrectDirection();
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.P) && SectionNumber == Manager.CameraLocationPoint)
        {
            SpawnChildren();
        }
    }

    void SpawnChildren()
    {
        SpawnChild.CreateChild(ToSpawn, transform.parent, transform.position, Direction);
    }
    void LookInCorrectDirection()
    {
        if(Physics.Raycast(transform.position, Vector3.forward, out Hit, 1.5f))
        {
            Direction = DIRECTION.Forward;
        }
        else if (Physics.Raycast(transform.position, -Vector3.forward, out Hit, 1.5f))
        {
            Direction = DIRECTION.Backward;
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out Hit, 1.5f))
        {
            Direction = DIRECTION.Right;
        }
        else if (Physics.Raycast(transform.position, -Vector3.right, out Hit, 1.5f))
        {
            Direction = DIRECTION.Left;
        }
    }
}
