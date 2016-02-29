using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour {

	//Movement Stuff;
	public Rigidbody rb;
	public Transform myTransform;

	//Movement Speeds && Distances;
	private float ForwardMovementSpeed = 0.5f;
	private float BackwardMovementSpeed = -0.3f;
	private float RotationSpeed = 1.5f;
	private float RayCastJumpCheckDistance = 0.1f;

	//Ground Bool;
	public bool Grounded;

	//Animation Stuff;
	public PlayerState playerState;
	public Animation animationComponent;
	public enum PlayerState
	{
		Idle,
		Walk,
		Attack,
		Hit
	}

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		myTransform = this.transform;
		animationComponent = GetComponent<Animation> ();
		playerState = PlayerState.Idle;
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerMovement ();
		JumpCheck ();
		AnimationCheck ();
	}

	public void PlayerMovement()
	{
		if(Input.GetKey(KeyCode.W))
		{
			playerState = PlayerState.Walk;
			rb.transform.Translate(0,0,ForwardMovementSpeed);
		}
		if(Input.GetKey(KeyCode.S))
		{
			playerState = PlayerState.Walk;
			rb.transform.Translate(0,0, BackwardMovementSpeed);
		}
		if(Input.GetKey(KeyCode.A))
		{
			playerState = PlayerState.Walk;
			rb.transform.Rotate (0,-RotationSpeed,0);
		}
		if(Input.GetKey(KeyCode.D))
		{
			playerState = PlayerState.Walk;
			rb.transform.Rotate(0,RotationSpeed,0);
		}
		if(Input.GetKey(KeyCode.Q))
		{
			playerState = PlayerState.Walk;
			rb.transform.Translate(-ForwardMovementSpeed,0,0);
		}
		if(Input.GetKey(KeyCode.E))
		{
			playerState = PlayerState.Walk;
			rb.transform.Translate(ForwardMovementSpeed,0,0);
		}
		if(Input.GetKeyDown(KeyCode.Space) && Grounded == true)
		{
			rb.AddForce(0,1000,0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha1))
	    {
			playerState = PlayerState.Attack;
		}
		if(Input.anyKey == false)
		{
			playerState = PlayerState.Idle;
		}
	}

	public void JumpCheck()
	{
		RaycastHit hit;
		Ray DownwardRay = new Ray (transform.position, Vector3.down);
		
		Debug.DrawRay(transform.position, Vector3.down * RayCastJumpCheckDistance, Color.red);
		
		if(Physics.Raycast(DownwardRay, out hit, RayCastJumpCheckDistance))
		{
			if(hit.collider != null)
			{
				Grounded = true;
			}
		}
		else
		{
			Grounded = false;
		}
	}

	public void AnimationCheck()
	{
		//Animation Switch
		switch (playerState)
		{
		case PlayerState.Idle:
			animationComponent.Play("Idle1");
			break;
			
		case PlayerState.Walk:
			animationComponent.Play("Walk");
			break;
			
		case PlayerState.Attack:
			animationComponent.Play("Attack1h1");
			break;

		case PlayerState.Hit:
			animationComponent.Play("Hit1");
			break;
		}
	}
}
