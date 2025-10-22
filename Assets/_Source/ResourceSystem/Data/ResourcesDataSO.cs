using System.Collections.Generic;
using UnityEngine;

//step 5
namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "ResourcesDataSO", menuName = "SO/New Resources Data")]
    public class ResourcesDataSO : ScriptableObject
    {
        [field:SerializeField] public List<ResourceData> ResourcesViewData { get; private set; }
    }
}