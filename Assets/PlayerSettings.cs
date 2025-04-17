using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour {
    private float speed  = 15f;
    public float Minspeed = 15f;
    public float Maxspeed = 30f;
    public float JumpForce = 2f;
    public bool IsGrounded;
    private Rigidbody rb;

      // CÁMARA
    public float Sensibility = 2f;
    public float LimitX = 45;
    public Transform cam;
    private float rotationX;
    private float rotationY;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
      rb = GetComponent<Rigidbody>();
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update() {
 //CÁMARA

      rotationX += -Input.GetAxis("Mouse Y") * Sensibility;
      rotationX = Mathf.Clamp(rotationX, -LimitX, LimitX);
      cam.localRotation = Quaternion.Euler(rotationX, 0, 0);
      transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * Sensibility, 0);

     //MOVIMIENTO

      float x = Input.GetAxis("Horizontal");
      float y = Input.GetAxis("Vertical");

      if (Input.GetKey(KeyCode.LeftShift)) {
         speed = Maxspeed;
      } else {
         speed = Minspeed;
      }
      
      if(Input.GetKeyDown(KeyCode.Space)) {
         Jump();
         transform.Translate(new Vector3(x, 0, y) * Time.deltaTime * speed);
      }
   }

   public void Jump() {
      if (IsGrounded == true){
         rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
      }
   }       

   public void OnCollisionEnter(Collision collision) {
      if (collision.gameObject.tag == "Ground") {
         IsGrounded = true;
      }
   }

   public void OnCollisionExit(Collision collision) {
      if (collision.gameObject.tag == "Ground") {
         IsGrounded = false;
      } 
   }
}

   
   



 