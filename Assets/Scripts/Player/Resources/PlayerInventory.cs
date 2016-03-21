using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    private Resource _resourceObject;
    private ResourceTypes.ResourceType _resourceType = new ResourceTypes.ResourceType();
    private Resources _playerResources = new Resources();

    public Resources PlayerResources
    {
        get
        {
            return _playerResources;
        }
    }

    private float _maxDis = 1.0f;

    public void SetState()
    {
        _resourceType = _resourceObject.ResourceType;
        switch (_resourceType)
        {
            case ResourceTypes.ResourceType._fur:
                _playerResources.Fur += _resourceObject.Value;
                break;
            case ResourceTypes.ResourceType._meat:
                _playerResources.Meat += _resourceObject.Value;
                break;
            case ResourceTypes.ResourceType._stone:
                _playerResources.Stones += _resourceObject.Value;
                break;
            case ResourceTypes.ResourceType._wood:
                _playerResources.Wood += _resourceObject.Value;
                break;
        }
    }

    public void PickupResources()
    {
        Resource[] _resources = FindObjectsOfType<Resource>();
        for (int i = 0; i < _resources.Length; i++)
        {
            if (Vector2.Distance(transform.position, _resources[i].transform.position) < _maxDis)
            {
                _resourceObject = _resources[i];
                SetState();
                FindObjectOfType<InventoryBar>().CheckForItem(_resources[i]);
            }
        }
    }
}