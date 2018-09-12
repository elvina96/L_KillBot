using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour {
	[SerializeField] float speed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate();
	}

	public void Rotate()
	{
        transform.Rotate(0, speed, 0, Space.World);
	}
}
