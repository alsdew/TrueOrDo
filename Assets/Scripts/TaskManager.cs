using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private Task[] allTasks;
    public Task[] list
    {
        get
        {
            if (allTasks == null || allTasks.Length == 0) {
                LoadAllTasks();
            }
            return allTasks;
        }
    }
    public Task take()
    {
        var index = Random.Range(0, list.Length);
        var task = list[index];
        removeTaskByIndex(index);
        return task;
    }

    private void removeTaskByIndex(int index)
    {
        if (allTasks.Length <= index || index < 0)
        {
            return;
        }

        int newIndex = 0;
        Task[] newArray = new Task[allTasks.Length - 1];

        for (int oldIndex = 0; oldIndex < allTasks.Length; oldIndex++)
        {
            if (oldIndex != index)
            {
                newArray[newIndex] = allTasks[oldIndex];
                newIndex++;
            }
        }
        allTasks = newArray;
    }

    private void LoadAllTasks()
    {
        allTasks = Resources.LoadAll<Task>("tasks");
    }
}
