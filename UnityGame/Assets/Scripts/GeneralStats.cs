using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralStats : MonoBehaviour
{
    [Header("General Stats")]

    private int m_health;
    private float m_Attack, m_Defense, m_Speed;
    public enum teamColour { red, blue }
    private teamColour m_teamColour;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //Generic Getters
    public teamColour GetTeamColour()
    {
        return m_teamColour;
    }
    public float GetDefense()
    {
        return m_Defense;
    }
    public int GetHealth()
    {
        return m_health;
    }
}
