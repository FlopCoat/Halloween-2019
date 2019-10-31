using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
	public Vector3 rotation;
	public float distance = 1f;
	public MeshFilter levelSphere;
	public GameObject pumpkinPrefab;
	private List<GameObject> allPumpkins = new List<GameObject>();

	private void Start()
	{
		Generate();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			Generate();
		}

		transform.Rotate(rotation * Time.deltaTime);

		foreach(var pumpkin in allPumpkins)
		{
			pumpkin.transform.Rotate(-rotation * Time.deltaTime);
		}
	}

	private void Generate()
	{
		foreach (var pumpkin in allPumpkins)
		{
			Destroy(pumpkin);
		}
		allPumpkins.Clear();

		foreach (var vertex in levelSphere.mesh.vertices)
		{
			var pumpkin = Instantiate(pumpkinPrefab, transform);
			pumpkin.transform.position = transform.position + transform.TransformPoint(vertex) * distance;
			allPumpkins.Add(pumpkin);
		}
	}
}