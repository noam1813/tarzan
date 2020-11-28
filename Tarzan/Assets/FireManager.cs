using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireManager : MonoBehaviour
{
    public static FireManager instance;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private float interval;

    [SerializeField] private Vector2 LeftTopPos;
    [SerializeField] private Vector2 RightBottomPos;

    private IDisposable spawnObservable;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        spawnObservable = Observable.Interval(TimeSpan.FromSeconds(interval)).Subscribe(_ =>
        {
            Spawn();   
        }).AddTo(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Spawn()
    {
        var mode = Random.Range(0, 4);
        var mode2 = -1+Random.Range(0, 2)*2;
        var percent = Random.Range(0f, 1f);
        Vector3 pos = Vector3.zero;

        float posx;
        float posy;
        switch (1)
        {
            //上
            case 0:
                posx = RightBottomPos.x * mode2 - RightBottomPos.x * 2 * mode2 * percent;
                posx = Mathf.RoundToInt(posx);
                pos = new Vector3(posx,LeftTopPos.y);
                break;
            //下
            case 1:
                posx = RightBottomPos.x * mode2 - RightBottomPos.x * 2 * mode2 * percent;
                posx = Mathf.RoundToInt(posx);
                pos = new Vector3(posx,RightBottomPos.y);
                break;
            //左
            case 2:
                posy = RightBottomPos.y * mode2 - RightBottomPos.y * 2 * mode2 * percent;
                posy = Mathf.RoundToInt(posy);
                pos = new Vector3(LeftTopPos.x,posy);
                break;
            //右
            case 3:
                posy = RightBottomPos.y * mode2 - RightBottomPos.y * 2 * mode2 * percent;
                posy = Mathf.RoundToInt(posy);
                pos = new Vector3(RightBottomPos.x,posy);
                break;
        }

        var obj = Instantiate(firePrefab);
        obj.transform.position = pos;
        Debug.Log("OK");
    }
}
