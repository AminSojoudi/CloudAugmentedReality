using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour {

	public FaceName faceName;
	public int TargetID;
	public Vector3 PositionDiff = Vector3.zero;
	private GameObject Content;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetContent(GameObject content)
	{
		Content = content;
		content.transform.parent = this.transform;
		content.transform.rotation = Quaternion.Euler(new Vector3(90 ,0 ,0));
		content.transform.position = Vector3.zero;
	}



	public void SetPositionDiff(Vector3 position)
	{
		Content.transform.position += position;
	}

	public GameObject GetContent()
	{
		return Content;
	}

}
