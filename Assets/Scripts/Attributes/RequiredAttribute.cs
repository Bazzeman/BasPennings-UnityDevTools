using System;
using UnityEngine;


/// <summary>
/// Required attribute
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
public class RequiredAttribute : PropertyAttribute { }
