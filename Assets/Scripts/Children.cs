using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Children : MonoBehaviour
{
    GameManager Manager;
    NavMeshAgent Agent;
    NavMeshHit NHit;

    public int Speed = 1;
    public GameObject Target;
    NavMeshAgent TargetAgent;

    public bool Ragdolling = false;
    Rigidbody RB;
    RaycastHit Hit;

    private void Start()
    {
        Manager = GameManager.Manager;
        //Agent = GetComponent<NavMeshAgent>();
        if(!RB)
        {
            RB = GetComponent<Rigidbody>();
        }
        TargetAgent = Target.GetComponent<NavMeshAgent>();


        if(NavMesh.SamplePosition(transform.position, out NHit, 500, 1))
        {
            transform.position = NHit.position;
            Agent = gameObject.AddComponent<NavMeshAgent>();
        }

    }

    private void Update()
    {
        if(!Ragdolling)
            Agent.destination = Target.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Ragdolling && collision.gameObject.tag == "StaticObject")
        {
            print("EXPLODE");
            Destroy(gameObject);
            return;
        }
        if(collision.gameObject.tag == "Melee")
        {
            Manager.Score++;
            Agent.enabled = false;
            Agent.gameObject.AddComponent<NavMeshObstacle>();
            //Ragdoll
            Ragdolling = true;

            //Add Force from hit
            RB.AddForce(((transform.position - collision.transform.position).normalized + new Vector3(0,.1f,0)) * 1000); //:)
        }
    }
}
