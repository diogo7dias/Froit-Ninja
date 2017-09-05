using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour 
{
	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	private Vector2 previousPosition;
	private GameObject currentBladeTrail;
	private bool isCutting = false;
	private Rigidbody2D rb;
	private Camera cam;
	private CircleCollider2D circleCollider;

	void Start()
	{
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			StartCutting();
		}
		else if(Input.GetMouseButtonUp(0))
		{
			StopCutting();
		}

		if(isCutting)
		{
			UpdateCut();
		}
	}

	void UpdateCut()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if(velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		}
		else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
		circleCollider.enabled = false;
	}

	void StopCutting()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}
}
