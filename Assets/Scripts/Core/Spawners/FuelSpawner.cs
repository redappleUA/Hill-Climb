using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawner : MonoBehaviour
{
    [SerializeField] EnvironmentSpawner _ground;
    [SerializeField] GameObject _canisterPrefab;

    private void Start()
    {
        _ground.OnSpawn.AddListener(SpawnCanister);
    }

    private void SpawnCanister(Vector3 pos)
    {
        var go = Instantiate(_canisterPrefab, pos, Quaternion.identity);
    }
}
