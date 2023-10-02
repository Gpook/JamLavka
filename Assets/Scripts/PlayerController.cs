using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerAnimController playerAnimController;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject losePanel;
    
    [SerializeField] private Vector3 direction;
    [SerializeField] private Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeedMouse;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isCursorVisible;


    public void Start()
    {
        playerAnimController.AnimRun();
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
     public void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             playerAnimController.AnimRun();
         }
         if (collision.gameObject.CompareTag("Obstacle"))
         {
             
             losePanel.SetActive(true);
             UnlockCursor();
             direction.z = 0;
             playerAnimController.AnimDie();
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
     public void OnCollisionStay(Collision collision)
     {
         if (collision.gameObject.CompareTag("Ground"))
         {
             isGrounded = true;
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
            playerAnimController.AnimJump();
        }
        transform.Translate(direction * Time.deltaTime);
        
     } 
}
