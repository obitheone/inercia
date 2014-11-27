using UnityEngine;
using System.Collections;

public class particlemouse : MonoBehaviour {

	private Vector3 _screenPoint;
	private Vector3 _offset;
	private Vector3 _curScreenPoint;
	private Vector3 _curPosition;
	private bool _underInertia;



	//void LateUpdate () {

		//_curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z);
		//_curPosition = Camera.main.ScreenToWorldPoint(_curScreenPoint);

		/*ParticleSystem.Particle[] p = new ParticleSystem.Particle[particleSystem.particleCount+1];
		int l = particleSystem.GetParticles(p);
		int i = 0;
		while (i < l) {
			p[i].velocity = new Vector3(_curPosition.x, p[i].lifetime / p[i].startLifetime * 10F, _curPosition.z);
			i++;
		}
		particleSystem.SetParticles(p, l);*/

	//}
	float distance = 5;
	void LateUpdate ()
	{
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
		int count = particleSystem.GetParticles(particles);
		
		for(int i = 0; i < count; i++)
		{
			float yVel = (particles[i].lifetime / particles[i].startLifetime) * distance;
			particles[i].velocity = new Vector3(0, yVel, i);
		}
		particleSystem.SetParticles(particles, count);
	}

	void FixedUpdate()
	{

	}
	
	void OnMouseOver () {

	}
	
	
	void OnMouseDown()
	{
			Screen.showCursor = false;
			_underInertia = false;
	}
	void OnMouseDrag()
	{

	}
	void OnMouseUp()
	{
		_underInertia = true;
		Screen.showCursor = true;
	}
}
