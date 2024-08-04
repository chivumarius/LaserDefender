using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    // ▼ "Serializing" the "Fields" to be "Visible" in the "Inspector" ▼
    [SerializeField] float moveSpeed = 5f;
    
    // ▼ "Declaring" the "Fields" ▼
    Vector2 rawInput;



    // ▼ "Padding" the "Bounds" ▼
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    

    // ▼ "Storing Vector2" for the "Bottom Left" of the "Viewport" (0, 0) ▼
    Vector2 minBounds;
   
    // ▼ "Storing Vector2" for the "Top Right" of the "Viewport" (1, 1) ▼
    Vector2 maxBounds;


    // ▼ "Reference" to the "Shooter" Script ▼
    Shooter shooter;



    // ▬▬▬▬▬▬▬▬▬▬ "Awake()" Method ▬▬▬▬▬▬▬▬▬▬
    void Awake()
    {
        // ▼ "Getting" the "Shooter" Component ▼
        shooter = GetComponent<Shooter>();
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Start()" Method ▬▬▬▬▬▬▬▬▬▬
    void Start()
    {
        // ▼ "Calling" the "Method" ▼
        InitBounds();
    }




    // ▬▬▬▬▬▬▬▬▬▬ "Update()" Method ▬▬▬▬▬▬▬▬▬▬
    void Update()
    {
        // ▼ "Calling" the "Method" ▼
        Move();
    }



    // ▬▬▬▬▬▬▬▬▬▬ "Init Bounds()" Method ▬▬▬▬▬▬▬▬▬▬
    void InitBounds()
    {        
        // ▼ "Getting" the "Main Camera" ▼
        Camera mainCamera = Camera.main;
        
        // ▼ "Setting" the "Viewport To World Point" of the "Main Camera" 
        //      → for the "Bottom Left" of the "Viewport" (0, 0) ▼
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        
        // ▼ "Setting" the "Viewport To World Point" of the "Main Camera" 
        //      → for the "Top Right" of the "Viewport" (1, 1) ▼
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }





    // ▬▬▬▬▬▬▬▬▬▬ "Move()" Method ▬▬▬▬▬▬▬▬▬▬
    void Move()
    {
        // ▼ "Moving" the "Player" ▼
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        

        // ▼Initializing the "Vector2" for the "Position" 
        //      → to allow us to Edit the "X" & "Y" Components
        //      → of the "New Position" Vector2 ▼
        Vector2 newPos = new Vector2();
        
        // ▼ "Clamping" the "X Position" & "Y Position"
        //      → that "Restrict Any Values" 
        //      → that are "Outside" of the "Minimum Value" & "Maximum Value" 
        //      → that we "Set" ▼
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
         

        // ▼ "Setting" the "New Position" ▼
        transform.position = newPos;

    }




    // ▬▬▬▬▬▬▬▬▬▬ "On Move()" Method ▬▬▬▬▬▬▬▬▬▬
    void OnMove(InputValue value)
    {
        // ▼ "Getting" the "Vector2" Input Value ▼
        rawInput = value.Get<Vector2>();
    }



    // ▬▬▬▬▬▬▬▬▬▬ "On Fire()" Method ▬▬▬▬▬▬▬▬▬▬
    void OnFire(InputValue value)
    {
        // ▼ "Checking" if the "Shooter" Exists ▼
        if(shooter != null)
        {
            // ▼ "Setting" the "isFiring" Property to the "Keyboard" Input Value ▼
            shooter.isFiring = value.isPressed;
        }
    }

}
