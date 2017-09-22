using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class MovementAI : MonoBehaviour
{

    public LayerMask followTarget;
    [Range(0f, 360f)]
    public float fieldOfViewDegrees;
    public float radius;



    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 lastPoint;
    private SphereCollider sphereCollider;
    private NavMeshAgent enemy;



    private bool isFollowTarget;


    // Use this for initialization
    void Start()
    {


        enemy = gameObject.GetComponent<NavMeshAgent>();
        //sphereCollider = GetComponent<SphereCollider>();
        startPoint = transform.position;

        var targetRange = new GameObject();
        targetRange.name = "TriggerRange";
        targetRange.layer = LayerMask.NameToLayer("Trigger");
        targetRange.transform.parent = transform;
        targetRange.transform.position = transform.position;

        var sphereCollider = targetRange.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = radius;

        var targetTrigger = targetRange.AddComponent<ChildTriggerCollider>();
        targetTrigger.TriggerOnStay = TriggerOnStay;

        //radius = sphereCollider.radius * GetHighestValue(transform.localScale);

    }

    // Update is called once per frame
    void Update()
    {


        if (isFollowTarget)
        {

        }


        //if (lastPoint == transform.position || enemy.isStopped || endPoint == null
        //    || layerMask.value == 1 << LayerMask.NameToLayer("Main Player"))
        //{

        //    Attack();
        //}



        //if (lastPoint == transform.position || enemy.isStopped || endPoint == null || Vector3.Distance(transform.position, endPoint) < 10)
        //{

        //    RandomMove();
        //}
        //lastPoint = transform.position;

        //RaycastHit hit;
        //var players = Physics.OverlapSphere(transform.position, radius, layerMask);

        //if (players.Length > 0)
        //{
        //    Debug.Log(players[0].transform.position);
        //    enemy.SetDestination(players[0].transform.position);
        //}



    }

    void OnTriggerEnter(Collider col)
    {


        //if(col.gameObject.layer == LayerMask.NameToLayer("")
    }

    Vector3 test = Vector3.zero;

    private void TriggerOnStay(Collider col)
    {

        if ((followTarget.value & 1 << col.gameObject.layer) == (1 << col.gameObject.layer) && CanSeePlayer(col.gameObject))
        {
            test = col.transform.position;
            enemy.SetDestination(col.transform.position);
        }
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

    private void Attack()
    {

        NavMeshHit hit;

        Vector3 player = Random.insideUnitSphere * radius;

        player += startPoint;

        NavMesh.SamplePosition(player, out hit, radius, 1);
        enemy.SetDestination(hit.position);
        endPoint = hit.position;
    }


    protected bool CanSeePlayer(GameObject gb)
    {
        
        RaycastHit hit;
        Vector3 rayDirection = gb.transform.position - transform.position;

        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewDegrees * 0.5f)
        {
            // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit, radius))
            {
                return (hit.transform.CompareTag("Player"));
            }
        }

        return false;
    }


    private float GetHighestValue(Vector3 value)
    {
        float c = value.x;
        if (c < value.y) c = value.y;
        if (c < value.z) c = value.z;
        return c;
    }


}
