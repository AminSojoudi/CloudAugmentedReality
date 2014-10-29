using UnityEngine;
using System.Collections;
using System;

public class WebCam : MonoBehaviour
{
	public GameObject LastImageSent;
	public string screenShotURL = "http://images.earthcam.com/ec_metros/ourcams/fridays.jpg";
	public float TimeToSleep;




	private WebCamTexture webcamTexture ;
	private bool canCapture = false;
	private WWWForm form;
	private Texture2D tex;


		void Start ()
		{
				webcamTexture = new WebCamTexture ();
				webcamTexture.Play ();
				InvokeRepeating("SetCaptureToTrue" , TimeToSleep * 3 , TimeToSleep);
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Space)) {
						Debug.Log ("Send image called");
			canCapture = true;
				}
			
		}
	
		IEnumerator SendImage ()
		{
		Debug.Log("Send Image Called");
				// Upload to a cgi script
				WWW www = new WWW (screenShotURL, form);
				yield return www;
				if (!String.IsNullOrEmpty (www.error)) {
						print (www.error);
				}

				
				Debug.Log("Data Recieved from Server!");
		Debug.Log(www.text);
		}


	void OnPostRender () 
	{ 
		if (canCapture) {
			canCapture = false;
		Debug.Log("Create a texture the size of the screen, RGB24 format");
		// Create a texture the size of the screen, RGB24 format
		Color[] colors = webcamTexture.GetPixels();
		int width = webcamTexture.width;
		int height = webcamTexture.height;
		tex = new Texture2D(width, height);
		tex.SetPixels(colors);
		tex.Apply();

		LastImageSent.renderer.material.mainTexture = tex;
		
		Debug.Log("Encode texture into PNG");
		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG ();
		//Destroy (tex);
			
		// Create a Web Form
		form = new WWWForm ();
		form.AddField ("frameCount", Time.frameCount.ToString ());
		form.AddBinaryData ("fileUpload", bytes, "screenShot.png", "image/png");
		StartCoroutine (SendImage ());
		}
	}

	void SetCaptureToTrue()
	{
		canCapture = true;
	}



		
		
		

		
		

	

}
