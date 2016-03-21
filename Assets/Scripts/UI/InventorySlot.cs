using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//UI Class
public class InventorySlot : MonoBehaviour {
	[SerializeField]private Text _countText;
	private Image _item;
	private ResourceTypes.ResourceType _type = ResourceTypes.ResourceType._none;
	public ResourceTypes.ResourceType Type {
		get { 
			return _type;
		} set { 
			_type = value;
		}
	}

	private int _maxItemCount = 10;
	private int _itemCount;
	private bool _hasItem;
	public bool HasItem {
		get {
			return _hasItem;
		} set { 
			_hasItem = value;
		}
	}

	void Start () {
		_item = GetComponent<Image> ();
	}

	public void SetCount(int count) {
		_itemCount = count;
		_countText.text = _itemCount.ToString ();
		if (_itemCount == 0) {
			_hasItem = false;
			_item.sprite = null;
			Color c = _item.color;
			c.a = 0;
			_item.color = c;
			_type = ResourceTypes.ResourceType._none;
			_countText.text = "";
		}
	}

	public void SetItem(Resource _resource) {
		if (_itemCount < _maxItemCount) {
			Sprite _sprite = _resource.GetComponent<SpriteRenderer> ().sprite;
			Color c = _item.color;
			c.a = 1;
			_item.color = c;
			_item.sprite = _sprite;
			_hasItem = true;
			_itemCount += _resource.Value;
			if (_itemCount >= _maxItemCount) {
				_itemCount = _maxItemCount;
				_countText.color = Color.red;
			}
			Destroy (_resource.gameObject);
			_countText.text = _itemCount.ToString ();	
		}
	}
}
