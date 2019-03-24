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

    public Text Player1;
    public Text Player2;

    public bool player1Chose;
    // Start is called before the first frame update
    void Start()
    {
        var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
        ChangeShipInformation(SelectedShipInfo);
        player1Chose = false;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return) ) {
            var SelectedShipInfo = carousel.carouselObjects[carousel.ChosenObject].GetComponent<Ship>();
            if (!player1Chose) {
                StaticGameData.Player1ShipIndex = carousel.ChosenObject;
                Player1.color = Color.grey;
                Player2.color = Color.white;
                player1Chose = true;
            } else {
                StaticGameData.Player2ShipIndex = carousel.ChosenObject;
                SceneManager.LoadScene("ConfigurableSplitScreen");
            }
            
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
