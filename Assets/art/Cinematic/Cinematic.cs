using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{

    public bool StartCine;

    public Text myText;
    public Text spactext;

    public Image blackImage;

    float a;
    float b;
    float aBlack = 1;

    void Start()
    {
        spactext.text = "Space to End";
        myText.text = "At the end of this fight to save your life you have been teleported to a safe place but unfortunately this place is also affected by the forces of darkness. Congratulations. You have won this battle against the darkness but the war against the forces of darkness is far from over. This battle was too easy. next time we will make your next battle against the forces of darkness to be impossible to win but that would be too boring to see. Enjoy this temporary victory, for the next occasion your battle will be a little more difficult than the previous one.Do not disappoint us, We will be watching you during your next battle.";
    }

    void Update()
    {
        StartCinematic();
        ContinueCinematic();
    }

    void StartCinematic()
    {
        if (!StartCine)
        {
            blackImage.color = new Color(0, 0, 0, aBlack -=Time.deltaTime*0.3f);
            if (aBlack<0)
            {
                StartCine = true;
            }
        }
    }

    void ContinueCinematic()
    {
        if (StartCine)
        {
            if (a <= 1)
            {
                myText.color = new Color(1, 1, 1, a += Time.deltaTime*0.15f);
            }
            else
            {
                a = 1;
                blackImage.color = new Color(0, 0, 0, aBlack -= Time.deltaTime*0.3f);
                if (aBlack <= -1f)
                {
                    aBlack = -1f;
                    spactext.color = new Color(1, 1, 1, b += Time.deltaTime * 0.2f);
                    if (Input.GetKeyDown(KeyCode.Space))
                        SceneManager.LoadScene("Menu");
                    if (b >= 1)
                        b = 1;
                }
                    
            }

            
        }


    }
}
