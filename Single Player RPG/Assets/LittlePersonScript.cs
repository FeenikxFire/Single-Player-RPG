using UnityEngine;
using System.Collections;

public class LittlePersonScript : MonoBehaviour {

	public PlayerState playerState;
	public Animation animationComponent;
	public enum PlayerState
	{
		Idle,
		Attack
	}
	// Use this for initialization
	void Start () {

		playerState = PlayerState.Idle;
	
	}
	
	// Update is called once per frame
	void Update () {
		AnimationCheck ();
		PlayerMovement ();
	}

	public void AnimationCheck()
	{
		//Animation Switch
		switch (playerState)
		{
		case PlayerState.Idle:
			animationComponent.Play("Standing_Walk_Right");
			break;
			
		case PlayerState.Attack:
			animationComponent.Play("Crouch_Idle");
			break;
		}
	}
	public void PlayerMovement()
	{
		if(Input.GetKey(KeyCode.W))
		{
			playerState = PlayerState.Attack;
		}
		else
		{
			playerState = PlayerState.Idle;
		}
	}
}
