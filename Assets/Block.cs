using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad/40f;
    }
}
