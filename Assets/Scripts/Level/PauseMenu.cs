 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class PauseMenu : MonoBehaviour {
 
     bool pauseMenu;
	 CanvasGroup pause;

	 public AudioClip Pause;

	 void Start()
	 {
		 pause = GetComponent<CanvasGroup>();
		 pauseMenu = false;
		 pause.alpha = 0;
	 }
         
     // Update is called once per frame
     void Update () 
	 {


         if (Input.GetKeyDown ("p") && !pauseMenu) {    
                 
				 pauseMenu = true;
                 Time.timeScale = 0;
				 pause.alpha = 1;

				 Sound_Manager.instance.PlaySingleSound(Pause);
           		 Sound_Manager.instance.PauseBackGroundMusic();
             } 
			 else if (Input.GetKeyDown ("p") && pauseMenu)
             {	
				 pauseMenu = false;  
                 Time.timeScale = 1;
				 pause.alpha = 0;

				 Sound_Manager.instance.PlaySingleSound(Pause);
           		 Sound_Manager.instance.UnPauseBackGorundMusic();
             }
         } 
 }
