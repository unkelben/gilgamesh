using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D cursorHand;
    public Texture2D cursorPoint;
    public Texture2D cursorGrab;
    public Texture2D cursorPencil;
    public Texture2D cursorScrub;

    private bool lastMouseState;
    private string lastSceneState;


    private void Update()
    {
        bool mouseState = Input.GetMouseButton(0);
        string sceneState = GameObject.Find("scene_manager").GetComponent<sceneManager>().sceneState;
        if (mouseState != lastMouseState || sceneState != lastSceneState)
        {
            switch (sceneState)
            {
                case "path":
                    if (Input.GetMouseButton(0))
                    {
                        Cursor.SetCursor(cursorPencil, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    else
                    {
                        Cursor.SetCursor(cursorPencil, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    break;
                case "mountains":
                    if (Input.GetMouseButton(0))
                    {
                        Cursor.SetCursor(cursorGrab, Vector2.zero, CursorMode.ForceSoftware);
                    } 
                    else
                    {
                        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    break;
                case "feet":
                    if (Input.GetMouseButton(0))
                    {
                        Cursor.SetCursor(cursorScrub, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    else
                    {
                        Cursor.SetCursor(cursorScrub, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    break;
                case "council":
                    if (Input.GetMouseButton(0))
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    else
                    {
                        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    }
                    break;
                default:
                    break;
            }
        }

        lastSceneState = sceneState; 
        lastMouseState = mouseState;
    }


    private void OnMouseEnter()
    {
        if (GameObject.Find("scene_manager").GetComponent<sceneManager>().sceneState == "mountains")
        {
            Cursor.SetCursor(cursorPoint, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    private void OnMouseExit()
    {
        if (GameObject.Find("scene_manager").GetComponent<sceneManager>().sceneState == "mountains")
        {
            Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
