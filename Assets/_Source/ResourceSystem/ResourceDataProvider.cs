using ResourceSystem.Data;
using ResourceSystem.Data.View;

//step 9
namespace ResourceSystem
{
    public static class ResourceDataProvider
    {
        public static bool TryGetResourceViewData(
            ResourceType resourceType, 
            ResourcesViewDataSO resourceViewDataSO, 
            out ResourceViewData resourceViewData)
        {
            resourceViewData = null;
            foreach (var item in resourceViewDataSO.ResourcesViewData)
            {
                if (item.ResourceType == resourceType)
                {
                    resourceViewData = item;
                    return true;
                }
            }
            return false;
        }
        
        
        
        
        public static bool TryGetResourceData(
            ResourceType resourceType, 
            ResourcesDataSO resourceDataSO, 
            out ResourceData resourceData)
        {
            resourceData = null;
            foreach (var item in resourceDataSO.ResourcesViewData)
            {
                if (resourceData.ResourceType == resourceType)
                {
                    resourceData = item;
                    return true;
                }
            }
            return false;
        }
    }
}