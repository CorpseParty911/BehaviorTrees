using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BehaviorTree : MonoBehaviour
{
    public Door door;

    Task task;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        buildBehaviorTree();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !started)
        {
            task.run();
            started = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void buildBehaviorTree()
    {
        Task[] tasks = new Task[2];

        tasks[0] = new DoorUnlocked(door);
        tasks[1] = new OpenDoor(door);
        Task sequence = new Sequence(tasks);

        tasks = new Task[2];
        tasks[0] = new DoorClosed(door);
        tasks[1] = new BargeDoor(door);
        Task sequence2 = new Sequence(tasks);

        tasks = new Task[2];
        tasks[0] = sequence;
        tasks[1] = sequence2;
        Task selector = new Selector(tasks);

        tasks = new Task[2];
        tasks[0] = new DoorOpen(door);
        tasks[1] = new MoveRoom(this.transform);
        sequence = new Sequence(tasks);

        tasks = new Task[3];
        tasks[0] = new MoveDoor(this.transform);
        tasks[1] = selector;
        tasks[2] = new MoveRoom(this.transform);
        sequence2 = new Sequence(tasks);

        tasks = new Task[2];
        tasks[0] = sequence;
        tasks[1] = sequence2;

        task = new Selector(tasks);
    }
}
