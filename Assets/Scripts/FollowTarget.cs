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

    public bool buscarSempreMaisProximo;

    void Start () {
		
	}
	

	void Update () {
        Procurar();
        Movimentar();
        Rotacionar();
	}

    private void Procurar()
    {
        if (targetTag==""  || (!buscarSempreMaisProximo && target != null))
        {
            return;
        }

        if (!buscarSempreMaisProximo && target == null)
        {
            return;
        }

        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);

        Transform possivelTarget = null;

        foreach(GameObject checarTarget in targets)
        {
            float checarDistancia = Vector3.Distance(checarTarget.transform.position, transform.position);

            if (possivelTarget== null || checarDistancia<Vector3.Distance(possivelTarget.position,transform.position))
            {
                possivelTarget = checarTarget.transform;
            }
        }

        if(possivelTarget != null)
        {
            target = possivelTarget;
        }
        
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
