using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : Crafting {

    [SerializeField] GameObject log;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public override void Action() {
        currentProgress.transform.localScale += Vector3.right * 0.25f;
        if (currentProgress.transform.localScale.x == 1) {
            currentProgress.transform.localScale = new Vector3(0, 1, 1);
            Instantiate(log, transform.position + Vector3.down * 2, Quaternion.identity);
        }
    }
}
