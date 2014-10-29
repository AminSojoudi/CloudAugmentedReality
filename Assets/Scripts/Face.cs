using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour {

	public FaceName faceName;
	public int TargetID;
	private GameObject Content;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



//	public void ShowContent(Vector3 position)
//	{
//		GameObject go = ContentManager.Instance.GetContentByTargetID(TargetID);
//		Content = Instantiate(go) as GameObject;
//		Content.transform.position = position;
//	}
//
//
//	public void HideContent()
//	{
//		GameObject.Destroy(Content);
//	}
}
