using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{

    [System.Serializable]
    public enum idiom
    {
        portuguese,
        english,
        french
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj;
    public Image profileSprite;
    public TextMeshProUGUI speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    // [HideInspector] public bool isShowing;
    private bool _isShowing;
    public bool IsShowing { get => _isShowing; set => _isShowing = value; }
    private int index;
    private string[] _sentences;

    public static DialogueControl instance;

    // Primeiro life cycle - Inicia antes do Start
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _isShowing)
        {
            NextSentence();
        }
    }

    // Coroutine
    IEnumerator TypeSentence()
    {
        foreach (char letter in _sentences[index].ToCharArray())
        {
            // Criar texto com cada letra da frase
            speechText.text += letter;

            // Define tempo para cada letra aparecer
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // Pular fala
    public void NextSentence()
    {
        // Mostrou o texto completo
        if (speechText.text == _sentences[index])
        {
            if (index < _sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                _sentences = null;
                _isShowing = false;
            }
        }
    }

    // Cta to show speech
    public void Speech(string[] sentences)
    {
        if (!_isShowing)
        {
            dialogueObj.SetActive(true);
            _sentences = sentences;
            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }
}
