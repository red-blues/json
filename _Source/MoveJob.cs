using UnityEngine;
using UnityEngine.Jobs;

public struct MoveJob : IJobParallelForTransform
{
    public float Time;
    public float Radius;
    public float Speed;
    
    public void Execute(int index, TransformAccess transform)
    {
        //TODO deploy movement logic
        /*float angle = Time * Speed * index * .1f;
        float x = Radius * Mathf.Cos(angle);
        float z = Radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, 0, z);*/
    }
}
