using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    public abstract bool run();
}

public class OpenDoor : Task
{
    public Door door;

    public OpenDoor(Door door)
    {
        this.door = door;
    }

    public override bool run()
    {
        Debug.Log("OpenDoor");
        door.OpenClose();
        return true;
    }
}

public class DoorOpen : Task
{
    public Door door;

    public DoorOpen(Door door)
    {
        this.door = door;
    }

    public override bool run()
    {
        Debug.Log("DoorOpen");
        return door.IsOpen();
    }
}

public class DoorClosed : Task
{
    public Door door;

    public DoorClosed(Door door)
    {
        this.door = door;
    }

    public override bool run()
    {
        Debug.Log("DoorClosed");
        return !door.IsOpen();
    }
}

public class BargeDoor : Task
{
    public Door door;

    public BargeDoor(Door door)
    {
        this.door = door;
    }

    public override bool run()
    {
        Debug.Log("BargeDoor");
        door.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(50, 50, 0), ForceMode.VelocityChange);
        return true;
    }
}

public class DoorUnlocked : Task
{
    public Door door;

    public DoorUnlocked(Door door)
    {
        this.door = door;
    }

    public override bool run()
    {
        Debug.Log("DoorUnlocked");
        return !door.IsLocked();
    }
}

public class MoveDoor : Task
{
    public Transform transform;

    public MoveDoor(Transform transform)
    {
        this.transform = transform;
    }

    public override bool run()
    {
        Debug.Log("MoveDoor");
        transform.position = new Vector3(-2, 2.5f, 0);
        return true;
    }
}

public class MoveRoom : Task
{
    public Transform transform;

    public MoveRoom(Transform transform)
    {
        this.transform = transform;
    }

    public override bool run()
    {
        Debug.Log("MoveRoom");
        transform.position = new Vector3(13, 2.5f, 0);
        return true;
    }
}