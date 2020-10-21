using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{
  private Texture2D cursorType;

  public Texture2D hand;
  public Texture2D grab;

  private Vector2 hotspot;
    private void Start()
    {
      Cursor.lockState = CursorLockMode.Confined;

      SetHand();
      Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
    }

    public void SetHand()
    {
      cursorType = hand;
      Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }

    public void SetGrab()
    {
      cursorType = grab;
      Cursor.SetCursor(cursorType, hotspot, CursorMode.Auto);
    }
}
