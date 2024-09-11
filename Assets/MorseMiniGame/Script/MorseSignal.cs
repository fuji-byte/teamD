/* using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MorseSignal : MonoBehaviour
{
    public  Text sample;

    public static char test;
    public static string output;
    public static string question;
    public int i;
    public static string inserted;
    public static int len;
    public static bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        inserted="";
        output="";
        sample.text="";
        question="-----------------------";
    }

    // Update is called once per frame
    void Update()
    {
       sample.text = string.Format(output);

if(string.Equals(sample.text, question)){
    clear=true;
}
        }

    public static void MorseInput(char input){
        test = input;
        inserted += test;
        output=inserted;
    }
    }
 */
 using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MorseSignal : MonoBehaviour
{
    public Text sample;

    public static char test;
    public static string output;
    public static string question;
    public int i;
    public static string inserted;
    public static int len;
    public static bool clear = false;
    public GameObject targetObject;
    public GameObject targetObject2;
    public static bool morseGameFinished = false;
    //public GameObject targetObject3;

    // Start is called before the first frame update
    void Start()
    {
        inserted = "";
        output = "";
        sample.text = "";
        question = "---------------------------";
    }

    // Update is called once per frame
    void Update()
    {
        if(TaskLogic.rdm == 2){

            sample.text = string.Format(output);

            if (string.Equals(sample.text, question)) 
            {
                sample.text="クリア！";
                if(morseGameFinished == false){
                    GenerateLevels.TaskCleared ++;
                    morseGameFinished = true;
                    TaskLogic.taskWaiting = true;
                    targetObject.SetActive(false);
                    targetObject2.SetActive(false);
                }
            }
        }
    }

    public static void MorseInput(char input)
    {
        if(TaskLogic.rdm == 2){
            test = input;
            inserted += test;
            output = inserted;
        }
    }
}