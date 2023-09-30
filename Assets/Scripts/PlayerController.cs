using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeedMouse;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isCursorVisible;


     public void Start()
    {
        rb = GetComponent<Rigidbody>();
        LockCursor();
    }
     private void LockCursor()
     {
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
         isCursorVisible = false;
     }
     private void UnlockCursor()
     {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
         isCursorVisible = true;
     }
     public void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             isGrounded = true;
         }
         if (collision.gameObject.CompareTag("Obstacle"))
         {
             sceneController.StartSceneTime();
         }
     }
     public void OnCollisionExit(Collision collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             isGrounded = false;
         }
     }
    
    public void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }
        if (Input.GetMouseButtonDown(0))
        {
            LockCursor();
        }
        if (!isCursorVisible)
        {
            float mouseX = Input.GetAxis("Mouse X");
            Vector3 moveDirection = new Vector3(mouseX, 0f, 0f);
            moveDirection.Normalize();
            transform.Translate(moveDirection * (moveSpeedMouse * Time.deltaTime));
        }
        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
        
        transform.Translate(direction);
    }

    
}
