using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Crafting : MonoBehaviour {

    [SerializeField] protected GameObject progressBar;
    [SerializeField] protected GameObject currentProgress;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Activate() {
        progressBar.SetActive(true);
    }

    public void Deactivate() {
        progressBar.SetActive(false);
    }

    abstract public void Action();
}
