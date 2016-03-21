using UnityEngine;
using System.Collections;

public class Resources {
	private int _wood;
	private int _stones;
	private int _meat;
	private int _fur;

	private int _max = 10;

	public int Wood {
		get { 
			return _wood;
		}

		set {
			if (_wood < _max) {
				_wood = value;
				if (_wood > _max) {
					_wood = _max;
				}
			}

		}
	}

	public int Stones {
		get { 
			return _stones;
			}

		set {
			if (_stones < _max) {
				_stones = value;
				if (_stones > _max) {
					_stones = _max;
				}
			}
		}
	}

	public int Meat {
		get { 
			return _meat;
			}

		set {
			if (_meat < _max) {
				_meat = value;
				if (_meat > _max) {
					_meat = _max;
				}
			}
		}
	}

	public int Fur {
		get { 
			return _fur;
			}

		set {
			if (_fur < _max) {
				_fur = value;
				if (_fur > _max) {
					_fur = _max;

				}
			}
		}
	}
}

[System.Serializable]
public struct ResourceTypes
{
	public enum ResourceType
	{
		_none,
		_wood,
		_stone,
		_meat,
		_fur
	};
}

