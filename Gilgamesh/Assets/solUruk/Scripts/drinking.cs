using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drinking : MonoBehaviour
{
  private Vector3 targetPosition;

  public GameObject air;
  public GameObject pop;

  public GameObject gilText;
  public GameObject enkText;

  private float airIndex = -7.2f;

  public readonly string selectedCharacter = "selectedCharacter";

    private void Start()
    {
      int getCharacter = PlayerPrefs.GetInt(selectedCharacter);

      switch(getCharacter)
      {
        case 0:
          Destroy(enkText);
          break;
        case 1:
          Destroy(gilText);
          break;
      }
    }

    void FixedUpdate()
    {
      if (Input.GetMouseButtonDown(0))
      {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(targetPosition.x);
        // Debug.Log(targetPosition.y);

        int getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        switch(getCharacter)
        {
          case 0:
            if (targetPosition.x>-7.3&&targetPosition.x<-4.7&&targetPosition.y>-1&&targetPosition.y<1.6)
            {
              startDrinking();
            }
            break;
          case 1:
            if (targetPosition.x>4.2&&targetPosition.x<7.4&&targetPosition.y>-1.1&&targetPosition.y<0.4)
            {
              startDrinking();
            }
            break;
        }
      }
    }

    private void startDrinking()
    {
      if (airIndex == -7.2)
      {
        Instantiate(pop, new Vector3(6.5f, -5.75f, 0f), Quaternion.identity);
      }
      if (airIndex < 6.5)
      {
        // Debug.Log(airIndex);
        Instantiate(air, new Vector3(airIndex, -5.75f, 0f), Quaternion.identity);
        airIndex += 1.8f;


      }
      else
      {
        SceneManager.LoadScene("sheep");
      }
    }
}
