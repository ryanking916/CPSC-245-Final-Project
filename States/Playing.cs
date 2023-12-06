using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class Playing : BaseState
    {
        public override void OnStateEnter(GameObject forGameObject)
        {
            forGameObject.GetComponent<Level>().CharacterManager.ResumeCharacters();
        }

        public override Type Update(GameObject forGameObject)
        {
            return GetType();
        }
    }
}