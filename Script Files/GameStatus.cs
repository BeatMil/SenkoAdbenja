using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //parameters
    [SerializeField] int currentCoinAtStart;
    [SerializeField] int currentCoin;
    [SerializeField] Text currentCoinUI;
    [SerializeField] int currentLife;
    [SerializeField] Text currentLifeUI;

    [SerializeField] GameObject heart;
    bool gameStart = false;

    //cache
    CameraMovement cameraMovement;
    new AudioBlock audio;
    CanvasHealth canvasHealth;

    //AsyncOperation loadGameoverScene;
    Vector3 heartPos = new Vector3(5, 5, 5);



    //Skills
    [SerializeField] bool zoomOutSkill = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnLevelWasLoaded(int level)
    {
        if (gameStart)
        {
            cameraMovement = FindObjectOfType<CameraMovement>();
        }
        audio = FindObjectOfType<AudioBlock>();
        currentCoinAtStart = currentCoin;
        if(SceneManager.GetActiveScene().name == "Stage05")
        {
            Debug.Log("BOSS LEVEL!");
        }
    }

    void Start()
    {
        gameStart = true;
        audio = FindObjectOfType<AudioBlock>();
        cameraMovement = FindObjectOfType<CameraMovement>();
        currentCoinUI.text = currentCoin.ToString();
        currentLifeUI.text = currentLife.ToString();
        Debug.Log("GameStatus started");
        canvasHealth = FindObjectOfType<CanvasHealth>();
        //loadGameoverScene = SceneManager.LoadSceneAsync("Gameover");
        //loadGameoverScene.allowSceneActivation = false;

        if (SceneManager.GetActiveScene().name == "Stage05")
        {
            Debug.Log("BOSS LEVEL!");
        }

        Instantiate(heart);

       
    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Gameover scene progress: " + loadGameoverScene.progress);
        if (cameraMovement != null)
        {
            if (zoomOutSkill)
            {
                cameraMovement.ZoomOut();
            }
            else
            {
                cameraMovement.ZoomIn();
            }
        }
    }

    public void getZoomOutSkill(bool key)
    {
        zoomOutSkill = key;
    }

    public void getCoin()
    {
        currentCoin += 1;
        if (currentCoin >= 10)
        {
            currentCoin = 0;
            currentLife += 1;
            audio.playPulsLifeSound();
            canvasHealth.runningHeart();
        }
        currentCoinUI.text = currentCoin.ToString();
        currentLifeUI.text = currentLife.ToString();
    }

    public void lossLife()
    {
        Debug.Log(gameObject.name + ".lossLife");
        currentLife -= 1;
        currentLifeUI.text = currentLife.ToString();

        currentCoin = currentCoinAtStart;
        currentCoinUI.text = currentCoin.ToString();
        canvasHealth.runningHeart();
    }

    public int getCurrentLife()
    {
        return currentLife;
    }

    public void resetGame()
    {
        Destroy(gameObject);
    }
}
