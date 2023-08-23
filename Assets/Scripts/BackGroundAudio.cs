using UnityEngine;
using System.Collections;

public class BackGroundAudio : MonoBehaviour
{
	// Use this for initialization
	public void Awake()
	{
		DontDestroyOnLoad(this);

		if (FindObjectsOfType(GetType()).Length > 2)
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
