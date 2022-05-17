using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longNodeMove : MonoBehaviour
{
    public float speed = 2;
    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 0, speed * -10 * Time.deltaTime);

        if(this.transform.GetChild(2).transform.position.z < -11)
        {
            Destroy(this.gameObject);
        }

        if (!this.transform.GetChild(2))
        {
            Destroy(this.gameObject);
        }
    }
}
