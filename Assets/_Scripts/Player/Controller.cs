using UnityEngine;
using UnityEditor;


/// <summary>
/// This class controls player movement
/// </summary>
public class Controller : MonoBehaviour
{
    [Header("GameObject/Component References")]
    [Tooltip("The animator controller used to animate the player.")]
    public RuntimeAnimatorController animator = null;
    [Tooltip("The Rigidbody2D component to use in \"Astroids Mode\".")]
    public Rigidbody2D myRigidbody = null;

    [Header("Movement Variables")]
    [Tooltip("The speed at which the player will move.")]
    public float moveSpeed = 10.0f;
    [Tooltip("The speed at which the player rotates in asteroids movement mode")]
    public float rotationSpeed = 60f;

    [Tooltip("The aim mode in use by this player:\n" +
        "Aim Towards Mouse: Player rotates to face the mouse\n" +
        "Aim Forwards: Player aims the direction they face (doesn't face towards the mouse)")]
    public AimModes aimMode = AimModes.AimTowardsMouse;

    [Tooltip("The movmeent mode used by this controller:\n" +
        "Move Horizontally: Player can only move left/right\n" +
        "Move Vertically: Player can only move up/down\n" +
        "FreeRoam: Player can move in any direction and can aim\n" +
        "Astroids: Player moves forward/back in the direction they are facing and rotates with horizontal input")]
    public MovementModes movementMode = MovementModes.FreeRoam;  

    [Tooltip("The mode for MoveToward mode:\n" +
        "HorizontallyMove: Lock and utomatucaly move in Y axis.\n" +
        "VericallyMove: Lock and utomatucaly move in X axis.")]
    public TowardMovementModes towardMovementMode = TowardMovementModes.HorizontallyMove;

    [Tooltip("Change X value to which way move to x axis and what speed.\n" +
        "Change Y value to which way move to y axis and what speed.")]
    public Vector3 axisDirection = Vector3.zero;

    //The InputManager to read input from
    private InputManager inputManager;


    // Whether the player can aim with the mouse or not
    private bool canAimWithMouse { get { return aimMode == AimModes.AimTowardsMouse; } }

    // Whether the player's X coordinate is locked (Also assign in rigidbody)
    private bool lockXCoordinate { get { return movementMode == MovementModes.MoveVertically; } }
    
    // Whether the player's Y coordinate is locked (Also assign in rigidbody)
    public bool lockYCoordinate { get { return movementMode == MovementModes.MoveHorizontally; } }

    // Whether the player move in X cordinate.  (Also assign in rigidbody)
    private bool moveToXCordinate { get { return towardMovementMode == TowardMovementModes.HorizontallyMove; } }

    // Whether the player move in Y cordinate.  (Also assign in rigidbody)
    private bool moveToYCordinate { get { return towardMovementMode == TowardMovementModes.VerticallyMove; } }

    private void Start()
    {
        SetupInput();
    }

    private void Update()
    {
        // Collect input and move the player accordingly
        HandleInput();
        // Sends information to an animator component if one is assigned
        SignalAnimator();
    }

    /// <summary>
    /// Description:
    /// Sets up the input manager if it is not already set up. Throws an error if none exists
    /// Inputs:
    /// None
    /// Returns:
    /// void
    /// </summary>
    private void SetupInput()
    {
        if (inputManager == null)
        {
            inputManager = FindObjectOfType<InputManager>();
        }
        if (inputManager == null)
        {
            Debug.LogWarning("There is no player input manager in the scene, there needs to be one for the Controller to work");
        }
    }

    /// <summary>
    /// Description:
    /// Handles input and moves the player accordingly
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void HandleInput()
    {
        // Find the position that the player should look at
        Vector2 lookPosition = GetLookPosition();
        // Get movement input from the inputManager
        Vector3 movementVector = new Vector3(inputManager.horizontalMoveAxis, inputManager.verticalMoveAxis, 0);
        // Move the player
        MovePlayer(movementVector);
        LookAtPoint(lookPosition);
    }

    /// <summary>
    /// Description: 
    /// Handles signals to animator components
    /// Inputs: 
    /// none
    /// Returns: 
    /// void (no return)
    /// </summary>
    private void SignalAnimator()
    {
        // Handle Animation
        if (animator != null)
        {

        }
    }

    /// <summary>
    /// Description:
    /// Updates the position the player is looking at
    /// Inputs: 
    /// none
    /// Returns: 
    /// Vector2
    /// </summary>
    /// <returns>Vector2: The position the player should look at</returns>
    public Vector2 GetLookPosition()
    {
        Vector2 result = transform.up;
        if (aimMode != AimModes.AimForwards)
        {
            result = new Vector2(inputManager.horizontalLookAxis, inputManager.verticalLookAxis);
        }
        else
        {
            result = transform.up;
        }
        return result;
    }

