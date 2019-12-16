using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
	
	void Update ()

    {
        if (Input.GetMouseButton(0))

        {

            GetPlayerMove();

        }

        UpdateAnimator();
	}

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSPeed", speed);
    }

    private void GetPlayerMove()

    {
        RaycastHit hit;
        Ray lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isHit = Physics.Raycast(lastRay, out hit);
        if (isHit == true)
        {

            GetComponent<NavMeshAgent>().destination = hit.point;

        }

    }
}
