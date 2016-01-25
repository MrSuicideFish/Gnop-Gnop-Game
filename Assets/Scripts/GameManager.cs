using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Game Time
    float m_MatchTime = 0.0f;
    float m_WaitTime = 0.0f;

    //Points
    int m_Points_Player1= 0,
        m_Points_Player2 = 0;

    //State

    public eGameState CurrentGameState = eGameState.Waiting;
    public enum eGameState
    {
        Waiting,
        Playing
    }

    public void FixedUpdate( )
    {
        if(CurrentGameState == eGameState.Waiting )
        {
            m_WaitTime += Time.fixedDeltaTime;
        }else if(CurrentGameState == eGameState.Playing )
        {
            m_MatchTime += Time.fixedDeltaTime;
        }
    }

    public void StartGameState(eGameState newGameState )
    {
        if( newGameState != CurrentGameState )
        {
            //End current gamestate
            switch ( CurrentGameState )
            {
                case eGameState.Waiting:
                case eGameState.Playing:
                    break;
            }

            //Start new gamestate
            switch ( newGameState )
            {
                case eGameState.Waiting:
                case eGameState.Playing:
                    break;
            }

            //reset time
            m_WaitTime = 0;
            m_MatchTime = 0;
        }
    }
}