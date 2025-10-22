using System;
using UnityEngine;

//step 4
namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceData
    {
        [field:SerializeField] public ResourceType ResourceType { get; private set; }
        [field:SerializeField] public float ActiveTime { get; private set; }
        [field:SerializeField] public float DecayTime { get; private set; }
    }
}