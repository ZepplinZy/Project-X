using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementAI : MonoBehaviour {

    public LayerMask layerMask;


    public float radius = 120;



    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 lastPoint;

    private NavMeshAgent enemy;
    


	// Use this for initialization
	void Start ()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();
        startPoint = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (lastPoint == transform.position || enemy.isStopped || endPoint == null || Vector3.Distance(transform.position, endPoint) < 10)
        {
            
            RandomMove();
        }
        lastPoint = transform.position;

        //RaycastHit hit;
        //var players = Physics.OverlapSphere(transform.position, radius, layerMask);

        //if (players.Length > 0)
        //{
        //    Debug.Log(players[0].transform.position);
        //    enemy.SetDestination(players[0].transform.position);
        //}

    }


    private void RandomMove()
    {
        NavMeshHit hit;

        Vector3 rDirection = Random.insideUnitSphere * radius;

        rDirection += startPoint;

        NavMesh.SamplePosition(rDirection, out hit, radius, 1);
        enemy.SetDestination(hit.position);
        endPoint = hit.position;
    }


}
