using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public int SceneIndexDestination = 0;
    public void OnPointerClick(PointerEventData e)
    {
        //get current scene
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Current scene name = " + scene.name);

        //load new scene
        SceneManager.LoadScene(SceneIndexDestination);
    }
}
