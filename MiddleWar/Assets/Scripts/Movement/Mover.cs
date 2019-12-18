using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour
    {

        void Update()

        {
            UpdateAnimator();
        }

        public void Move(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSPeed", speed);
        }

    }
}
