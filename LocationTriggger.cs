using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LocationTriggger : MonoBehaviour
{
    public GameObject ActualGame;

    private void OnTriggerStay2D(Collider2D collision)
    {
		if (collision.gameObject.tag == "Player" && Input.GetKey("space"))
		{
            Debug.Log("Hello it works");
            Debug.Log("On: " + this.gameObject.name);
            if(this.gameObject.name == "water minigame")
            {
                ActualGame.SetActive(true);
            }
            if (this.gameObject.name != "Location Button 0") {
                SceneManager.LoadScene(this.gameObject.name);
            }
            
		}
    }
}
