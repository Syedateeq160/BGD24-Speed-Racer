using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************
 * _______   BASICS OF GAME DEVELOPMENT   _______
 * _______ COMBINED Scripts for Assignment 4.1 & 4.2 _______
 * ________ ATEEQ _____________
 ***********************************************/

public class CombinedAssignment : MonoBehaviour
{
    // Declared and initialized the car's information
    public string carMaker;
    public string carModel = "GTR R35";
    public string engineType = "V6, Twin Turbo";

    public int carWeight = 1609;
    public int yearMade = 2009;

    public float maxAcceleration = 0.98f;

    public bool isCarTypeSedan = false;
    public bool hasFrontEngine = true;

    // Created a subclass to handle the fuel information
    public class Fuel
    {
        public int fuelLevel;

        public Fuel(int amount)
        {
            fuelLevel = amount;
        }
    }

    // Fuel instance for tracking car fuel
    public Fuel carFuel = new Fuel(100);

    // Start is called before the first frame update
    void Start()
    {
        // Assignment 4.1: Print car details
        print("The racer model is " + carModel + " by " + carMaker + ". It has a " + engineType + " engine.");
        CheckWeight();

        if (yearMade <= 2009)
        {
            print("It was first introduced in " + yearMade);
            int carAge = CalculateAge(yearMade);
            print("That makes it " + carAge + " years old.");
        }
        else
        {
            print("It was introduced in the 2010's");
            print("And its maximum acceleration is " + maxAcceleration + " m/s2");
        }

        print(CheckCharacteristics());
    }

    // Update is called once per frame
    void Update()
    {
        // Assignment 4.2: Fuel management on space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConsumeFuel();
            CheckFuelLevel();
        }
    }

    // Assignment 4.1: Check car weight
    void CheckWeight()
    {
        if (carWeight < 1500)
        {
            print("The " + carModel + " weighs less than 1500 kg.");
        }
        else
        {
            print("The " + carModel + " weighs over 1500 kg.");
        }
    }

    // Assignment 4.1: Calculate car age
    int CalculateAge(int yearMade)
    {
        return 2023 - yearMade;
    }

    // Assignment 4.1: Check car characteristics
    string CheckCharacteristics()
    {
        if (isCarTypeSedan)
        {
            return "The car is a sedan type.";
        }
        else if (hasFrontEngine)
        {
            return "The car is not a sedan, but has a front engine.";
        }
        else
        {
            return "The car is neither a sedan, nor is its engine a front engine.";
        }
    }

    // Assignment 4.2: Consume fuel
    void ConsumeFuel()
    {
        carFuel.fuelLevel = Mathf.Max(0, carFuel.fuelLevel - 10);
    }

    // Assignment 4.2: Check fuel level
    void CheckFuelLevel()
    {
        switch (carFuel.fuelLevel)
        {
            case 70:
                print("Fuel level is nearing two-thirds.");
                break;
            case 50:
                print("Fuel level is at half amount.");
                break;
            case 10:
                print("Warning! Fuel level is critically low.");
                break;
            default:
                print("Nothing to report.");
                break;
        }
    }
}
