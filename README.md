[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-brightgreen.svg?style=flat-square)](https://makeapullrequest.com)

# Algorithms

## Sorted List vs Sorted Dictionary
 
Given the two snippet codes below, what are key diffrences between SortedList<T> And SortedDictionary<T> ?

```csharp
SortedList<int,int> sortedList=new SortedList<int, int>();

sortedList.Add(1,1);
sortedList.Add(2, 2);
sortedList.Add(3, 3);
sortedList.Add(4, 4);

```
```csharp
SortedDictionary<int,int> sortedDictionary=new SortedDictionary<int, int>();

sortedDictionary.Add(1,1);
sortedDictionary.Add(2, 2);
sortedDictionary.Add(3, 3);
sortedDictionary.Add(4, 4);
```

## Sorted List vs Sorted Dictionary Answer
SortedList<TKey, TValue> uses less memory than SortedDictionary<TKey,TValue >.

The SortedDictionary<TKey, TValue> generic class is a binary search tree with O(log n) retrieval, where n is the number of elements in the dictionary. In this, it is similar to the SortedList<TKey, TValue> generic class. The two classes have similar object models, and both have O(log n) retrieval.Where the two classes differ is in memory use and speed of insertion and removal

SortedDictionary<TKey, TValue> has faster insertion and removal operations for unsorted data, O(log n) as opposed to O(n) for SortedList<TKey, TValue>.

If the list is populated all at once from sorted data, SortedList<TKey,TValue > is faster than SortedDictionary<TKey, TValue>.
## List Operations

Given two lists with different capacities, if we run them, what is the memory complexity diffrence between these two?

```csharp
var listWithCapacity = new List<int>(16);

listWithCapacity.Add(1);
listWithCapacity.Add(2);
listWithCapacity.Add(3);
listWithCapacity.Add(4);
listWithCapacity.Add(5);
listWithCapacity.Insert(5,6);
```

```csharp
var listWithLessCapacity = new List<int>(4);

listWithLessCapacity.Add(1);
listWithLessCapacity.Add(2);
listWithLessCapacity.Add(3);
listWithLessCapacity.Add(4);
listWithLessCapacity.Add(5);
listWithLessCapacity.Insert(5,6);
```
## List Operation Answer

If Count is less than Capacity, this method is an O(1) operation. If the capacity needs to be increased to accommodate the new element, this method becomes an O(n) operation, where n is Count.

## Link vs LinkedList

Given a List<T> and LinkedList<T> , what are the time complexity diffrences for different Operations between these two?

```csharp
var normalList=new List<int>();
normalList.Add(1);
normalList.Add(2);
normalList.Add(3);
normalList.Insert(0,6);
```

```csharp
var linkedList = new LinkedList<int>();

linkedList.AddFirst(1);

var current = linkedList.FindLast(1);

linkedList.AddAfter(current, 2);
current = linkedList.FindLast(2);
linkedList.AddAfter(current, 3);
linkedList.AddLast(6);
```
## List vs LinkedList Answer

LinkedList<T>.AddLast(item) constant time

List<T>.Add(item) amortized constant time, linear worst case

LinkedList<T>.AddBefore(node, item) constant time

LinkedList<T>.AddAfter(node, item) constant time

List<T>.Insert(index, item) linear time
## 
# OOP
## OOP-Question 1

Imagine two classes blew. Customer class is child of User class. What will print in the console output?

```csharp
public class User
{
    public string UserName { get; set; } = "Base User Name";
}
```

```csharp
public class Customer : User
{
    public string UserName { get; set; } = "Customer User Name";
}

```

```csharp
User user = new Customer();
Console.WriteLine(user.UserName); //Output?
```
## OOP-Question 1-Answer
It will print "Base User Name"

The Problem here is that we are violating liskov principle and base class will hide the child class implementation.

## OOP-Question 2
What is the default behavior of C# language in term of dispatching?

Imagine the Inheritence hierarchy of the classes below

```csharp
public interface IShape
{

}

public class Shape : IShape
{

}

public class Square : Shape
{

}
```

we have an Echo class with Do method that writes something on console based on the type of class.

```csharp
public class Echo
{
    public void Do(IShape shape)
    {
        Console.WriteLine("IShape Type");
    }

    public void Do(Shape shape)
    {
        Console.WriteLine("Shape Type");
    }

    public void Do(Square square)
    {
        Console.WriteLine("Square Type");
    }
}

```

we generate a list of shapes like this.

```csharp
var shapes = new List<IShape>()
{
    new Shape(),
    new Square(),
    new Shape(),
    new Square()
};

var echo = new Echo();

```

If we call the Do method on Echo class with these two different ways, what will be the output?

```csharp
shapes.ForEach(s => echo.Do(s));
```

```csharp
foreach (dynamic shape in shapes)
{
    echo.Do(shape);
}
```
## OOP- Question 2- Answer

First one will print IShape Method on Do , second one will print the respective types of each classes. First one is called "Static Dispatching" second one is called "Dynamic Dispatching"

The Problem With OOP Languages like c# and Java is that method invocation is determined at the compile time. we can use dynamic invocation (dispatching) to determine the target type at runtime or use the visitor pattern.
## OOP- Question 3

Imagine two classes with inheritence hierarchy below.

```csharp
public class BaseClass
{
    public BaseClass()
    {
        Print();
    }

    public virtual void Print()
    {
        Console.WriteLine("From Base Class");
    }
}
```

```csharp
public class ChildClass : BaseClass
{
    private readonly string _declaration;
    public ChildClass()
    {
        _declaration = "I am a child!";
    }
    public override void Print()
    {
        Console.WriteLine(_declaration.ToLower());
    }
}
```

what will happen if we construct the ChildClass like below?

```csharp
var child = new ChildClass();
```
## OOP-Question 3-Answer

Gives Exception. 

When an object written in C# is constructed, what happens is that the initializers run in order from the most derived class to the base class, and then constructors run in order from the base class to the most derived class.

Also in .NET objects do not change type as they are constructed, but start out as the most derived type, with the method table being for the most derived type. This means that virtual method calls always run on the most derived type.

When you combine these two facts you are left with the problem that if you make a virtual method call in a constructor, and it is not the most derived type in its inheritance hierarchy, that it will be called on a class whose constructor has not been run, and therefore may not be in a suitable state to have that method called.
##
# Design Patterns
## Design Patterns- Question 1

Describe Dependency Inversion Principal


## Design Pattern- Question 2
Given the code below. What seems to be the problem?

```csharp
public class SalaryCalculator
{
    public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
}
```

```csharp
public class EmployeeDetails
{
    public int HoursWorked { get; set; }
    public int HourlyRate { get; set; }
    public float GetSalary()
    {
        var salaryCalculator = new SalaryCalculator();
        return salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
    }
}
```
## Design Patterns-Question 2-Answer

It violates dependency inversion principle. We Can modify the code like below

```csharp
public interface ISalaryCalculator
{
    float CalculateSalary(int hoursWorked, float hourlyRate);
}
```

```csharp
public class SalaryCalculatorModified : ISalaryCalculator
{
    public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
}
```

```csharp
public class EmployeeDetailsModified
{
    private readonly ISalaryCalculator _salaryCalculator;
    public int HoursWorked { get; set; }
    public int HourlyRate { get; set; }
    public EmployeeDetailsModified(ISalaryCalculator salaryCalculator)
    {
        _salaryCalculator = salaryCalculator;
    }
    public float GetSalary()
    {
        return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
    }
}
```
## Design Patterns- Question 3

What is the problem of the code below? refactor it to a better one

```csharp
public class Deposit
{
    public decimal Amount { get; set; }
    public int UserId { get; set; }

    public Deposit(decimal amount, int userId)
    {
        var checkResult = this.CheckDepositValidity().GetAwaiter().GetResult();

        if (!checkResult)
            throw new InvalidOperationException("Deposit is not valid for this user");

        Amount = amount;
        UserId = userId;
    }

    private async Task<bool> CheckDepositValidity()
    {
        //Do Some I/O Checking

        return true;
    }
}
```
## Design Patterns- Question 3- Answer

Calling an async operation and waiting it in constructor is a bad idea. We can use factory method to modify the code like below

```csharp
public class DepositModified
{
    public decimal Amount { get; set; }
    public int UserId { get; set; }

    private DepositModified(decimal amount, int userId)
    {
        Amount = amount;
        UserId = userId;
    }

    public static async Task<DepositModified> CreateDepositAsync(decimal amount, int userId)
    {
        //Some I/O Check

        return new DepositModified(amount, userId);
    }
}
```
##
# Csharp
## Garbage Collection
What are the generations in C# Garbage Collections?

Can control when garbage collection happens?

Can control when garbage collection happens?

What are the types of garbage collection modes?

##  Types
What is the difference between value type and reference type?

How value types are compared and how reference types are compared?

Are value types immutable?

what is the usage of ```in``` keyword? is it beneficial to use it for reference types?

## Threads and Async Operations

what is the diffrence between ```ThreadPool.QueueWorkItem``` and ```new Thread().Start()``` ?

Does ```Task.Run()``` creates new thread everytime?

what code does compiler generates when you use ```await``` keyword?

what is the purpose of ```ConfigureAwait(false)``` method in ```Task``` class?

what is the difference between ```Task.WaitAll()``` and ```Task.WhenAll()``` ?

##CLR

what is CLR? what benefits does it have?

Do you need NET for compiling C# code?

how can you load a DLL written in C++ and use its methods in C# ?
##
# ASP NET Core

Briefly describe a request life cycle in ASP NET Core (what happens when you call an ASP NET Core endpoint from browser?)

In previous versions of ASP NET Core , we had ```UseMVC()``` middleware, microsoft decided to remove it and added a new middleware called ```UseRouting()``` . What was the purpose of this action?

We know that ASP NET Core is a multi-thread application (a thread is opened based on each request). What is the benefit of using ```async``` in an ASP NET Core application?

ASP NET Core is cross platform. Which means that you can host it in a linux server behind nginx of windows server behind IIS. How is ASP NET Core hosting different from old ASP NET?

What happens when you inject a scoped service in a singleton service?

Imagin an interface with multiple implementations. Based on a certain situation we need to get a certain implementation. How can we do that?

Can you use controllers in depenency injection in ASP NET Core?
##
# DDD

What is the definition of ```Domain``` in DDD?

What are the types of ```Sub Domains``` in DDD?

What is the Difference between ```Sub Domain``` and ```Bounded Context``` ?

When Refactoring a legacy application , how can you use its old features without making your new code dirty?

What is the difference between Application Layer and Domain Layer?

in Old N-Tier applications , dependencies are from out layer to core layer, but in Clean Arc , dependencies are completely reveresed. What is the benfit of it?

Why the Domain should have no dependencies and be isolated?

Why DDD suggests that you don't use generic repository?

What is the specification pattern?
## 
# Microservice

What are the benefits of Microservice Architecture?

What Are the types of comminucations in Microservices?

What does High Cohesion means in Microservices?

What is the benefit of Health Checks API in ASP NET Core?

How can you manage to handle client applications when you have multiple services ?

Imagine a service is not responding, from logs we checked that it has restarted and takes time to comes up. How can you prevent other services from bombing this service with requests while it is loading?

How can you manage logs and trace a request in microservice Architecture?

What are the advantages and disadvantages of ```grpc``` ?

What is Saga pattern? What is the usage of it?

What is the Actor Model?

Have you used application runtime managements like Dapr?
