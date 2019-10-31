using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : MonoBehaviour
{
	private Rigidbody rb;
	private bool ready;
	private bool activated;
	private Vector3 startPos;

	private void Start()
	{
		startPos = transform.position;
	}

	private void Update()
	{
		if (!ready)
		{
			return;
		}

		var distance = (transform.position - startPos).magnitude;
		if (distance > 50f)
		{
			Destroy(gameObject);
		}
		else if (!activated && distance > 0.1f)
		{
			activated = true;
			GameManager.gm.AddScore();
			rb = GetComponent<Rigidbody>();
			Destroy(GetComponent<SphereCollider>());
		}
	}

	private void FixedUpdate()
	{
		if (activated && rb)
		{
			rb.velocity *= 1.2f;
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		ready = true;
	}
}