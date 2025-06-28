using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToPlanetTrigger : MonoBehaviour
{
    public Canvas goToPlanetCanvas;     
    public string planetSceneName = "ExplorableEarthScene";  
    public float activationDistance = 200f;

    private Transform player;

    void Start()
    {
        player = Camera.main.transform;  
        if (goToPlanetCanvas != null)
            goToPlanetCanvas.enabled = false;
    }

    void Update()
    {
        if (player == null || goToPlanetCanvas == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= activationDistance)
        {
            goToPlanetCanvas.enabled = true;
        }
        else
        {
            goToPlanetCanvas.enabled = false;
        }
    }

    
    public void GoToPlanet()
    {
        SceneManager.LoadScene(planetSceneName);
    }
}
