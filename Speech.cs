using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Speech : MonoBehaviour
{
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        StartCoroutine(Speeches());
    }

    void Text(string chars = "") { text.text = chars; }

    [SerializeField] Reply[] speeches;
    [SerializeField] float letterTime = .05f;

    [SerializeField] Transform cam;
    [SerializeField] Transform playerSlot;
    [SerializeField] Transform fatherSlot;

    [SerializeField] GameObject hideOnClick;

    [SerializeField] bool outro = false;

    IEnumerator Speeches()
    {
        foreach (var speech in speeches)
        {
            cam.SetPositionAndRotation(speech.father ? fatherSlot.position : playerSlot.position, speech.father ? fatherSlot.rotation : playerSlot.rotation);
            yield return StartCoroutine(Talk(speech.speech));

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            hideOnClick.SetActive(false);
            yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
        }

        if (outro)
        {
            Destroy(FindObjectOfType<DontDestroy>().gameObject);
            Useful.LoadScene();
        }
        else Useful.LoadNextScene();
    }

    IEnumerator Talk(string chars)
    {
        talking = true;
        string display = "";

        foreach (var letter in chars)
        {
            if (stop) { stop = talking = false; Text(chars); yield break; }

            display += letter;
            Text(display);

            yield return new WaitForSeconds(letterTime);
        }

        talking = false;
        //string displayText = "";

        //foreach (var letter in text.Reverse())
        //{
        //    if (breakOut) { breakOut = false; yield break; }

        //    displayText = letter + displayText;
        //    console.text = displayText;

        //    yield return new WaitForSeconds(letterTime);
        //}
    }

    bool talking = false;
    bool stop = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && talking) stop = true;
    }

    [Serializable]
    struct Reply
    {
        //public enum Talker { /*General,*/ Player, Father }
        public bool father;
        public string speech;
    }
}