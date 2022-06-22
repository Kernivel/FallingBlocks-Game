using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerMoveSpeed = 7;
    private Vector2 halfScreenSize;
    private float  halfPlayerWidth;
    public event System.Action OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        halfScreenSize = new Vector2(mainCamera.orthographicSize*mainCamera.aspect,mainCamera.orthographicSize);
        halfPlayerWidth = transform.localScale.x/2f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right*horizontalInput*playerMoveSpeed*Time.deltaTime);
        float screenWidth = halfScreenSize.x;
        
        if(transform.position.x>screenWidth+halfPlayerWidth){
            transform.position = new Vector2(-screenWidth,transform.position.y);
        }
        if(transform.position.x<-screenWidth-halfPlayerWidth){
            transform.position = new Vector2(screenWidth,transform.position.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
      Debug.Log("Collided");
      if(other.transform.tag == "FallingBlock"){
          Debug.Log("Call");
          if(OnPlayerDeath != null){
              OnPlayerDeath();
          }
          Destroy(gameObject);
      }
  }
  
}
