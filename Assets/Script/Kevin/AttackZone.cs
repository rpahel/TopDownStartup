using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    HashSet<IKevinHealth> _inZone;

    public IEnumerable<IKevinHealth> InZone => _inZone;

    private void Awake()
    {
        _inZone = new();  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IKevinHealth h))
        {
            _inZone.Add(h);
        }
        else
        {

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IKevinHealth>(out var h))
        {
            _inZone.Remove(h);
        }
    }


}
