using UnityEngine;
using System.Collections;

public class SkeletonRaycasterJumpCheck : MonoBehaviour {

	public Transform myTransform;
	public GameObject ground;
	private float JumpDistance = 0.1f;

	public bool touching;

	// Use this for initialization
	void Start ()
	{
		myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		Ray DownwardRay = new Ray (transform.position, Vector3.down);

		Debug.DrawRay(transform.position, Vector3.down * JumpDistance, Color.red);

		if(Physics.Raycast(DownwardRay, out hit, JumpDistance))
		{
			if(hit.collider != null)
			{
				touching = true;
			}
		}
		else
		{
			touching = false;
		}
	}
}
