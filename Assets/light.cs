using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {

	private Vector3 _mousePosition;
	private GameObject _light;
	/*
	private GameObject _light;
	private float _distance;
	private Plane _plane;
	private Vector3 _hitPoint;
	private Vector3 _ray;*/
	// Use this for initialization
	void Start () {
		_light = new GameObject("The Light");
		_light.AddComponent(typeof(Light));
		_light.light.color = Color.blue;
		_light.light.type=LightType.Point;
		_light.AddComponent ("blackhole");
	}
	
	// Update is called once per frame
	void Update () {

			
	}
	void OnMouseDown()
	{

		Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100, LayerMask.NameToLayer("Terrain")))
		{
			_light.transform.position = hit.point + new Vector3 (0,1,0);
		}

	}
}
