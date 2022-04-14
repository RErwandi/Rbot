using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "Answer", menuName = "Rbot/Answer")]
public class Answer : ScriptableObject
{
    public string answerName;
    public List<string> answerTopics = new List<string>();
}
