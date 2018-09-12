using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField] enum RotationAxis
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2,
    }

    [SerializeField] float sensitivityX = 9f;
    [SerializeField] float sensitivityY = 9f;

    [SerializeField] float minimumVert = -45f;
	[SerializeField] float maximumVert = 45f;

	private float _rotationX = 0;

    [SerializeField] RotationAxis axis = RotationAxis.MouseXandY;

	// Use this for initialization
	void Start () {
		Rigidbody body = GetComponent<Rigidbody>();

		if (body != null)
			body.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (axis == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else if (axis == RotationAxis.MouseY)
        {
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float _rotationY = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
        else
        {
			_rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
			_rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

			float delta = Input.GetAxis("Mouse X") * sensitivityX;
			float rotationY = transform.localEulerAngles.y + delta;

			transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
	}
}
