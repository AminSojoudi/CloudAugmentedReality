using UnityEngine;
using System.Collections;

public class ContentManager : MonoBehaviour {

	public static ContentManager Instance;

	public GameObject[] Contents;

	public GameObject currentContent;

	void Awake()
	{
		Instance = this;
	}



	public GameObject GetContentByTargetID(int id)
	{
		return currentContent;
	}
}
