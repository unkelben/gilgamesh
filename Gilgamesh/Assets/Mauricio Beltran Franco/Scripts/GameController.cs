using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    [SerializeField] Boar boar;
    [SerializeField] Hunter hunter;
    [SerializeField] Player player;

    [SerializeField] MouseOver trap;
    [SerializeField] MouseOver shovel;
    [SerializeField] MouseOver pond;

    [SerializeField] Image night;
    [SerializeField] GameObject end;

    [SerializeField] AudioSource shovelSound;
    [SerializeField] AudioSource fallingSound;
    [SerializeField] AudioSource closeTrapSound;
    [SerializeField] AudioSource placeTrapSound;
    [SerializeField] AudioSource drinkSound;
    [SerializeField] AudioSource madSound;
    int day = 1;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Restart() {
        pond.enabled = false;
        shovel.enabled = false;
        trap.enabled = false;
        boar.Restart();
        player.Restart();
        hunter.Restart();
    }

    public void StartBoar() {
        shovel.enabled = true;
        trap.enabled = true;
        boar.StartGame();
        player.StartGame();
    }

    public void Drink() {
        pond.enabled = true;
        player.Drink();
    }

    public void EndDay() {
        pond.enabled = false;
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

    public void DisableShovel() {
        shovel.enabled = false;
    }

    public void PlayShovel() {
        shovelSound.Play();
    }

    public void PlayFalling() {
        fallingSound.Play();
    }

    public void PlayCloseTrap() {
        closeTrapSound.Play();
    }

    public void PlayPlaceTrap() {
        placeTrapSound.Play();
    }

    public void PlayDrink() {
        drinkSound.Play();
    }

    public void PlayMad() {
        madSound.Play();
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
