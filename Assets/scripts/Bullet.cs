using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public Vector3 endPoint;
    public Vector3? oldPos;


    public float range;
<<<<<<< HEAD
    public float speed = 20f;
=======

>>>>>>> b5c53beb0c4c3981b706799f8b16ab42fbb020f9

    private float dd;

    private Vector3 startPos;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {


        if (gameObject.activeSelf)
        {
            //Debug.Log("start et eller andet");
            //Debug.Log("is " + Vector3.Distance(transform.position, endPoint));
            //Debug.Log("Q "+ endPoint.magnitude);
            //Debug.Log("S "+ transform.position.magnitude);
            

            float distanceThisFrame = speed * Time.deltaTime;
            //Debug.Log("1 " + Vector3.Distance(startPos, transform.position));
            

            if (oldPos.HasValue)
            {
                //Debug.Log("3 start et eller andet");
                RaycastHit hit;

                {
                    gameObject.SetActive(false);
                }
                else
                {
                    Debug.DrawLine(oldPos.Value, transform.position, Color.red, 20f);
                }

                
            }
            
            //Debug.Log("e "+ endPoint);
            //Debug.Log("c " + transform.position);
           // Debug.DrawLine(startPos, GetComponent<Bullet>().endPoint, Color.green, 10f);

            oldPos = transform.position;
            //transform.Translate(endPoint.normalized * distanceThisFrame, Space.World);
            //transform.position = Vector3.MoveTowards(transform.position, endPoint, distanceThisFrame);
            var heading = endPoint - startPos;
            transform.Translate(heading.normalized * distanceThisFrame, Space.World);
            if (Vector3.Distance(startPos, transform.position) > range)
            {

                gameObject.SetActive(false);

            }
        }
	}
    

    void OnCollisionEnter(Collision collision)
    {
    }

    void OnEnable()
    {
        startPos = transform.position;
        oldPos = transform.position;
        //Debug.DrawLine(transform.position, endPoint, Color.blue, 10f);
        dd = Vector3.Distance(startPos, endPoint);

        
    }

    private void HitTarget(GameObject go)
    {
        var hitHealth = go.GetComponent<Health>();
        //Debug.Log("hit targhet");
        //Debug.Log("11 takedamg");
        if (hitHealth != null)
        {
            hitHealth.TakeDamage(50);
            //Debug.Log("takedamg");
            //Debug.Log(hitHealth.currentHP);
        }
    }
    
	private void ttt(){}



}
