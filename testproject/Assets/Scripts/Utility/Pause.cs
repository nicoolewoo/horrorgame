// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Pause : MonoBehaviour
// {
//     private bool isPaused = false;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//          if (Input.GetKeyDown(KeyCode.P))
//         {
//             if (isPaused)
//             {
//                 UnpauseGame();
//             }
//             else
//             {
//                 PauseGame();
//             }
//         }
//     }
//     private void PauseGame()
//     {
//         Time.timeScale = 0f;
//         isPaused = true;
//     }
//     private void UnpauseGame()
//     {
//         Time.timeScale = 1f; 
//         isPaused = false;
//     }
// }
