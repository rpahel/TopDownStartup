using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using NaughtyAttributes;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField, BoxGroup("Dependencies")] private Canvas _interactionUI;

        [SerializeField, BoxGroup("Configuration")] private float _radius;
        [SerializeField, BoxGroup("Configuration")] private float _scanInterval;
        
        private IInteractable _current;

        IEnumerator Start()
        {
            var waiter = new WaitForSeconds(_scanInterval);
            while (true)
            {
                yield return waiter;
                _current = ScanForInteractables();

            }
        }

        private IInteractable ScanForInteractables()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, _radius);
            IInteractable interactableobj;
            List<GameObject> founds = new ();
            foreach(Collider2D obj in cols) 
            {
                if (obj.gameObject.TryGetComponent<IInteractable>(out interactableobj))
                {
                    if(interactableobj.IsInteractable())
                        founds.Add(obj.gameObject);
                }
            }

            IInteractable objfound = null;
            if (founds.Count > 0)
            {
                objfound = founds.OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).FirstOrDefault()?.GetComponent<IInteractable>();
            }

            _interactionUI.gameObject.SetActive(objfound != null);

            return objfound;
        }

        public void Interact()
        {
            _current?.TryInteract();
        }
    }
}