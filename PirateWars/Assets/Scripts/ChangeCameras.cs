using UnityEngine;
using System.Collections;

public class ChangeCameras: MonoBehaviour
{
	public Camera cameraMain;
	public Camera cameraLeft;
	public Camera cameraRight;

	public GameObject cameraMainLocation;
	public GameObject cameraLeftLocation;
	public GameObject cameraRightLocation;

	public float smooth = 1.5f;

	private Vector3 mouseOrigin;
	private bool isRotating;

	void Start() {
		cameraMain.active = true;
		cameraLeft.active = false;
		cameraRight.active = false;
		Screen.showCursor = false;
	}
	void Update () {
		Screen.showCursor = false;

		if(Input.GetKey("q")){
			cameraLeft.active = true;
			cameraRight.active = false;
		}
		else if(Input.GetKey("e")){
			cameraLeft.active = false;
			cameraRight.active = true;
		}
		else if(Input.GetKey(KeyCode.Space)){

			cameraMain.active = true;
			cameraLeft.active = false;
			cameraRight.active = false;
		}

		if(cameraMain.active)
		{
			if(Input.GetMouseButtonDown(1))
			{
				mouseOrigin = Input.mousePosition;
				isRotating = true;
			}

			if (!Input.GetMouseButton(1))
				isRotating=false;

			if (isRotating)
			{
				Vector3 pos = cameraMain.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
				
				cameraMain.transform.RotateAround(transform.position, transform.right, -pos.y * 4);
				cameraMain.transform.RotateAround(transform.position, Vector3.up, pos.x * 4);
			}
		}

		if(cameraLeft.active)
		{
			cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, cameraLeftLocation.transform.position, smooth * Time.deltaTime);
			cameraMain.transform.rotation = Quaternion.Slerp(cameraMain.transform.rotation, cameraLeftLocation.transform.rotation, smooth * Time.deltaTime);
		}
		else if(cameraRight.active)
		{
			cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, cameraRightLocation.transform.position, smooth * Time.deltaTime);
			cameraMain.transform.rotation = Quaternion.Slerp(cameraMain.transform.rotation, cameraRightLocation.transform.rotation, smooth * Time.deltaTime);
		}
		else
		{
			cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, cameraMainLocation.transform.position, smooth * Time.deltaTime);
			cameraMain.transform.rotation = Quaternion.Slerp(cameraMain.transform.rotation, cameraMainLocation.transform.rotation, smooth * Time.deltaTime);
		}
	}
}