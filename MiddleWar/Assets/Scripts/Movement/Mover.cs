using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        NavMeshAgent navMeshAgent;

        [SerializeField]
        Transform target;

        public void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }


        void Update()

        {
            UpdateAnimator();
        }

        public void Move(Vector3 destination)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;

        }

        public void Stop()
        {

            navMeshAgent.isStopped = true;

        }
        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSPeed", speed);
        }

    }
}
