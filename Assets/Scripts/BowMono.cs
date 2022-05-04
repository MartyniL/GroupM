using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMono : MonoBehaviour
{

    public Bow bow;
    public Transform stringTop, stringBottom, drawPoint, gunTip;
    float drawStren;
    LineRenderer lr;
    Vector3 initDrawPos, drawPos;
    public GameObject arrow;
    // Start is called before the first frame update
    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        initDrawPos = drawPoint.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        drawStren = bow.drawstrength;
        drawPos = new Vector3(drawStren*2, initDrawPos.y, initDrawPos.z);
        drawPoint.localPosition = drawPos;
        UpdateString();
        arrow = bow.arrow;
        if(arrow != null)
        {
            arrow.transform.localPosition = new Vector3(drawStren * 2 + gunTip.localPosition.x, 0f, 0f);
        }

    }

    void UpdateString()
    {
        lr.SetPosition(0, stringTop.position);
        lr.SetPosition(1, drawPoint.position);
        lr.SetPosition(2, stringBottom.position);
    }
}
