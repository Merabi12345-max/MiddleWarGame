using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;


namespace Combat
{
    public class Fight : MonoBehaviour
    {

        Transform target;

        [SerializeField] float weaponRange = 2;

        private void Update()
        {
            bool isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
            if (target != null && !isInRange)
            {

                GetComponent<Mover>().Move(target.position);

            }
            else
            {

                GetComponent<Mover>().Stop();

            }
        }

        public void Attack(CombatTarget combatTarget)
        {

            target = combatTarget.transform;

        }
    }
}
