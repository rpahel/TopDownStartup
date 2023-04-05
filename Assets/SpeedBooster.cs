using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] Physics2DInteraction _physics;

#if UNITY_EDITOR
    private void Reset()
    {
        _physics = GetComponent<Physics2DInteraction>() ?? GetComponentInChildren<Physics2DInteraction>();
    }
#endif

    private void Start()
    {
        _physics.TriggerEnter2D += AlterateEntitySpeed;

    }

    private void AlterateEntitySpeed(Collider2D target)
    {

        var movement = target.GetComponentInParent<Entity>()
            ?.GetComponentInChildren<EntityMovement>();



        var t1 = movement.CurrentSpeed.AddTransformator(f => f * 1.2f, 100);

        var t2 = movement.CurrentSpeed.AddTransformator(f => f + 1.2f, 120);

        var t3 = movement.CurrentSpeed.AddTransformator(f => 0, 130);

        movement.CurrentSpeed.RemoveTransformator(t2);



        gameObject.SetActive(false);
    }
}
