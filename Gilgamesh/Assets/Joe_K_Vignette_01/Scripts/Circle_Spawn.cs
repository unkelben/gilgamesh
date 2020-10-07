using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Circle_Spawn : MonoBehaviour
{
    Vector2 mousePosition;
    public GameObject circlePrefab;
    private void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Click();
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(circlePrefab, mousePosition, Quaternion.identity);
        }
    }
}
