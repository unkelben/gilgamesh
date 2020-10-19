using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionSelection : MonoBehaviour
{
    [SerializeField] Button[] choices;

    // Options for the sub categories
    public GameObject option1;
    public GameObject option2;
    public GameObject option3;
    public GameObject option4;
    public GameObject option5;
    public GameObject option6;
    public GameObject option7;
    public GameObject option8;
    public GameObject option9;
    public GameObject option10;
    public GameObject option11;
    public GameObject option12;
    public GameObject option13;
    public GameObject option14;
    public GameObject option15;

    // Changes on Enkidu's character
    public GameObject change1;
    public GameObject change2;
    public GameObject change3;
    public GameObject change4;
    public GameObject change5;
    public GameObject change6;
    public GameObject change7;
    public GameObject change8;
    public GameObject change9;
    public GameObject change10;
    public GameObject change11;
    public GameObject change12;
    public GameObject change13;
    public GameObject change14;
    public GameObject change15;

    // Enkidu's real appearance
    public GameObject real1;
    public GameObject real2;
    public GameObject real3;
    public GameObject real4;
    public GameObject real5;

    // Enkidu's character confusion face
    public GameObject confused;

    public int score = 0;

    public GameObject mButton1;
    public GameObject mButton2;
    public GameObject mButton3;
    public GameObject mButton4;
    public GameObject mButton5;


    void Start()
    {
        // Variables for main categories buttons
        mButton1 = GameObject.FindWithTag("Head");
        mButton2 = GameObject.FindWithTag("Hair");
        mButton3 = GameObject.FindWithTag("Chest");
        mButton4 = GameObject.FindWithTag("Legs");
        mButton5 = GameObject.FindWithTag("Feet");

        // Initial values for options so the options from sub categories appears right off the bat
        option1.SetActive(true);
        option1.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

        option2.SetActive(true);
        option3.SetActive(true);
        option4.SetActive(false);

        option5.SetActive(false);
        option5.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

        option6.SetActive(false);
        option7.SetActive(false);

        option8.SetActive(false);
        option8.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

        option9.SetActive(false);

        option10.SetActive(false);
        option10.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

        option11.SetActive(false);
        option12.SetActive(false);
        option13.SetActive(false);
        option14.SetActive(false);

        option15.SetActive(false);
        option15.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);


        // Initial values for options on Enkidu's character that appears right off the bat
        change1.SetActive(true);
        change2.SetActive(false);
        change3.SetActive(false);
        change4.SetActive(false);
        change5.SetActive(true);
        change6.SetActive(false);
        change7.SetActive(false);
        change8.SetActive(true);
        change9.SetActive(false);
        change10.SetActive(true);
        change11.SetActive(false);
        change12.SetActive(false);
        change13.SetActive(false);
        change14.SetActive(false);
        change15.SetActive(true);

        // Initial values for Enkidu's real appearance
        real1.SetActive(false);
        real2.SetActive(false);
        real3.SetActive(false);
        real4.SetActive(false);
        real5.SetActive(false);

        // Initial values for Enkidu's character confusion face
        confused.SetActive(false);

        // Makes possible for chosen specific buttons
        foreach (Button btn in choices)
        {
            Button choice = btn;
            btn.onClick.AddListener(() => TaskOnClick(choice));
        }
    }

    void TaskOnClick(Button choice)
    {
        // Appear and disapear function for subcategories of Head, Hair, Chest, Legs and Feet

        if (choice.gameObject.tag == "Head")
        {
            Debug.Log("Head subcategory opened");

            // Active Head button
            mButton1.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            // Inactive Hair, Chest, Legs and Feet buttons
            mButton2.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton3.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton4.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);


            option1.SetActive(true);
            option2.SetActive(true);
            option3.SetActive(true);
            option4.SetActive(false);
            option5.SetActive(false);
            option6.SetActive(false);
            option7.SetActive(false);
            option8.SetActive(false);
            option9.SetActive(false);
            option10.SetActive(false);
            option11.SetActive(false);
            option12.SetActive(false);
            option13.SetActive(false);
            option14.SetActive(false);
            option15.SetActive(false);
        }
    
        if (choice.gameObject.tag == "Hair")
        {
            Debug.Log("Hair subcategory opened");

            // Active Hair button
            mButton2.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            // Inactive Head, Chest, Legs and Feet buttons
            mButton1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton3.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton4.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            option4.SetActive(true);
            option5.SetActive(true);
            option6.SetActive(true);
            option7.SetActive(false);
            option8.SetActive(false);
            option9.SetActive(false);
            option10.SetActive(false);
            option11.SetActive(false);
            option12.SetActive(false);
            option13.SetActive(false);
            option14.SetActive(false);
            option15.SetActive(false);
        }

        if (choice.gameObject.tag == "Chest")
        {
            Debug.Log("Chest subcategory opened");

            // Active Chest button
            mButton3.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            // Inactive Head, Hair, Legs and Feet buttons
            mButton1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton2.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton4.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            option4.SetActive(false);
            option5.SetActive(false);
            option6.SetActive(false);
            option7.SetActive(true);
            option8.SetActive(true);
            option9.SetActive(true);
            option10.SetActive(false);
            option11.SetActive(false);
            option12.SetActive(false);
            option13.SetActive(false);
            option14.SetActive(false);
            option15.SetActive(false);
        }

        if (choice.gameObject.tag == "Legs")
        {
            Debug.Log("Legs subcategory opened");

            // Active Legs button
            mButton4.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            // Inactive Head, Hair, Chest and Feet buttons
            mButton1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton2.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton3.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            option4.SetActive(false);
            option5.SetActive(false);
            option6.SetActive(false);
            option7.SetActive(false);
            option8.SetActive(false);
            option9.SetActive(false);
            option10.SetActive(true);
            option11.SetActive(true);
            option12.SetActive(true);
            option13.SetActive(false);
            option14.SetActive(false);
            option15.SetActive(false);
        }

        if (choice.gameObject.tag == "Feet")
        {
            Debug.Log("Feet subcategory opened");

            // Active Feet button
            mButton5.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            // Inactive Head, Hair, Chest and Legs buttons
            mButton1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton2.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton3.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);
            mButton4.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            option1.SetActive(false);
            option2.SetActive(false);
            option3.SetActive(false);
            option4.SetActive(false);
            option5.SetActive(false);
            option6.SetActive(false);
            option7.SetActive(false);
            option8.SetActive(false);
            option9.SetActive(false);
            option10.SetActive(false);
            option11.SetActive(false);
            option12.SetActive(false);
            option13.SetActive(true);
            option14.SetActive(true);
            option15.SetActive(true);
        }


        // If specific options are chosen in  the sub categories

        // Head category
        if (choice.gameObject.tag == "Option1")
        {
            change1.SetActive(true);
            change2.SetActive(false);
            change3.SetActive(false);

            // Keeps the Head button selected
            mButton1.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            Debug.Log("Option 1 chosen");
        }

        if (choice.gameObject.tag == "Option2")
        {
            StartCoroutine("ChangingToReal1");

            change1.SetActive(false);
            change2.SetActive(true);
            change3.SetActive(false);

            // Keeps the Head button selected
            mButton1.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 2 chosen");
        }

        if (choice.gameObject.tag == "Option3")
        {
            change1.SetActive(false);
            change2.SetActive(false);
            change3.SetActive(true);

            // Keeps the Head button selected
            mButton1.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option1.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 3 chosen");
        }

        // Hair category
        if (choice.gameObject.tag == "Option4")
        {
            change4.SetActive(true);
            change5.SetActive(false);
            change6.SetActive(false);

            // Keeps the Hair button selected
            mButton2.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 4 chosen");
        }

        if (choice.gameObject.tag == "Option5")
        {
            change4.SetActive(false);
            change5.SetActive(true);
            change6.SetActive(false);

            // Keeps the Hair button selected
            mButton2.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            Debug.Log("Option 5 chosen");
        }

        if (choice.gameObject.tag == "Option6")
        {
            StartCoroutine("ChangingToReal2");

            change4.SetActive(false);
            change5.SetActive(false);
            change6.SetActive(true);

            // Keeps the Hair button selected
            mButton2.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option5.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 6 chosen");
        }

        // Chest category
        if (choice.gameObject.tag == "Option7")
        {
            StartCoroutine("ChangingToReal3");

            change7.SetActive(true);
            change8.SetActive(false);
            change9.SetActive(false);

            // Keeps the Chest button selected
            mButton3.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option8.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 7 chosen");
        }

        if (choice.gameObject.tag == "Option8")
        {
            change7.SetActive(false);
            change8.SetActive(true);
            change9.SetActive(false);

            // Keeps the Chest button selected
            mButton3.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            Debug.Log("Option 8 chosen");
        }

        if (choice.gameObject.tag == "Option9")
        {
            change7.SetActive(false);
            change8.SetActive(false);
            change9.SetActive(true);

            // Keeps the Chest button selected
            mButton3.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option8.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 9 chosen");
        }

        // Legs category
        if (choice.gameObject.tag == "Option10")
        {
            change10.SetActive(true);
            change11.SetActive(false);
            change12.SetActive(false);

            // Keeps the Legs button selected
            mButton4.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            Debug.Log("Option 10 chosen");
        }

        if (choice.gameObject.tag == "Option11")
        {
            change10.SetActive(false);
            change11.SetActive(true);
            change12.SetActive(false);

            // Keeps the Legs button selected
            mButton4.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option10.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 11 chosen");
        }

        if (choice.gameObject.tag == "Option12")
        {
            StartCoroutine("ChangingToReal4");

            change10.SetActive(false);
            change11.SetActive(false);
            change12.SetActive(true);

            // Keeps the Legs button selected
            mButton4.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option10.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 12 chosen");
        }

        // Feet category
        if (choice.gameObject.tag == "Option13")
        {
            change13.SetActive(true);
            change14.SetActive(false);
            change15.SetActive(false);

            // Keeps the Feet button selected
            mButton5.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option15.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 13 chosen");
        }

        if (choice.gameObject.tag == "Option14")
        {
            StartCoroutine("ChangingToReal5");

            change13.SetActive(false);
            change14.SetActive(true);
            change15.SetActive(false);

            // Keeps the Feet button selected
            mButton5.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);
            // Deselects the default option
            option15.GetComponent<Image>().color = new Color(0.2627451f, 0.4039216f, 0.4901961f, 1.0f);

            Debug.Log("Option 14 chosen");
        }

        if (choice.gameObject.tag == "Option15")
        {
            change13.SetActive(false);
            change14.SetActive(false);
            change15.SetActive(true);

            // Keeps the Feet button selected
            mButton5.GetComponent<Image>().color = new Color(0.1490196f, 0.2392157f, 0.3058824f, 1.0f);

            Debug.Log("Option 15 chosen");
        }

    }

    IEnumerator ChangingToReal1()
    {
        yield return new WaitForSeconds(0.5f);

        real1.SetActive(true);

        GameObject.Find("Button_Option_1 (1)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_2 (1)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_3 (1)").GetComponent<Button>().interactable = false;

        change1.SetActive(false);
        change2.SetActive(false);
        change3.SetActive(false);

        score++;

        if (score == 5)
        {
            ConfusedFace();
        }
    }

    IEnumerator ChangingToReal2()
    {
        yield return new WaitForSeconds(0.5f);

        real2.SetActive(true);

        GameObject.Find("Button_Option_1 (2)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_2 (2)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_3 (2)").GetComponent<Button>().interactable = false;

        change4.SetActive(false);
        change5.SetActive(false);
        change6.SetActive(false);

        score++;

        if (score == 5)
        {
            ConfusedFace();
        }
    }

    IEnumerator ChangingToReal3()
    {
        yield return new WaitForSeconds(0.5f);

        real3.SetActive(true);

        GameObject.Find("Button_Option_1 (3)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_2 (3)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_3 (3)").GetComponent<Button>().interactable = false;

        change7.SetActive(false);
        change8.SetActive(false);
        change9.SetActive(false);

        score++;

        if (score == 5)
        {
            ConfusedFace();
        }
    }

    IEnumerator ChangingToReal4()
    {
        yield return new WaitForSeconds(0.5f);

        real4.SetActive(true);

        GameObject.Find("Button_Option_1 (4)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_2 (4)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_3 (4)").GetComponent<Button>().interactable = false;

        change10.SetActive(false);
        change11.SetActive(false);
        change12.SetActive(false);

        score++;

        if (score == 5)
        {
            ConfusedFace();
        }
    }

    IEnumerator ChangingToReal5()
    {
        yield return new WaitForSeconds(0.5f);

        real5.SetActive(true);

        GameObject.Find("Button_Option_1 (5)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_2 (5)").GetComponent<Button>().interactable = false;
        GameObject.Find("Button_Option_3 (5)").GetComponent<Button>().interactable = false;

        change13.SetActive(false);
        change14.SetActive(false);
        change15.SetActive(false);

        score++;

        if (score == 5)
        {
            ConfusedFace();
        }
    }

    void ConfusedFace()
    {
            Debug.Log("FINISHED");

            confused.SetActive(true);

        // Activate ending
        StartCoroutine("Ending");
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {

    }

}