using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 moveSpeedMinMax = new Vector2(4f,8f);
    private Vector2 halfScreenSize;
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Mathf.Lerp(moveSpeedMinMax.x,moveSpeedMinMax.y,Difficulty.GetDifficultyPercentage());
        halfScreenSize = new Vector2(Camera.main.orthographicSize*Camera.main.aspect,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*Time.deltaTime*moveSpeed);
        if(transform.position.y+transform.localScale.y<-halfScreenSize.y){
            Destroy(gameObject);
        }
    }
}
