using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour, IFactory
{
    [SerializeField] GameObject _prefab;
    [SerializeField] int _startupCount;
    public List<GameObject> ObjectPool { get; private set; }

    private void Awake()
    {
        ObjectPool = new List<GameObject>();
        Warmup();
    }

    // Precharger des instances
    void Warmup()
    {
        for (int i = 0; i < _startupCount; i++)
        {
            ObjectPool.Add(Instantiate(_prefab));
        }
    }

    
    public GameObject Get()
    {
        throw new NotImplementedException();
    }

    public void Release(GameObject go)
    {

    }
}


