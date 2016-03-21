using UnityEngine;
using System.Collections;

public enum States {
	Attacking,
	Wander,
	Chasing,
	None
}

public static class EnemyStates {
	public static States _states = States.None;
}
