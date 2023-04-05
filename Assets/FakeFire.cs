using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeFire : MonoBehaviour
{
    [SerializeField] float _rate = 0.3f;
    [SerializeField] GameObject _prefab;
    IEnumerator Start()
    {

        while(true)
        {
            yield return new WaitForSeconds(_rate);
            Instantiate(_prefab, transform.position, Quaternion.identity);
        }

    }
}
