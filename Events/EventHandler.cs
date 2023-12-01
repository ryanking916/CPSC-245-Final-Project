using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
   public delegate void GameHandler();
   
   public static event GameHandler OnGameStart;
   public static event GameHandler OnGamePause;
   public static event GameHandler OnGameEnd;

   public static bool GameIsPaused = false;

   public static void TriggerGameStart()
   {
      OnGameStart?.Invoke();
   }

   public static void TriggerGamePause()
   {
      GameIsPaused = !GameIsPaused;
      
      OnGamePause?.Invoke();
   }

   public static void TriggerGameEnd()
   {
      OnGameEnd?.Invoke();
   }
}
