using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "QuestionData" ,menuName = "QuestionData")]
public class QuizDataTable : ScriptableObject
{
    public List<Question> question;
}
