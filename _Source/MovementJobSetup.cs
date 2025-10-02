using System;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = System.Random;

public class MovementJobSetup : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int objectCount;
    [SerializeField] private float movementRadius;
    [SerializeField] private float speed;

    private TransformAccessArray _transformAccessArray;
    private JobHandle _jobHandle;
    private void Awake() => Setup();
    private void Setup()
    {
        _transformAccessArray = new TransformAccessArray(objectCount);

        for (int i = 0; i < objectCount; i++)
        {
            var instance = Instantiate(prefab, 
                UnityEngine.Random.insideUnitSphere * movementRadius, 
                Quaternion.identity);
            _transformAccessArray.Add(instance.transform);
        }
    }
    private void Update() => InitJob();
    private void InitJob()
    {
        var job = new MoveJob()
        {
            Time = Time.deltaTime,
            Radius = movementRadius,
            Speed = speed
        };
        
        _jobHandle = job.Schedule(_transformAccessArray);
    }
    private void LateUpdate() => _jobHandle.Complete();
    private void OnDestroy() => _transformAccessArray.Dispose();
}
