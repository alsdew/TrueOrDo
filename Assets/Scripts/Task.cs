using System;
using UnityEngine;

public enum CategoryType {
    TRUTH = 1,
    ACTION = 2,
}

[CreateAssetMenu(fileName = "Task", menuName = "Task", order = 51)]
public class Task : ScriptableObject
{
    [SerializeField]
    public CategoryType category = CategoryType.TRUTH;
    [SerializeField]
    public string message;
    [SerializeField]
    public bool withTimer = false;

    public bool isTruth {
        get {
            return category == CategoryType.TRUTH;
        }
    }
}