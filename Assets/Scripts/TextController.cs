using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextController : MonoBehaviour
{
    [SerializeField] private List<TextSequence> textSequences = new List<TextSequence>();
    [SerializeField] private TextMeshPro tmp = null;
    [SerializeField] private UnityEvent unityEvent = null;

    [SerializeField] private bool startOnStart = false;

    private void Start()
    {
        if (startOnStart == true)
        {
            StartText();
        }
    }

    public void StartText()
    {
        StartCoroutine(PlayText());
    }

    private IEnumerator PlayText()
    {
        foreach (TextSequence textSequence in textSequences)
        {
            if (textSequence.animTargetTime > 0) StartCoroutine(AnimateText(textSequence));
            yield return new WaitForSeconds(textSequence.displayTime);
        }
        unityEvent.Invoke();
        tmp.text = "";
    }

    private IEnumerator AnimateText(TextSequence textSequence)
    {
        char[] array = textSequence.displayText.ToCharArray();
        float timePerChar = textSequence.animTargetTime / array.Length;
        string displayText = "";
        for (int i = 0; i < array.Length; i++)
        {
            displayText += array[i];
            tmp.text = displayText;
            yield return new WaitForSeconds(timePerChar);
        }
    }
}

[Serializable]
public class TextSequence
{
    [Tooltip("Time that the message is displayed.")] public float displayTime = 3;
    [Tooltip("Text that is displayed")] public string displayText = "";
    [Tooltip("Animation target time")] public float animTargetTime = 2;
}