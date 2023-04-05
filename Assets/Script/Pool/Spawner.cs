using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IFactory
{
    [SerializeField] GameObject _prefab;
    public GameObject Get()
    {
        return Instantiate(_prefab);
    }

    public void Release(GameObject go)
    {
        Destroy(go);
    }
}
