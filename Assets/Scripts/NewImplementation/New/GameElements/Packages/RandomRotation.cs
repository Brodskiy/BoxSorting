using System.Collections.Generic;
using UnityEngine;
public class RandomRotation : MonoBehaviour
{
	[SerializeField] private float _maxRotationSpeed = 100;
	[SerializeField] private float _minRotationSpeed = 10;

	private List<int> _direction = new List<int> { 1, -1, 1, -1, 1, -1, 1, -1, 1, -1, 1, -1 };
	
	private void Update()
	{
		Rotation();
	}

	private void Rotation()
	{
		transform.Rotate(new Vector3(0, 0, GetZParametr() * Time.deltaTime), Space.Self);
	}

	private float GetZParametr()
	{
		return SetRotationSpeed() * SetRotationDirection();
	}

	private float SetRotationSpeed()
	{
		return Random.Range(_minRotationSpeed, _maxRotationSpeed);
	}

	private int SetRotationDirection()
	{
		int d = new System.Random().Next(0, 12);
		return _direction[d];
	}
}