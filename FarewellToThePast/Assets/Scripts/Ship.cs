using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private string shipName;
    [SerializeField]
    private int shotDamage;
    [SerializeField]
    private int rateOfFire;
    [SerializeField]
    private int healthPoints;
    [SerializeField]
    private int maneuverabilty;
    [SerializeField]
    private int damage;

    public Ship(string shipName, int shotDamage, int rateOfFire, int healthPoints, int maneuverabilty)
    {
        this.shipName = shipName;
        this.shotDamage = shotDamage;
        this.rateOfFire = rateOfFire;
        this.healthPoints = healthPoints;
        this.maneuverabilty = maneuverabilty;
        this.damage = 0;
    }

    public string getShipName()
    {
        return this.shipName;
    }

    public int getShotDamage()
    {
        return shotDamage;
    }

    public int getRateOfFire()
    {
        return rateOfFire;
    }

    public int getHealthPoints()
    {
        return this.healthPoints;
    }

    public int getManeuverability()
    {
        return this.maneuverabilty;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }

}