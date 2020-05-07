using UnityEngine;
public class RundomRotation : MonoBehaviour
{
	private void Update()
	{
		float zRotation = transform.rotation.z - 1;
		transform.Rotate(0,0, zRotation);
	}
}