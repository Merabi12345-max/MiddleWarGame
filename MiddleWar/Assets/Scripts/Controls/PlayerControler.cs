using System;
using Movement;
using UnityEngine;
using Combat;


namespace Controls {

    public class PlayerControler : MonoBehaviour

    {
        private void Update()

        {
            ClickCursorForMoving();
            ClickCursorForAttacing();
        }


        private void ClickCursorForMoving()

        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                bool isHit = Physics.Raycast(LastRay(), out hit);
                if (isHit == true)
                {
                    GetComponent<Mover>().Move(hit.point);
                }
            }
        }

        private static Ray LastRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private void ClickCursorForAttacing()
        {

           RaycastHit[] hits =  Physics.RaycastAll(LastRay());
            foreach (RaycastHit hit in hits)
            {

               CombatTarget target =  hit.transform.GetComponent<CombatTarget>();

                if(target == null) continue;

                if (Input.GetMouseButtonDown(0))
                {

                    GetComponent<Fight>().Attack(target);

                }              

            }
             
        }
    }

}
