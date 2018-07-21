using System;

public static class Util
{
    public static int Map(float value, float toSource, float fromTarget, float toTarget)
    {
        return (int)Math.Ceiling(value / toSource * (toTarget - fromTarget) + fromTarget);
    }
}