public class Ship {
    private string name;
    private int shotDamage;
    private int rateOfFire;
    private int healthPoints;
    private int maneuverabilty;
    private int damage;

    public Ship(string name, int shotDamage, int rateOfFire, int healthPoints, int maneuverabilty)
    {
        this.name = name;
        this.shotDamage = shotDamage;
        this.rateOfFire = rateOfFire;
        this.healthPoints = healthPoints;
        this.maneuverabilty = maneuverabilty;
        this.damage = 0;
    }

    public string getName()
    {
        return this.name;
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