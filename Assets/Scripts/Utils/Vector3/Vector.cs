using UnityEngine;
using System.Collections;

namespace VectorUtils
{
	public class Vector : MonoBehaviour{
		

		public static Vector3 ToVector(float value) {
			Vector3 v = new Vector3 (value, value, value);
			return v;
		}
	}

}
