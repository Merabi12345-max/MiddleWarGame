using System;
using Movement;
using UnityEngine;
using Combat;


namespace Controls {

    public class PlayerControler : MonoBehaviour

    {
        private void Update()

        {
            if(ClickCursorForMoving()) return;
            if( ClickCursorForAttacing()) return;
            
        }



        private bool ClickCursorForAttacing()
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
                return true;
            }

            return false;
        }


        private bool ClickCursorForMoving()

        {

            RaycastHit hit;
            bool isHit = Physics.Raycast(LastRay(), out hit);
            if (isHit)
            {
                if (Input.GetMouseButton(0))
                {

                    GetComponent<Mover>().Move(hit.point);

                }

                return true;
            }
            return false;
        }



        private static Ray LastRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }

}
