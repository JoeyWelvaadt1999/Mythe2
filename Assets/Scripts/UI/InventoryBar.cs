using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//UI Class
public class InventoryBar : MonoBehaviour {
	[SerializeField]private InventorySlot[] _inventorySlots;
	private int _slotNumber;

	public void CheckForItem(Resource _resource) {
		StartCoroutine (Check (_resource));
		_inventorySlots [_slotNumber].SetItem (_resource);
	}

	IEnumerator Check(Resource _resource) {
		for (int i = 0; i < _inventorySlots.Length;) {
			if (_inventorySlots [i].Type == ResourceTypes.ResourceType._none) {
				_inventorySlots [i].Type = _resource.ResourceType;
			}
			if (!_inventorySlots [i].HasItem || _inventorySlots [i].Type == _resource.ResourceType) {
				_slotNumber = i;
				break;
			} else {
				i++;
			}
		}
		yield return 0;
	}


}
