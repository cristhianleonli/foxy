using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

enum ObjectTag
{
    Player
}

public class GameController : MonoBehaviour
{
    private PlayerController player;
    private HealthBar healthBar;
    private float killWaitTime = 1;
    private float killCooldown = 0;
    private bool canGetDamaged = true;
    private int playerMaxHealth = 4;
    private int playerHealth = 4;

    private Cinemachine.CinemachineVirtualCamera camera;
    private Cinemachine.CinemachineFramingTransposer transposer;

    public static GameController Instance { get; private set; }

    public GameObject diamondsContainer;
    public TextMeshProUGUI diamondText;
    private int diamondCounter = 0;
    private int maxDiamonds = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        healthBar = FindObjectOfType<HealthBar>();
        camera = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
        transposer = camera.GetCinemachineComponent<Cinemachine.CinemachineFramingTransposer>();
        
        healthBar.SetMaxHealth(playerMaxHealth);
        healthBar.TopUp();

        maxDiamonds = diamondsContainer.transform.childCount;
        UpdateDiamondCounter();
    }

    private void Update()
    {
        transposer.m_ScreenY = player.transform.position.y < 0 ? 0.5f : 0.85f;

        if (killCooldown > 0)
        {
            canGetDamaged = false;
            killCooldown -= Time.deltaTime;
        } else
        {
            canGetDamaged = true;
        }
    }

    public void PlayerGotDamage()
    {
        if (canGetDamaged == false) return;
        
        killCooldown = killWaitTime;
        playerHealth -= 1;

        healthBar.SetHealth(playerHealth);
        CameraShake.Instance.ShakeCamera(5f, 0.1f);

        if (playerHealth == 0)
        {
            // TODO: Play hurt animation
            Invoke("ReloadScene", 0.5f);
        }
    }

    public void PlayerDidGetDiamond()
    {
        diamondCounter += 1;
        UpdateDiamondCounter();
    }

    public void PlayerDidGetCherry()
    {
        if (playerHealth == playerMaxHealth) return;
        playerHealth += 1;
        healthBar.SetHealth(playerHealth);
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void UpdateDiamondCounter()
    {
        diamondText.text = $"{diamondCounter}/{maxDiamonds}";
    }
}
