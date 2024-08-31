using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TeslaFactory : MonoBehaviour
{
    [SerializeField] private float _initialDelay;
    [SerializeField] private Vector2 _spawnDelay;
    [SerializeField] private float _spawnDelayShrink;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _lanes;
    [SerializeField] private Vector2 _laneRange;

    private Vector2 _currentSpawnDelay;
    private float _nextSpawn;

    private void OnEnable()
    {
        _currentSpawnDelay = _spawnDelay;
        _nextSpawn = Time.time + _initialDelay;
    }

    private void FixedUpdate()
    {
        _currentSpawnDelay.x = Mathf.Lerp(_currentSpawnDelay.x, 0f, _spawnDelayShrink * Time.fixedDeltaTime);
        _currentSpawnDelay.y = Mathf.Lerp(_currentSpawnDelay.y, 0f, _spawnDelayShrink * Time.fixedDeltaTime);

        if (Time.time > _nextSpawn)
        {
            var newbie = Instantiate(_prefab);
            newbie.transform.position += Vector3.right * Mathf.Lerp(_laneRange.x, _laneRange.y, Random.Range(0, _lanes) / (_lanes - 1f));

            _nextSpawn = Time.time + Random.Range(_currentSpawnDelay.x, _currentSpawnDelay.y);
        }
    }
}
