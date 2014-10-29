using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FaceHandler : MonoBehaviour {

	public static FaceHandler Instance;

	public FaceName[] facePriorites;

	public List<Face> DetectedFaces;

	public Transform ARCameraTransform;

	private int TargetID = 0;

	private GameObject Content;


	void Awake()
	{
		Instance = this;
		DetectedFaces = new List<Face>();
	}


	void Update()
	{

	}

	public void HandleFaces()
	{
		Content = ContentManager.Instance.GetContentByTargetID(TargetID);
		Vector3 Position = Vector3.zero;

		HideContent();
		if (DetectedFaces.Count == 0) {
			return;
		}
		foreach (Face face in DetectedFaces) {
			Position += face.transform.position;
			// har kodoom ke khasti , man akhari ro entekhab kardam
			TargetID = face.TargetID;
		}
		Position *= 1f/3f ;
		ShowContent(Position);
	}


	public void AddToDetectedFaces(Face face)
	{
		DetectedFaces.Add(face);
	}

	public void RemoveFromDetectedFaces(Face face)
	{
		DetectedFaces.Remove(face);
	}

	public void ShowContent(Vector3 position)
	{
		Content.GetComponent<MeshRenderer>().enabled = true;
		Content.transform.position = position;
	}


	public void HideContent()
	{
		Content.GetComponent<MeshRenderer>().enabled = false;
	}



}
