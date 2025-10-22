using System;
using UnityEngine;

//step 2
namespace ResourceSystem.Data.View
{
    [Serializable]
    public class ResourceViewData
    {
        [field:SerializeField] public ResourceType ResourceType { get; private set; }
        [field:SerializeField] public Sprite ActiveStateIcon { get; private set; }
        [field:SerializeField] public Sprite DecayStateIcon { get; private set; }
    }
}