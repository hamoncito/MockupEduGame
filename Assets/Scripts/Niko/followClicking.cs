﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followClicking : MonoBehaviour
{
    public static int scenarioNumber = 0;


    private void Awake()
    {
        scenarioNumber = Random.Range(0, 4);
    }

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 10f);

            if (didHit)
            {
                bubbleDestroy destScript = rhInfo.collider.GetComponent<bubbleDestroy>();

                // Scenario control
                if (destScript)
                {
                    if (scenarioNumber == 0)
                    {
                        destScript.RemoveMeScenario0();
                    }
                    else if (scenarioNumber == 1)
                    {
                        destScript.RemoveMeScenario1();
                    }
                    else if (scenarioNumber == 2)
                    {
                        destScript.RemoveMeScenario2();
                    }
                    else if (scenarioNumber == 3)
                        destScript.RemoveMeScenario3();
                    else
                    {
                        Debug.Log("No scenario has been loaded");
                    }
                }
            }

        }
    }

    public void changeScenario()
    {
        scenarioNumber++;
        Debug.Log("Scenario changed");
        Debug.Log("Number of scenario: " + scenarioNumber);
    }

    public int getScenarioNumber()
    {
        return scenarioNumber;
    }

    public void setBaseScenario()
    {
        scenarioNumber = 0;
    }
}
