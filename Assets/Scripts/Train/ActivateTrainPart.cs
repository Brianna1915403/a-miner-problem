using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateTrainPart : MonoBehaviour
{
    public GameObject roof;
    public GameObject wheels;
    public GameObject engineCar;
    public GameObject connectingRods;
    public GameObject wheelsupport;
    public GameObject chimney;
    public GameObject tracks;
    public GameObject screws;
    public GameObject blueprint_roof;
    public GameObject blueprint_wheels;
    public GameObject blueprint_engineCar;
    public GameObject blueprint_connectingRods;
    public GameObject blueprint_wheelsupport;
    public GameObject blueprint_chimney;
    public GameObject blueprint_tracks;
    public GameObject blueprint_screws;
    public GameObject ui;
    public void activate(GameObject trainPart)
    {
        trainPart.SetActive(true);
    }

    public void deactivate(GameObject trainPart)
    {
        trainPart.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (roof.activeSelf && wheels.activeSelf && engineCar.activeSelf && connectingRods.activeSelf && wheelsupport.activeSelf && chimney.activeSelf && tracks.activeSelf && screws.activeSelf)
        {
            if (other.tag == "Player")
            {
                ui.SetActive(true);
                if (Input.GetKeyDown(KeyCode.X))
                {
                    SceneManager.LoadScene("EndScene");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
}
