using System;

public class Father
{
    public virtual string InterestOn() // virtual allows child to override
    {
        return "I like to play Cricket";
    }
}

public class Son : Father
{
    public override string InterestOn()
    {
        return "Mobile Games";
    }
}
