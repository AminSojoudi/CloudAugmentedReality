using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FaceHandler : MonoBehaviour {

	public static FaceHandler Instance;

	public List<Face> DetectedFaces;

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
		if (DetectedFaces.Count == 0) {
			return;
		}
		foreach (Face face in DetectedFaces) {
			face.SetContent(ContentManager.Instance.GetContentByTargetID(face.TargetID));
			Vector3 Position = face.GetContent().transform.position;
			Position += face.PositionDiff;
			face.SetPositionDiff(Position);
		}
	}


	public void AddToDetectedFaces(Face face)
	{
		DetectedFaces.Add(face);
	}

	public void RemoveFromDetectedFaces(Face face)
	{
		DetectedFaces.Remove(face);
	}


}
