using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	[SerializeField] private float _maxRotationSpeed = 50;
	[SerializeField] private float _minRotationSpeed = 10;
	[SerializeField] private MoveBox _moveBox;

	private readonly List<int> _direction = new List<int> { 1, -1, 1, -1, 1, -1, 1, -1, 1, -1, 1, -1 };
	private int _selectedDirection;

	private void OnEnable()
	{
		SetRotationDirection();
	}

	private void Update()
	{
		Rotation();
	}

	private void Rotation()
	{
		if(_moveBox.IsBoxStop == false)
		{
			transform.Rotate(new Vector3(0, 0, GetZParametr() * Time.deltaTime), Space.Self);
		}		
	}

	private float GetZParametr()
	{
		return SetRotationSpeed() * _selectedDirection;
	}

	private float SetRotationSpeed()
	{
		return Random.Range(_minRotationSpeed, _maxRotationSpeed);
	}

	private void SetRotationDirection()
	{
		int d = new System.Random().Next(0, 12);
		_selectedDirection = _direction[d];
	}
}