    /// <summary>
    /// Description: 
    /// Rotates the player to look at a point
    /// Inputs: 
    /// Vector3 point
    /// Returns: 
    /// void (no return)
    /// </summary>
    /// <param name="point">The screen space position to look at</param>
    private void LookAtPoint(Vector3 point)
    {
        if (Time.timeScale > 0)
        {
            // Rotate the player to look at the mouse.
            Vector2 lookDirection = Camera.main.ScreenToWorldPoint(point) - transform.position;

            if (canAimWithMouse)
            {
                transform.up = lookDirection;
            }
            else
            {
                if (myRigidbody != null)
                {
                    myRigidbody.freezeRotation = true;
                }
            }
        }
    }

    /// <summary>
    /// Description:
    /// Moves the player
    /// Inputs: 
    /// Vector3 movement
    /// Returns: 
    /// void (no return)
    /// </summary>
    /// <param name="movement">The direction to move the player</param>
    private void MovePlayer(Vector3 movement)
    {
        // Set the player's posiiton accordingly

        // Move according to astroids setting
        if (movementMode == MovementModes.Astroids)
        {

            // If no rigidbody is assigned, assign one
            if (myRigidbody == null)
            {
                myRigidbody = GetComponent<Rigidbody2D>();
            }

            // Move the player using physics
            Vector2 force = transform.up * movement.y * Time.deltaTime * moveSpeed;
            Debug.Log(force);
            myRigidbody.AddForce(force);

            // Rotate the player around the z axis
            Vector3 newRotationEulars = transform.rotation.eulerAngles;
            float zAxisRotation = transform.rotation.eulerAngles.z;
            float newZAxisRotation = zAxisRotation - rotationSpeed * movement.x * Time.deltaTime;
            newRotationEulars = new Vector3(newRotationEulars.x, newRotationEulars.y, newZAxisRotation);
            transform.rotation = Quaternion.Euler(newRotationEulars);

        }
        // Move self in X or Y cordinate
        else if (movementMode == MovementModes.MoveToward)
        {
            // Move automatically in the X  axis
            if (moveToXCordinate)
            {
                movement.x = axisDirection.x;
            }
            // Move automatically in the Y axis
            if (moveToYCordinate)
            {
                movement.y = axisDirection.y;
            }

            transform.position = transform.position + (new Vector3(movement.x, movement.y, 0) * Time.deltaTime * moveSpeed);
        }
        // Move according to the other settings
        else
        {
            // Don't move in the X axis if the settings stop us from doing so
            if (lockXCoordinate)
            {
                movement.x = 0;
            }
            // Don't move in the Y axis if the settings stop us from doing so
            if (lockYCoordinate)
            {
                movement.y = 0;
            }
           
            transform.position = transform.position + (movement * Time.deltaTime * moveSpeed);
        }
    }
}


#region CUSTOM INSPECTOR
//Custom inspector.
#if UNITY_EDITOR
[CustomEditor(typeof(Controller))]
[CanEditMultipleObjects]
public class controllerEditor : Editor
{
    private SerializedProperty animator;
    private SerializedProperty myRg;

    private SerializedProperty moveSpeed;
    private SerializedProperty rotationSpeed;

    private SerializedProperty aimMode;
    private SerializedProperty movementMode;
    private SerializedProperty moveToward;

    private SerializedProperty axisDirection;

    private void OnEnable()
    {
        animator = serializedObject.FindProperty("animator");
        myRg = serializedObject.FindProperty("myRigidbody");

        moveSpeed = serializedObject.FindProperty("moveSpeed");
        rotationSpeed = serializedObject.FindProperty("rotationSpeed");

        aimMode = serializedObject.FindProperty("aimMode");
        movementMode = serializedObject.FindProperty("movementMode");
        moveToward = serializedObject.FindProperty("towardMovementMode");

        axisDirection = serializedObject.FindProperty("axisDirection");


    }
    public override void OnInspectorGUI()
    {
        DrawScriptField();

        serializedObject.Update();

        EditorGUILayout.PropertyField(animator);
        EditorGUILayout.PropertyField(myRg);

        EditorGUILayout.PropertyField(moveSpeed);
        EditorGUILayout.PropertyField(rotationSpeed);

        
        EditorGUILayout.PropertyField(aimMode);
        EditorGUILayout.PropertyField(movementMode);
        switch ((MovementModes)movementMode.enumValueIndex)
        {
            case MovementModes.MoveToward:
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(moveToward);
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(axisDirection);
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    // Have the script field on top
    private void DrawScriptField()
    {
        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((Controller)target), typeof(Controller), false);
        EditorGUILayout.Space();
        EditorGUI.EndDisabledGroup();
    }
}
#endif
#endregion CUSTOM INSPECTOR