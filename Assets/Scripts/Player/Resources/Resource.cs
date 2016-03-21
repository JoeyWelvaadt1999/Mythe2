using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	
	private ResourceTypes _resourceTypes = new ResourceTypes();
	[SerializeField]private ResourceTypes.ResourceType _resourceType = new ResourceTypes.ResourceType();

	[SerializeField]private int _min;
	[SerializeField]private int _max;
	private int _value;

	public ResourceTypes.ResourceType ResourceType {
		get { 
			return _resourceType;
		}
	}

	public int Value {
		get {
			return _value;
		}
	}

	void Awake () {
		_value = Random.Range (_min, _max);
	}
}