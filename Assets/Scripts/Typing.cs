using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.TextCore.Text;

public class Typing : MonoBehaviour
{
    public string[] dialogues;
    public int dialogueIndex = 0;
    int charIndex = 0;

    public AudioSource sound;

    public TextMeshPro text;

    float delay = 0.0375f;
    float timer;

    bool active = true;

    void Awake()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueIndex <= dialogues.Length - 1)
        {
            char[] characters = dialogues[dialogueIndex].ToCharArray();
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                timer = 0;
                if (charIndex <= characters.Length - 1)
                {
                    if (active)
                    {
                        text.text += characters[charIndex];
                        charIndex++;
                    }
                }
                else
                {
                    active = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                charIndex = 0;
                if (!active)
                {
                    if (dialogueIndex < dialogues.Length - 1)
                    {
                        text.text = "";
                        dialogueIndex++;
                        active = true;
                    }
                }
                else
                {
                    active = false;
                    text.text = dialogues[dialogueIndex];
                }
            }
        }

        if (active)
        {
            if (!sound.isPlaying)
                sound.Play();
            else if (sound.time != 0)
                sound.UnPause();
        }
        else
        {
            sound.Pause();
        }
    }
}
