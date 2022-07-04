using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 0.02f;
    public float deadLine = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;
        pos.z -= speed;
        transform.position = pos;

        if(transform.position.z <= deadLine)
        {
            Destroy(gameObject);
        }
    }
}
