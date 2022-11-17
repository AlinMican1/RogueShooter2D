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
    LevelUpMenu levelUpMenu_Script;
    LevelUpMenu enableButton_script;
    
    // Start is called before the first frame update

    private void Awake()
    {
        pause = GameObject.FindObjectOfType<PauseController>();
        levelUpMenu_Script = GameObject.FindObjectOfType<LevelUpMenu>();
        enableButton_script = GameObject.FindObjectOfType<LevelUpMenu>();
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
            currentXP = 0;
            //Pause Game Once LevelUp
            pause.PauseGame();
            
        }
        else if(currentXP + Xp >= maxXP)
        {
            levelUp = true;
            currentXP = 0;
            //Pause Game Once LevelUp
            pause.PauseGame();
        }
        else
        {
            currentXP += Xp;
        }
        
        xpbar.SetXP(currentXP);
    }

    //Check LevelUp
    public bool LevelUp()
    {
 
        return levelUp;
        
    }
    //Check if we pick up experience;
    public bool pickUpXp()
    {
        return true; 
    }

    public void SetLevelUpToFalse()
    {
        levelUp = false;
    }
}
