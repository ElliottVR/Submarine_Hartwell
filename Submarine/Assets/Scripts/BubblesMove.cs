using UnityEngine;
using System.Collections;

public class BubblesMove : MonoBehaviour {

	public GameObject player;

	public Vector3 offset;

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}