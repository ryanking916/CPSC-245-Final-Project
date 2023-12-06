
using GameStates;
using UnityEngine;
using UnityEngine.UI;

public class ChapmanState
{
    enum ChapManState
    {
        Idle,
        Moving,
        MainMenu,
        Pause,
        SetUp,
        Win,
        Loss
    }
    

    public GameObject currentNode;
    public float speed = 4f;

    public string direction = "";
    public string lastMovingDirection = "";

    class Program
    {
        private static ChapManState currentState = ChapManState.Idle;

        static void Main()
        {
            while (true)
            {
                Update();
                ChapMan();
            }
        }

        static void Update()
        {
            NodeController currentNodeController = currentNode.GetComponent<NodeController>();

            Transform.position = Vector2.MoveTowards(Transform.position, currentNodeController.transform.position,
                speed * Time.deltaTime);

            bool reversedirection = false;
            if (
                (direction == "left" && lastMovingDirection == "right")
                || (direction == "left" && lastMovingDirection == "right")
                || (direction == "left" && lastMovingDirection == "right")
                || (direction == "left" && lastMovingDirection == "right")
            )
            {
                reversedirection = true;
            }

                if ((Transform.position.x == currentNodeController.transform.position.x &&
                    Transform.position.y == currentNodeController.transform.position.y) || reversedirection)
            {
                GameObject newNode = currentNodeController.GetNodeFromDirection(direction);

                if (newNode != null)
                {
                    currentNode = newNode;
                    lastMovingDirection = direction;
                }
                else
                {
                    direction = lastMovingDirection;
                    newNode = currentNodeController.GetNodeFromDirection(direction);
                    if (newNode != null)
                    {
                        currentNode = newNode;
                    }
                }
            }

            public void SetDirection(string newDirection);
            
            switch (currentState)
            {
                case ChapManState.Idle:
                    HandleIdleState();
                    break;
                case ChapManState.Moving:
                    HandleMovingState();
                    break;
                case ChapManState.MainMenu:
                    HandleMainMenuState();
                    break;
                case ChapManState.Win:
                    HandleWinState();
                    break;
                case ChapManState.Loss:
                    HandleLossState();
                    break;
            }
            
            currentState = GetNextState(currentState);
        }

        static void HandleIdleState()
        {
            Console.WriteLine("Chap-Man is idle.");
        }

        static void HandleMovingState()
        {
            pelletsRemaining--;

            if (pelletsRemaining == 0)
            {
                currentState = ChapmanState.Win;
            }

            {
                Console.WriteLine("Chap-Man is moving.");

                MoveChapman(1, 1);

                if (chapmanX == ghostX && chapmanY == ghostY)
                {
                    currentState = ChapManState.Loss;
                }
            }
        }

        static void HandleWinState()
        {



        }
        
        static void HandleLossState()
        {



        }
        
        static void HandleMainMenuState()
        {



        }
        
        


        static void ChapMan()
        {
            Console.WriteLine($"Current State: {currentState}");
        }

        static ChapManState GetNextState(ChapManState currentState)
        {
            switch (currentState)
            {
                case ChapManState.Idle:
                    return ChapManState.Moving;
                case ChapManState.Moving:
                    return ChapManState.Idle;
                case ChapManState.Win:
                    return ChapManState.MainMenu;
                case ChapManState.Loss:
                    return ChapManState.MainMenu;
                case ChapManState.MainMenu:
                    return ChapManState.Idle;
                case ChapManState.Pause:
                    return ChapManState.Idle;
                case ChapManState.SetUp:
                    return ChapManState.Pause;
                
                default:
                    return ChapManState.Idle;
            }
        }
    }
}
