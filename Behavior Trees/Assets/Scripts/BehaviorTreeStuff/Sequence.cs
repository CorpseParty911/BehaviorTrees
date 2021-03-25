using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    Task[] children;

    public Sequence(Task[] children)
    {
        this.children = children;
    }

    public override bool run()
    {
        foreach (Task child in children)
            if (!child.run())
                return false;
        return true;
    }
}
