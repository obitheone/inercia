using UnityEngine;
using System.Collections;

public class mouseinertial : MonoBehaviour
{
	private Vector3 _screenPoint;
	private Vector3 _offset;
	private Vector3 _curScreenPoint;
	private Vector3 _curPosition;
	private Vector3 _velocity;
	private bool _underInertia;
	private bool _pressmouse;
	private float _time = 0.0f;
	public float fuerza=300;
	void FixedUpdate()
	{
		if (_pressmouse) {
			Vector3 _prevPosition = _curPosition;
			_curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
			_curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint) + _offset;
			_velocity = _curPosition - _prevPosition;
			transform.position = _curPosition;
			rigidbody.velocity = Vector3.zero;	
			}
	}

	void OnMouseOver () {

		if (Input.GetMouseButtonDown (1)) {
					if (_pressmouse) _pressmouse = false;
					rigidbody.AddForce(Camera.main.transform.forward * 500);
				}
		if (Input.GetMouseButtonDown (2)) {
					if (_pressmouse)_pressmouse = false;
					rigidbody.AddForce(-Camera.main.transform.forward * 500);
				}
	}


	void OnMouseDown()
	{

		if (!_pressmouse) {
						_pressmouse = true;			
						_screenPoint = Camera.main.WorldToScreenPoint (gameObject.transform.position);
						_offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
						Screen.showCursor = false;
						_underInertia = false;
						rigidbody.velocity = Vector3.zero;
						rigidbody.AddTorque (new Vector3 (10, 10, 0) * fuerza);
				}
		else {
			_pressmouse = false;
				}

	}
	void OnMouseDrag()
	{
		/*Vector3 _prevPosition = _curPosition;
		_curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
		_curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint) + _offset;
		_velocity = _curPosition - _prevPosition;
		transform.position = _curPosition;
		rigidbody.velocity = Vector3.zero;*/
	}
	void OnMouseUp()
	{
		_underInertia = true;
		Screen.showCursor = true;
		rigidbody.AddForce(_velocity * fuerza);
	}
}
