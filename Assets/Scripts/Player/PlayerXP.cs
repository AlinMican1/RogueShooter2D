using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public int currentXP;
    public int minXP = 0;
    public int maxXP = 100;
    PauseController pause;
    public PauseController PauseGame;

    bool levelUp = false;
    public XPBar xpbar;
    // Start is called before the first frame update

    private void Awake()
    {
        pause = GameObject.FindObjectOfType<PauseController>();
    }
    void Start()
    {
        currentXP = minXP;
        xpbar.SetMinExperience(minXP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            IncreaseXp(5);
        }
        
    }

    public void IncreaseXp(int Xp)
    {
        if(currentXP == maxXP)
        {
            levelUp = true;
            displayMenu(levelUp);
            currentXP = 0;
        }
        else if(currentXP + Xp >= maxXP)
        {
            levelUp = true;
            displayMenu(levelUp);
            currentXP = 0;
        }
        else
        {
            currentXP += Xp;
        }
        
        xpbar.SetXP(currentXP);
    }

    public void displayMenu(bool leveledUp)
    {
        if (leveledUp)
        {
            pause.PauseGame();
        }

    }

    //Check if we pick up experience;
    public bool pickUpXp()
    {
        return true; 
    }
}
