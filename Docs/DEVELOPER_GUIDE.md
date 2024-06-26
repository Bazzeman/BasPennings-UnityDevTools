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
### Template 1
- **Description**: What this template does.
- **Usage**: How to use this template.
- **Example**: Provide a code example.

### Template 2
- **Description**: What this template does.
- **Usage**: How to use this template.
- **Example**: Provide a code example.

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