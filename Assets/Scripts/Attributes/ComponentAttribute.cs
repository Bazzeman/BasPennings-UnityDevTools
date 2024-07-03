using System;

/// <summary>
/// Component attribute
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class ComponentAttribute : Attribute
{
    public string Name { get; private set; } = null;
    public string Description { get; private set; } = null;

    public ComponentAttribute(string name) => Name = name;
    public ComponentAttribute(string name, string description) : this(name) => Description = description;
}