using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Collections;
using NaughtyAttributes;

namespace Game
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField, BoxGroup("Configuration")] private float radius;
        
        private IInteractable _current;

        IEnumerator Start()
        {
            var waiter = new WaitForSeconds(0.5f);
            while (true)
            {
                yield return waiter;
                _current = ScanForInteractables();

            }
        }

        private IInteractable ScanForInteractables()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
            IInteractable interactableobj;
            List<GameObject> founds = new ();
            foreach(Collider2D obj in cols) 
            {
                if (obj.gameObject.TryGetComponent<IInteractable>(out interactableobj))
                {
                    founds.Add(obj.gameObject);
                }
            }

            IInteractable objfound = null;
            if (founds.Count > 0)
            {
                objfound = founds.OrderBy(i => Vector3.Distance(transform.position, i.transform.position)).FirstOrDefault().GetComponent<IInteractable>();
            }
            
            return objfound;
        }

        public void Interact()
        {
            _current?.TryInteract();
        }
    }
}