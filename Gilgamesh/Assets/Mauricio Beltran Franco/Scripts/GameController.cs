using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] Boar boar;
    [SerializeField] Hunter hunter;
    [SerializeField] Player player;

    [SerializeField] Image night;
    [SerializeField] GameObject end;

    int day = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart() {
        boar.Restart();
        player.Restart();
        hunter.Restart();
    }

    public void StartBoar() {
        boar.StartGame();
        player.StartGame();
    }

    public void Drink() {
        player.Drink();
    }

    public void EndDay() {
        hunter.Return();
    }

    public void NewDay() {
        if (day == 3) {
            StartCoroutine("LastDay");
        } else {
            day++;
            StartCoroutine("NextDay");
        }
    }

    IEnumerator NextDay() {
        for (float i = 0; i <= 255; i++) {
            night.color = new Color(0, 0, 0, i/255);
            yield return new WaitForSeconds(3f / 255);
        }
        boar.Restart();
        player.Restart();
        for (float i = 255; i >= 0; i--) {
            night.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(3f / 255);
        }
        hunter.Restart();
    }

    IEnumerator LastDay() {
        for (float i = 0; i <= 255; i++) {
            night.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(3f / 255);
        }
        end.SetActive(true);
    }
}
