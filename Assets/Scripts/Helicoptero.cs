using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicoptero : MonoBehaviour {

    FollowTarget followTarget;

    public GameObject explode;

    public Rigidbody rb;

    public float forcaTorque = 200;

	void Start () {
        followTarget = GetComponent<FollowTarget>();
	}

	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            Waypoint waypoint = other.GetComponent<Waypoint>();
            Waypoint waypointPosterior = waypoint.waypointPosterior;
            followTarget.target = waypointPosterior.transform;
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Projétil"))
        {
            Instantiate(explode,transform.position,explode.transform.rotation);

            //Destroy(gameObject);
            rb.isKinematic = false;
            rb.useGravity = true;
            Destroy(c.gameObject);
            rb.AddTorque(Vector3.up*forcaTorque*Random.RandomRange(0,5));
            rb.AddTorque(Vector3.right* forcaTorque);
            gameObject.tag.Replace("Inimigos","");
        }

        else if(c.gameObject.CompareTag("Chao")) {
            Instantiate(explode, transform.position, explode.transform.rotation);
            Destroy(gameObject);

        }
    }
}
