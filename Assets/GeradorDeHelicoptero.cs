using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeHelicoptero : MonoBehaviour {

    public GameObject helicopteroprefab;
    public float delay = 2f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("GerarHelicoptero", delay, delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GerarHelicoptero()
    {
        int a = Random.Range(0, 4);

        GameObject helicoptero = Instantiate(helicopteroprefab);

        helicoptero.transform.eulerAngles = Vector3.up * a * 90;
    }
}
