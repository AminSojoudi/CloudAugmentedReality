using UnityEngine;
using System.Collections;

public class ContentManager : MonoBehaviour {

	public static ContentManager Instance;

	public GameObject[] Contents;

	void Awake()
	{
		Instance = this;
	}



	public GameObject GetContentByTargetID(int id)
	{
		return Contents[id];
	}
}
