using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class GameManager : MonoBehaviour
{
    public Button nextTurnButton;
    public TextMeshProUGUI categoryText;
    public TextMeshProUGUI messageText;
    public GameObject background;

    public float rotateSpeed = 240f;
    private GameMode gameMode = new GameMode();

    private TaskManager tasks;

    private void Awake()
    {
        
    }
    void Start()
    {
        tasks = new TaskManager();
        nextTurnButton.onClick.AddListener(Turn);
    }

    void Update()
    {
        rotateBackground();
    }

    public void Turn() {
        if (gameMode.isChange) {
            return;
        }

        gameMode.next();
        var task = tasks.take();
        messageText.text = adaptadeToGender(task.message);
    }
 
    public string adaptadeToGender(string message) {
        Regex maleRegex = new Regex(@"\[(?<f>[^\]]+)\]");
        Regex femaleRegex = new Regex(@"\((?<m>[^\)]+)\)");

        if(gameMode.isMale) {
            return femaleRegex.Replace(maleRegex.Replace(message, ""), "${m}");
        }
        
        return maleRegex.Replace(femaleRegex.Replace(message, ""), "${f}");
    }

    public void rotateBackground() {
        if (gameMode.check(GameMode.TO_MALE)) {
            background.transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

            if(background.transform.rotation.z > -0.1){
                gameMode.next();
            }
        } 

        if (gameMode.check(GameMode.TO_FEMALE)) {
            background.transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);

            if(background.transform.rotation.z < -0.99){
                gameMode.next();
            }
        } 
    }
}
