using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //Game Time
    public float m_MatchTime = 0.0f;
    public float m_WaitTime = 0.0f;

    //Points
    int m_Points_Player1= 0,
        m_Points_Player2 = 0;

    //Event
    public delegate void GameStateDelegate( eGameState newGameState );
    public static event GameStateDelegate OnGameStateChanged;

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

    void Update( )
    {
        if(CurrentGameState == eGameState.Waiting )
        {
            if ( Input.GetKeyDown( KeyCode.Space ) )
            {
                StartGameState( eGameState.Playing );
            }
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

            if ( OnGameStateChanged != null )
            {
                OnGameStateChanged.Invoke( newGameState );
            }
        }
    }

    void OnGUI( )
    {
        GUI.Label( new Rect( 0, 0, 600, 200 ), CurrentGameState.ToString( ) + ":: Current Time - " + m_MatchTime + ":: Wait Time - " + m_WaitTime );
    }
}