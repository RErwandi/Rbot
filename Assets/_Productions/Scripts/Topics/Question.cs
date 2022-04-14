using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "Question", menuName = "Rbot/Question")]
public class Question : ScriptableObject
{
    public string questionName;
    public List<Answer> answers = new List<Answer>();
}