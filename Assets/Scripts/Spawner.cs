using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public Sprite sprite;
	public GameObject pumpkinPrefab;
	private List<GameObject> allPumpkins = new List<GameObject>();

	private void Start()
	{
		GenerateEnemies();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			GenerateEnemies();
		}
	}

	public void GenerateEnemies()
	{
		foreach (var pumpkin in allPumpkins)
		{
			Destroy(pumpkin);
		}
		allPumpkins.Clear();

		int pixels = 0;
		for (int y = 0; y < sprite.rect.height; y++)
		{
			for (int x = 0; x < sprite.rect.width; x++)
			{
				pixels++;
				var color = sprite.texture.GetPixel(x, y);
				if (color != Color.white)
				{
					var pumpkin = Instantiate(pumpkinPrefab, transform);
					var pumpkinTrans = pumpkin.transform;
					pumpkinTrans.localPosition = new Vector3(x, y, 0);
					allPumpkins.Add(pumpkin);
				}
			}
		}
	}
}