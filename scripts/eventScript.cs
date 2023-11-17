using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class eventScript : MonoBehaviour
{
    [Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }
	// public BoolEvent OnAttackEvent;

    void Awake(){
        if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
		// if (OnAttackEvent == null)
		// 	OnAttackEvent = new BoolEvent();
    }
}
