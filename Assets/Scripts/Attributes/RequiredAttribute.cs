using System;
using UnityEngine;

/// <summary>
/// Required attribute
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class RequiredAttribute : PropertyAttribute 
{ 
    public string Description { get; set; } = "Required!"; 
}