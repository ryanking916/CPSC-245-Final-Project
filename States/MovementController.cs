using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class MovementController
    {
        public Gameobject currentNode;
        public float speed = 4f;
        
        public string direction = "";

        public string lastMovingDirection = "";

        void Start()
        {
            
        }

        void Update()
        {
            Nodecontroller currentnodecontroller = currentNode.GetComponent<NodeController>();
            
            transtorm.position = Vector2.MoveTowards(transform.position, currentNode.transtorm.position, speed * Time.deltatime);

            1t transtorm.position.x == currentNode.transtorm.position.x && transtorm.position.v == currentNode.transtorm.position.v)

        }
        
        
    }
}