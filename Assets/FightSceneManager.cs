using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{

    #region Game_Constants
    public int nbRound = 2;
    public float Time_limit = 100f;
    #endregion
    #region UI_Elements;
    public UnityEngine.UI.Text time_display;
    public PlayerManager p1manager , p2manager;
    #endregion
    #region private_members;
    float timestart;
    #endregion
    // Use this for initialization
    protected void Start () {
        timestart = Time.time;
	}

    // Update is called once per frame
    protected void Update ()
    {
        float timeConsumed = Time.time - timestart;

        if (timeConsumed < Time_limit)
        {
            time_display.text = string.Format("{0:0}", Time_limit - timeConsumed);
        }
        else
        {
            time_display.text = "0";
            time_display.color =Color.red;
            Fightover();
        }
    }

    public void Fightover()
    {
      
    }

   
}
