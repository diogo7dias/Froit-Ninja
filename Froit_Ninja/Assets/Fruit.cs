using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
	public GameObject fruitSlicedPrefab;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Blade")
		{
			Instantiate(fruitSlicedPrefab);
			Destroy(gameObject);
		}
	}
}
