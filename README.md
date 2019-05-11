# Dibware.Salon
An open source salon booking application. Anyone is welcome to contribute. 
The purpose of this project is to build a web based salon booking application.

## Current Travis-Build Status
**Branches:**
* master branch 
[![Build Status](https://api.travis-ci.com/dibley1973/Dibware.Salon.svg?branch=master)](https://travis-ci.com/dibley1973/Dibware.Salon) 
[![Sonarcloud Status](https://sonarcloud.io/api/project_badges/measure?project=Core%3ADibware.Salon&metric=alert_status)](https://sonarcloud.io/dashboard?id=Core%3ADibware.Salon)


## Tooling
Before embarking on development it is suggested that SonarLint is installed.

## Coding Standards
The code is to be written in a manner that allows easy readability, modification and extension. Clean code practices should be followed. Refactoring should be considered as part of the main development of features. Small classes and short methods are encouraged. Unit tests for classes is mandatory.

## Testing

### Unit Testsing
Classes should be protected with adequate cover to test all likely code paths and a suitable range of values.

#### Unit Testing Naming
It is expected that all test should be in the `GivenSomething_WhenSomethingElse_ThenSoSomethingOther`, for example:
```
    ///<summary>Given the constructor when passed null hours then throws exception.</summary>
    [Test]
    public void GivenConstructor_WhenPassedNullHours_ThenThrowsException()
    {
        // ARRANGE
        const Hours nullHours = null;

        // ACT
        Action actual = () => new Duration(nullHours, ValidMinutes);

        // ASSERT
        actual.Should().Throw<ArgumentNullException>("because a null hours is not permitted");
    }
```

### Reference
Refer to the book **Refactoring** by *Martin Fowler*
