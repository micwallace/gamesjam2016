using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour
{

	private bool doorOpen = false;
	private Ray ray;
	private RaycastHit hit;
	private float distance = 5.0f;

	private void Update()
	{
		if (Input.GetKeyDown("e"))
		{
			int x = Screen.width / 2;
			int y = Screen.height / 2;
			ray = Camera.main.ScreenPointToRay(new Vector2(x, y));
			if (Physics.Raycast(ray, out hit, distance))
			{
				if(hit.collider.gameObject.tag == "OpenableDoor"){//Check that your ray is colliding with the door
					if (!doorOpen)
					{
						hit.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
						doorOpen = true;
					}
					else
					{
						hit.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
						doorOpen = false;
					}
				}
			}
		}
	}
}