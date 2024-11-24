using UnityEngine;

public class CharacterProfile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5;
    private Rigidbody2D rb;
    public float jump;
    private bool isJumping;
    void Start()
    {
      rb = GetComponent<Rigidbody2D> ();
      isJumping = false;
      rb.freezeRotation = true;
    }

    // collisions
     private void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log(collision.gameObject.name);
      if(collision.gameObject.tag == ("Ground")){
        isJumping = false;
      }
    }


    // Update is called once per frame
    void Update()
    {
      float xinput = Input.GetAxis("Horizontal");
      float yinput = Input.GetAxis("Vertical");

      if (Mathf.Abs(xinput) > 0){
        rb.linearVelocity = new Vector2(xinput * speed, rb.linearVelocity.y);
      }
      
      if(Input.GetButtonDown("Jump")){
        if(!isJumping){
        isJumping = true;
        rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
        }
      }

    }

}
