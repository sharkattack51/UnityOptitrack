/**
 * Adapted from johny3212
 * Written by Matt Oskamp
 */
using UnityEngine;

public class OptiTrackObject : MonoBehaviour
{
	public int rigidbodyIndex;

	public bool usePosition = true;
	public Vector3 positionOffset;

	public bool useRotation = true;
	public Vector3 rotationOffset;


	void Start ()
	{

	}

	void Update ()
	{
		if(!OptiTrackManager.Instance.getTracked (rigidbodyIndex))
			return;
		
		Vector3 position = OptiTrackManager.Instance.getPosition(rigidbodyIndex);
		Quaternion rotation = OptiTrackManager.Instance.getOrientation(rigidbodyIndex);

		if(usePosition)
		{
			position += positionOffset;
			this.gameObject.transform.localPosition = position;
		}

		if(useRotation)
		{
			rotation *= Quaternion.Euler(rotationOffset);
			this.gameObject.transform.localRotation = rotation;
		}
	}
}
