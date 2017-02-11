using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyWall : ConditionBasedBehavior {

	public AudioClip destroy_sound;
	public int life;

	// Use this for initialization
	void Start () {
		
	}

		
	public override void OnConditionSatisfied()
	{
		life--;
		if (life <= 0) {
			SoundManager.instance.PlaySingle (destroy_sound);
			Destroy (gameObject);
		}
	} 
		
}

#if UNITY_EDITOR
[CustomEditor(typeof(DestroyWall))]
public class DestroyWallEditor : ConditionBasedEditor {

}
#endif

