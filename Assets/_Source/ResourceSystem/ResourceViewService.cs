using ResourceSystem.Data;
using ResourceSystem.Data.View;
using UnityEngine;

//step 6
namespace ResourceSystem
{
    public class ResourceViewService
    {
        //step 7
        #region Singleton
        private static ResourceViewService _instance;
        public static ResourceViewService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ResourceViewService();
                return _instance;
            }
        }
        #endregion

        private const string _dataPath = "ResourcesViewDataSO";
        private readonly ResourcesViewDataSO _viewData;
        
        public ResourceViewService()
        {
            _viewData = Resources.Load(_dataPath) as ResourcesViewDataSO; //TODO move to load service
        }
        
        //step 8
        public bool TryGetActiveIcon(ResourceType resourceType,
            out Sprite icon)
        {
            icon = null;
            if (ResourceDataProvider
                .TryGetResourceViewData(resourceType, _viewData, 
                    out ResourceViewData resourceViewData))
            {
                icon = resourceViewData.ActiveStateIcon;
                return true;
            }
            return false;
        }
        
        public bool TryGetDecayIcon(ResourceType resourceType, 
            out Sprite icon)
        {
            icon = null;
            if (ResourceDataProvider
                .TryGetResourceViewData(resourceType, _viewData, 
                    out ResourceViewData resourceViewData))
            {
                icon = resourceViewData.DecayStateIcon;
                return true;
            }
            return false;
        }
    }
}