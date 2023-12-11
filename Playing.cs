using UnityEngine;

public class Playing : MonoBehaviour
{
    private ChapManGame chapManGame;

    // Track the total number of pellets in the level
    private int totalPelletCount;

    // Track the remaining number of pellets
    private int remainingPelletCount;

    public float speed = 5f;
    public float levelTimer = 120f;

    private void Start()
    {
        // Assuming this script is attached to a GameObject in the scene
        chapManGame = new ChapManGame();
        chapManGame.ChangeState(ChapManState.Playing); // Initialize state to Playing

        totalPelletCount = GameObject.FindGameObjectsWithTag("Pellet").Length;
        remainingPelletCount = totalPelletCount;

    }

    public void PelletEaten()
    {
        // Decrease the remaining pellet count
        remainingPelletCount--;

        // Check if all pellets are eaten
        if (remainingPelletCount == 0)
        {
            // Trigger transition to the win state
            chapManGame.ChangeState(ChapManState.Win);
        }

        void Update()
        {
            // Read input from the player
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector2 movement = new Vector2(horizontalInput, verticalInput);

            // Normalize the movement vector to ensure consistent speed in all directions
            movement.Normalize();

            // Move the Pac-Man GameObject
            MovePacMan(movement);

            // Check for conditions to transition to other states
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Pause the game if the Escape key is pressed
                chapManGame.ChangeState(ChapManState.Pause);
            }


            // Add other gameplay logic here
        }

        void MovePacMan(Vector2 direction)
        {
            // Get the Rigidbody2D component attached to the GameObject
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            // Move the GameObject using the Rigidbody2D component
            rb.velocity = direction * speed;
        }
        
        // Check conditions for handling the loss state
        if (levelTimer <= 0f)
            {
                HandleLossCondition();
            }
        
        void HandleLossCondition()
        {
            // Additional logic for handling the loss condition
            Debug.Log("Handling loss condition...");

            // You can add more logic here, such as showing a specific animation, playing a sound, etc.

            // Transition to the Loss state
            chapManGame.ChangeState(ChapManState.Loss);
        }
        }
    }

