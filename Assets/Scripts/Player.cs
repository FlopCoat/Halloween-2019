using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float pullSpeed = 1f;
	public float shootPower = 1f;
	public Rigidbody currentWeapon;

    private void Update()
    {
		var transPos = transform.position;
		if (Input.GetButton("Fire1") && !currentWeapon)
		{
			RaycastHit hit;
			LayerMask mask = 1 << 9;
			if (Physics.Raycast(transPos, GameManager.cam.forward, out hit, Mathf.Infinity, mask))
			{
				currentWeapon = hit.collider.GetComponent<Rigidbody>();
				currentWeapon.transform.parent = null;
				currentWeapon.isKinematic = false;
				currentWeapon.useGravity = false;
			}
		}
		else if (Input.GetButtonUp("Fire1") && currentWeapon)
		{
			Shoot();
		}

		if (currentWeapon)
		{
			var holdingPos = transPos + GameManager.cam.forward.normalized * 2f;
			currentWeapon.velocity = (holdingPos - currentWeapon.position) * pullSpeed;
		}
	}

	public void Shoot()
	{
		currentWeapon.AddForce(GameManager.cam.forward * shootPower, ForceMode.VelocityChange);
		currentWeapon.useGravity = true;
		currentWeapon = null;
	}
}
