# Developer Guide

## Table of Contents
1. [Introduction](#introduction)
2. [Utilities](#utilities)
3. [Properties](#properties)
4. [Script Templates](#script-templates)
5. [Other Features](#other-features)
6. [Usage Examples](#usage-examples)
7. [Best Practices](#best-practices)
8. [Contributing](#contributing)

## Introduction
Provide a brief overview of the document and its purpose.

## Utilities
### Singleton class
The Singleton pattern ensures that only one instance of a class exists throughout the application's lifecycle, providing a global point of access to that instance.

#### Usage
- Inherit from the Singleton base class. 
- Override any necessary methods (e.g., Awake) to customize behavior if needed.

#### Example
```csharp
using UnityEngine;

public class MyManager : Singleton<MyManager>
{
    public int a = 10;

    protected override void Awake()
    {
        // Always call base class Awake to ensure singleton behavior
        base.Awake();
    }
}
```
```csharp
using UnityEngine;

public class MyScript : MonoBehaviour
{
    private void Start() {
        // Console will output 10
        Debug.Log(MyManager.Instance.a);
    }
}
```

## Properties
### Property 1
- **Description**: What this property does.
- **Usage**: How to use this property.
- **Example**: Provide a code example.

### Property 2
- **Description**: What this property does.
- **Usage**: How to use this property.
- **Example**: Provide a code example.

## Script Templates
Script templates are used to improve workflow and are a way to make sure that developers use the same coding conventions for scripts. Script templates can be used when creating a new script by right clicking inside the assets folder and navigating to create/code/.
![image](https://github.com/Bazzeman/Project-Vortex-Showcase/assets/110249979/13b2a761-f0fa-4d39-b1c4-e3651dcb3304)


### MonoBehaviour template
This template removes the unused imports and the Update loop. It also adds a note explaining the difference between the Update and the FixedUpdate loops.
```csharp
using UnityEngine;

#ROOTNAMESPACEBEGIN#
/// <summary>
/// #NAME#
/// </summary>
public class #SCRIPTNAME# : MonoBehaviour
{
    void Start()
    {
        #NOTRIM#
    }

    // Update() - A continueos loop for running visual based code. - Uses Time.deltaTime.
    // FixedUpdate() - A continueos loop for running physics based code. - Uses Time.fixedDeltatime
}
#ROOTNAMESPACEEND#
```

### Enum template
A template for creating an empty Enum.
```csharp
#ROOTNAMESPACEBEGIN#
/// <summary>
/// #NAME#
/// </summary>
public enum #SCRIPTNAME#
{
    #NOTRIM#
}
#ROOTNAMESPACEEND#
```

### Singleton template
A template for creating a singleton class using the generic Singleton class explained in the [Utilities](#utilities) section.
```csharp
using UnityEngine;

#ROOTNAMESPACEBEGIN#
/// <summary>
/// #NAME#
/// </summary>
public class #SCRIPTNAME# : Singleton<#SCRIPTNAME#>
{
    // Access the instance of this class by using #SCRIPTNAME#.Instance.

    // Make sure to call base.Awake() when overriding Awake method.
    // protected override void Awake() => base.Awake();
}
#ROOTNAMESPACEEND#
```

## Other Features
### Feature 1
- **Description**: What this feature does.
- **Usage**: How to use this feature.
- **Example**: Provide a code example.

### Feature 2
- **Description**: What this feature does.
- **Usage**: How to use this feature.
- **Example**: Provide a code example.

## Usage Examples
Provide comprehensive usage examples that combine utilities, properties, templates, and other features.

## Best Practices
Outline any best practices for using the utilities, properties, templates, and other features.

## Contributing
Guidelines for contributing to the project, if applicable.
