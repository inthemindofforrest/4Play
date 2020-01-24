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

    public float Timer = 0;

    RaycastHit Hit;

    private void Start()
    {
        Manager = GameManager.Manager;
        LookInCorrectDirection();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.P) || Timer <= 0) && SectionNumber == Manager.CameraLocationPoint)
        {
            Timer = 3;
            SpawnChildren();
        }
    }

    void SpawnChildren()
    {
        GameObject ChildToBeSpawned = SpawnChild.CreateChild(ToSpawn, transform.parent, transform.position, Direction);
        switch (Direction)
        {
            case DIRECTION.Forward:
                ChildToBeSpawned.transform.LookAt(transform.position + Vector3.right);
                break;
            case DIRECTION.Backward:
                ChildToBeSpawned.transform.LookAt(transform.position + -Vector3.right);
                break;
            case DIRECTION.Right:
                ChildToBeSpawned.transform.LookAt(transform.position + -Vector3.forward);
                break;
            case DIRECTION.Left:
                ChildToBeSpawned.transform.LookAt(transform.position + Vector3.forward);
                break;
        }
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
