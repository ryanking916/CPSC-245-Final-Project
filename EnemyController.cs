using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum GhostNodeStatesEnum
    {
        respawning,
        leftNode,
        rightNode,
        centerNode,
        startNode,
        movingInNodes,
    }

    public GhostNodeStatesEnum ghostNodeState;
    
    public MovementController movementController;

    public GameManager gameManager;
    
    public GameObject ghostNodeLeft;
    public GameObject ghostNodeRight;
    public GameObject ghostNodeCenter;
    public GameObject ghostNodeStart;

    void Awake()
    {
        gameManger = GameObject.Find("GameManager").GetComponent<GameManager>();
        movementController = GetComponent<MovementController>();
        ghostNodeState = GhostNodeStatesEnum.startNode;
        movementController.currentNode = startingNode;
        transform.position = startingNode.transform.position;
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReachedCenterOfNode(NodeController nodeController)
    {
        if (ghostNodeState == GhostNodeStatesEnum.movingInNodes)
        {
            //Determine next game node to go to
            DetermineEnemyDirection();
        }
        else if (ghostNodeState == GhostNodeStatesEnum.respawning)
        {
            //Determine quickest direction to home
        }
    }

    void DetermineEnemyDirection()
    {
        string direction = GetClosestDirection(gameManager.player.transform.position);
    }

    string GetClosestDirection(Vector2 target)
    {
        float shortestDistance = 0;
        string lastMovingDirection = movementController.lastMovingDirection;

        NodeController nodeController = movementController.currentNode.GetComponent<NodeController>();
// if we can move up and we aren't reversing
        if (nodeController.canMoveUp && lastMovingDirection != "down")
        {
            //get the node above us
            GaemObject nodeUp = nodeController.nodeUp;
            //Get the distance our top node, and player
            float distance = Vector2.Distance(nodeUp.transform.position, target);

            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "up";
            }
        }
        
        if (nodeController.canMoveDown && lastMovingDirection != "up")
        {
            //get the node above us
            GaemObject nodeDown = nodeController.nodeUp;
            //Get the distance our top node, and player
            float distance = Vector2.Distance(nodeDown.transform.position, target);

            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "down";
            }
        }

        if (nodeController.canMoveLeft && lastMovingDirection != "up")
        {
            //get the node above us
            GaemObject nodeLeft = nodeController.nodeLeft;
            //Get the distance our top node, and player
            float distance = Vector2.Distance(nodeLeft.transform.position, target);

            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "left";
            }

            if (nodeController.canMoveRight && lastMovingDirection != "up")
            {
                //get the node above us
                GaemObject nodeRight = nodeController.nodeRight;
                //Get the distance our top node, and player
                float distance = Vector2.Distance(nodeRight.transform.position, target);

                if (distance < shortestDistance || shortestDistance == 0)
                {
                    shortestDistance = distance;
                    newDirection = "right";
                }
            }
        }
    }

    void DetermineEnemyDirection()
    //GAMEMANAGER MUST HAVE A PLAYER GAMEOBJECT REFERENCE
    {
        string direction = GetClosestDirection(gameManager.player.transform.position);
        movementController.SetDirection(direction);
    }

    void GetClosestDirection(Vector2 target)
    {
        float shortestDistance = 0;
        string lastMovingDirection = movementController.lastMovingDirection;
        string newDirection = "";

        NodeController nodeController = movementController.currentNode.GetComponent<NodeController>();
        
        if (nodeController.canMoveUp && lastMovingDirection != "down")
        {
            GameObject nodeUp = nodeController.nodeUp;
            //Get the distance between our top node and player
            float distance = Vector2.Distance(nodeUp.transform.position, target);

            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "up";
            }
        }
        
        if (nodeController.canMoveUp && lastMovingDirection != "up")
        {
            GameObject nodeDown = nodeController.nodeDown;
            //Get the distance between our top node and player
            float distance = Vector2.Distance(nodeDown.transform.position, target);

            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "down";
            }
        }
        
        if (nodeController.canMoveLeft && lastMovingDirection != "right")
        {
            GameObject nodeLeft = nodeController.nodeLeft;
            //Get the distance between our top node and player
            float distance = Vector2.Distance(nodeLeft.transform.position, target);

            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "left";
            }
        }
        
        if (nodeController.canMoveRight && lastMovingDirection != "left")
        {
            GameObject nodeRight = nodeController.nodeRight;
            //Get the distance between our top node and player
            float distance = Vector2.Distance(nodeRight.transform.position, target);

            //if this is the shortest distance so far, set our direction
            if (distance < shortestDistance || shortestDistance == 0)
            {
                shortestDistance = distance;
                newDirection = "right";
            }
        }

        return newDirection;
    }
}
       
