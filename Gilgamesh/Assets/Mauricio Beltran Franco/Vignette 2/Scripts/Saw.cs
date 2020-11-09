using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Crafting {

    Log log;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public override void Action() {
        currentProgress.transform.localScale += Vector3.right * 0.2f;
        if (currentProgress.transform.localScale.x == 1) {
            currentProgress.transform.localScale = new Vector3(0, 1, 1);
            log.GetComponent<BoxCollider2D>().enabled = true;
            log.Saw();
            log.transform.position = transform.position + Vector3.down;
            log = null;
        }
    }

    public void Insert(Log log) {
        log.GetComponent<BoxCollider2D>().enabled = false;
        this.log = log;
        log.transform.position = transform.position;
    }

    public bool IsCrafting() {
        return log;
    }
}
