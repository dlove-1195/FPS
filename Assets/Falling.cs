using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0f, speed, 0f);
        if (transform.position.y < 0.05f)
            //Destroy(this);
            this.gameObject.SetActive(false);
    }
}
