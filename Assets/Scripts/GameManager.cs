using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // UI
    public GameObject uiTitle;
    public GameObject uiPlay;
    public GameObject uiGameOver;
    // score
    int score;
    int scoreTop;
    public Text textScore;
    public Text textScoreTop;
    // player
    PlayerMove player;
    Rigidbody rbPlayer;
    // state
    public enum State
    {
        Title,
        Play,
        GameOver
    }
    public State state;
    // AD
    GoogleAD ad;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // UI
        uiTitle.SetActive(true);
        uiPlay.SetActive(false);
        uiGameOver.SetActive(false);
        // stop time
        //Time.timeScale = 0f;
        // score
        score = 0;
        scoreTop = PlayerPrefs.GetInt("ScoreTop", 0);
        textScore.text = "" + score;
        textScoreTop.text = "Top:" + scoreTop;
        // player
        player = FindObjectOfType<PlayerMove>();
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.useGravity = false;
        // state
        state = State.Title;
        // AD
        ad = FindObjectOfType<GoogleAD>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // sound
        SoundManager.instance.PlaySound(SoundManager.instance.audioClick, player.transform.position, 1f);

        // UI
        uiTitle.SetActive(false);
        uiPlay.SetActive(true);
        uiGameOver.SetActive(false);
        // start time
        //Time.timeScale = 1f;
        // state
        state = State.Play;
        // use gravity for player
        rbPlayer.useGravity = true;
    }

    public void AddScore()
    {
        if (state == State.Play)
        {
            // sound
            SoundManager.instance.PlaySound(SoundManager.instance.audioScore, player.transform.position, 0.5f);
            score++;
            textScore.text = "" + score;
        }
        
    }

    public void GameOver()
    {
        // sound
        SoundManager.instance.PlaySound(SoundManager.instance.audioGameOver, player.transform.position, 1f);
        // UI
        uiTitle.SetActive(false);
        uiPlay.SetActive(false);
        uiGameOver.SetActive(true);
        // state
        state = State.GameOver;
        // top score
        TopScore();
    }

    void TopScore()
    {
        // new top score
        if (score > scoreTop)
        {
            // sound
            SoundManager.instance.PlaySound(SoundManager.instance.audioFanfare, player.transform.position, 1f);
            // top score
            scoreTop = score;
            textScoreTop.text = "Top:" + scoreTop;
            PlayerPrefs.SetInt("ScoreTop", scoreTop);
        }
    }

    public void ShowAD()
    {
        // sound
        SoundManager.instance.PlaySound(SoundManager.instance.audioGameOver, player.transform.position, 1f);
        
        // AD is loaded
        if (!ad.isFailToLoadAD)
        {
            // show AD
            ad.ShowAD();
        }
        // AD is failed to load
        else
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}
