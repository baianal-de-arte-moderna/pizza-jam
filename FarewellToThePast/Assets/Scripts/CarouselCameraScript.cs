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
        var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
        ChangeShipInformation(SelectedShipInfo);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(Vector3.up);
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 30f);
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) ) {
            carousel.rotateTheCarouselRight();
            var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
            ChangeShipInformation(SelectedShipInfo);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) ) {
            carousel.rotateTheCarouselLeft();
            var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
            ChangeShipInformation(SelectedShipInfo);
        }
    }

    void ChangeShipInformation(Ship ship) {
        ShipName.text = ship.getShipName();   
        var stats = "";
        for (var i = 0; i < ship.getShotDamage() / 2; i++)
            stats += "O" ;
        stats += '\n';
        for (var i = 0; i < ship.getRateOfFire() / 2; i++)
            stats += "O" ;
        stats += '\n';
        for (var i = 0; i < ship.getHealthPoints() / 2; i++)
            stats += "O" ;
        stats += '\n';
        for (var i = 0; i < ship.getManeuverability() / 2; i++)
            stats += "O" ;
        ShipStats.text = stats;
    }
}
