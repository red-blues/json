using System.Collections.Generic;
using UnityEngine;

//step 3
namespace ResourceSystem.Data.View
{
    [CreateAssetMenu(fileName = "ResourcesViewDataSO", menuName = "SO/New Resources View Data")]
    public class ResourcesViewDataSO : ScriptableObject
    {
        [field:SerializeField] public List<ResourceViewData> ResourcesViewData { get; private set; }
    }
}