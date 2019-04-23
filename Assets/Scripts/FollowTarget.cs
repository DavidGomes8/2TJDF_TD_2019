using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    public Transform target;
    public string targetTag;

    public float velocidadeMovimento = 1f;
    public float velocidadeRotacao = 1f;
    public bool lookAt = false;

    void Start () {
		
	}
	

	void Update () {
        Movimentar();
        Rotacionar();
	}

    private void Rotacionar()
    {
        if (lookAt && target != null)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position-transform.position), Time.deltaTime * velocidadeRotacao);
        }

    }

    private void Movimentar()
    {
        if (lookAt || target == null)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * velocidadeMovimento);
        }
        else if (target != null)
        {
            Vector3 direcao = (target.position - transform.position).normalized;
            transform.Translate(direcao * velocidadeMovimento * Time.deltaTime, Space.World);
        }
    }
}
