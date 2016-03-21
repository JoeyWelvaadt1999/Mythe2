using UnityEngine;
using System.Collections;

public class PlayerCraft : MonoBehaviour
{
    private Craftables _craftables = new Craftables();
	private PlayerInventory _playerInventory;//Variable to PlayerInventory component 
	private Resources _resources;//Empty variable, will be used to store Recourses from te PlayerInventory component

	// Use this for initialization
	void Start ()
    {
		_playerInventory = GetComponent<PlayerInventory> ();//Use GetComponent to get the PlayerInventory component from the player object
		_resources = _playerInventory.PlayerResources;//Put the recources from the PlayerInventory component in the recourses variable in this component
		//Be aware that this needs to be updated incase the player pick's up a new recourse
//        print("Resources required to make a torch : " + "Wood: "+ _craftables.Torch.wood + " Stones: " + _craftables.Torch.stones);
//        print("Resources required to make a fur coat" + _craftables.FurCoat.fur);
        
	}

    void CraftItem()
    {
        if (_resources.Fur >= _craftables.FurCoat.fur && Input.GetKey(KeyCode.Alpha1))
        {
            print("you have made a fur coat");
			_resources.Fur -= _craftables.FurCoat.fur;
			InventorySlot[] inventorySlots = FindObjectsOfType<InventorySlot> ();
			foreach (InventorySlot slot in inventorySlots) {
				if (slot.HasItem) {
					switch (slot.Type) {
					case ResourceTypes.ResourceType._fur:
						slot.SetCount (_resources.Fur);
						break;
					default:
						break;
					}
				}
			}
        }

        if (_resources.Wood >= _craftables.Torch.wood && _resources.Stones >= _craftables.Torch.stones && Input.GetKey(KeyCode.Alpha2))
        {
            print("you have made a torch");
        }
    }
	
	void Update ()
    {
       CraftItem();   
	}
}
