using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyPlayer : ConditionBasedBehavior {

	public AudioClip destroy_sound;

	// Use this for initialization
	void Start () {
		
	}

		
	public override void OnConditionSatisfied()
	{
		SoundManager.instance.PlaySingle (destroy_sound);
		GameManager.instance.EndGame (false);
		Destroy(gameObject);
	} 
		
}

#if UNITY_EDITOR
[CustomEditor(typeof(DestroyPlayer))]
public class DestroyPlayerEditor : ConditionBasedEditor {

}
#endif

