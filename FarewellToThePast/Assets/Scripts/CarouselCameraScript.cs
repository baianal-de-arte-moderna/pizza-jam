using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarouselCameraScript : MonoBehaviour
{
    public CreateCarousel carousel;
    public Text ShipName;
    public Text ShipStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.up);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 30f);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ) {
            carousel.rotateTheCarouselRight();
            var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
            ShipName.text = SelectedShipInfo.getShipName();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ) {
            carousel.rotateTheCarouselLeft();   
        }
    }
}
