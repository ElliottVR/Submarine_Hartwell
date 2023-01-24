using UnityEngine;

public class HideMouse : MonoBehaviour 
{
	void Start () 
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }
}
