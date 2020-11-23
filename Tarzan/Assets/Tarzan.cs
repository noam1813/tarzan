using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tarzan : MonoBehaviour
{
    private Vector2 mousePosition;
    private Vector3 Speed;
    [SerializeField] private Vector2 SpeedAccel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var pos = transform.position;
        
        //Xziku
        if (pos.x >= mousePosition.x)
        {
            Speed.x -= SpeedAccel.x * Time.deltaTime;
        }
        else
        {
            Speed.x += SpeedAccel.x * Time.deltaTime;
        }
        
        //Yziku
        if (pos.y >= mousePosition.y)
        {
            Speed.y -= SpeedAccel.y * Time.deltaTime;
        }
        else
        {
            Speed.y += SpeedAccel.y * Time.deltaTime;
        }

        transform.position += Speed * Time.deltaTime;
    }
}
