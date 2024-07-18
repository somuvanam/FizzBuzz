# FizzBuzz Web Application

This is a FizzBuzz web application developed in C# using .NET Core 8.0, applying SOLID principles, Dependency Injection, Factory Design Pattern, and unit tests with NUnit and Moq.

## Introduction
This application processes an array of values and returns results based on the FizzBuzz rules:
1. If the value is a multiple of 3, it outputs "Fizz".
2. If the value is a multiple of 5, it outputs "Buzz".
3. If the value is divisible by both 3 and 5, it outputs "FizzBuzz".
4. If the value is non-numeric or not divisible by 3 or 5, it outputs relevant messages.

## How to Run
1. Clone the repository:
    ```bash
    git clone https://github.com/somuvanam/FizzBuzz
    ```
2. Navigate to the project directory:
    ```bash
    cd FizzBuzzApp
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
visual studio 2022

4. Run the project:
    ```bash
    dotnet run
    ```
visual studio 2022

## How to Test
Testing APIs using tools like Postman  is a common practice to verify their functionality.

## API Endpoints
- `POST /fizzbuzz`
  - Request Body: An array of strings.
  - Response: An array of FizzBuzzResult objects.

## Example
Request:
```json
["1", "3", "5", "15", "A", "23"]
