using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bidule
{
    public class StateMachineBrain : MonoBehaviour
    {
        public enum State { PATROL, INSPECT, CHASE, GUN }

        State InternalState { get; set; }

        private void Update()
        {
            switch (InternalState)
            {
                case State.PATROL:
                    // Act
                    // FOllow path

                    // Transition
                    // Si le joueur est pas loin :
                    InternalState = State.INSPECT;
                    break;
                case State.INSPECT:
                    // Act

                    // Transition

                    break;
                case State.CHASE:
                    // Act


                    // Transition


                    break;
                case State.GUN:
                    // Act


                    // Transition


                    break;
                default:
                    break;
            }
        }
    }
}
