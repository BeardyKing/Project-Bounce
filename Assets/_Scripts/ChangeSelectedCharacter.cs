using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSelectedCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh tm_text;
    char[] c_text;
    public bool positiveChange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
    
        if (positiveChange == true){
            c_text = tm_text.text.ToUpper().ToCharArray();
            if (c_text[0] >= 'A' && c_text[0] < 'Z'){
                c_text[0]++;
            }
            else{
                c_text[0] = 'A';
            }
        }
        else if(positiveChange == false){
            c_text = tm_text.text.ToUpper().ToCharArray();
            if (c_text[0] >= 'A')
            {
                c_text[0]--;
            }
            if(c_text[0] < 'A'){
                c_text[0] = 'Z';
            }
        }
        tm_text.text = c_text[0].ToString();

    }
}
