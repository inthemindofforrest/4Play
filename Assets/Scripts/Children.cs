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

    bool Ragdolling = false;
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
        Agent.destination = Target.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(Ragdolling)
        {
            print("EXPLODE");
            Destroy(gameObject);
            return;
        }
        if(collision.gameObject.tag == "Melee")
        {
            print("Hit " + (transform.position - collision.transform.position).normalized * 20);
            //Ragdoll
            Ragdolling = true;

            //Add Force from hit
            RB.AddForce(((transform.position - collision.transform.position).normalized + new Vector3(0,.1f,0)) * 1000); //:)
        }
    }
}
