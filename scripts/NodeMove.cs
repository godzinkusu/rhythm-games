using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        this.transform.position+= new Vector3(0, 0, speed * -10 * Time.deltaTime);
        if (this.transform.position.z < -11f)
        {
            Destroy(this.gameObject);
            //i.transform.position = Vector3.Lerp(v_start, v_destination, v);//vは0～1変わり、0の時,startにいて、徐々にdestinationに近づく
        }
    }
}
