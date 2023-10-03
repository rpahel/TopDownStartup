using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent _onTryInteract;
        [SerializeField, SerializeReference] private List<Condition> Conditions = new();

        public event UnityAction OnTryInteract
        {
            add => _onTryInteract.AddListener(value);
            remove => _onTryInteract.RemoveListener(value);
        }

        public bool IsInteractable()
        {
            if(Conditions.Count > 0) 
            {
                bool conditionMet = false;
                for(int i = 0; i < Conditions.Count; i++)
                {
                    conditionMet = Conditions[i].IsConditionMet();
                }

                return conditionMet;
            }
            return true;
        }

        public bool TryInteract()
        {
            if(IsInteractable())
            {
                _onTryInteract?.Invoke();
                return true;
            }

            return false;
        }
    }
}
