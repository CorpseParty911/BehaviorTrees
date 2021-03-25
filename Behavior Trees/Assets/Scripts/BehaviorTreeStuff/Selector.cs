using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    Task[] children;

    public Selector(Task[] children)
    {
        this.children = children;
    }

    public override bool run()
    {
        foreach (Task child in children)
            if (child.run())
                return true;
        return false;
    }
}
