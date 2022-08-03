// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Algorithms

#region Sorted List and Dictionary

SortedList<int,int> sortedList=new SortedList<int, int>();

sortedList.Add(1,1);
sortedList.Add(2, 2);
sortedList.Add(3, 3);
sortedList.Add(4, 4);

SortedDictionary<int,int> sortedDictionary=new SortedDictionary<int, int>();

sortedDictionary.Add(1,1);
sortedDictionary.Add(2, 2);
sortedDictionary.Add(3, 3);
sortedDictionary.Add(4, 4);


//SortedList<TKey, TValue> uses less memory than SortedDictionary<TKey,TValue >.

//The SortedDictionary<TKey, TValue> generic class is a binary search tree with O(log n) retrieval, where n is the number of elements in the dictionary. In this, it is similar to the SortedList<TKey, TValue> generic class. The two classes have similar object models, and both have O(log n) retrieval.Where the two classes differ is in memory use and speed of insertion and removal:

//SortedDictionary<TKey, TValue> has faster insertion and removal operations for unsorted data, O(log n) as opposed to O(n) for SortedList<TKey, TValue>.

//If the list is populated all at once from sorted data, SortedList<TKey,TValue > is faster than SortedDictionary<TKey, TValue>.

#endregion

#region List Operation

var listWithCapacity = new List<int>(16);
listWithCapacity.Add(1);
listWithCapacity.Add(2);
listWithCapacity.Add(3);
listWithCapacity.Add(4);
listWithCapacity.Add(5);
listWithCapacity.Insert(5,6);

var listWithLessCapacity = new List<int>(4);

listWithLessCapacity.Add(1);
listWithLessCapacity.Add(2);
listWithLessCapacity.Add(3);
listWithLessCapacity.Add(4);
listWithLessCapacity.Add(5);
listWithLessCapacity.Insert(5,6);

//If Count is less than Capacity, this method is an O(1) operation. If the capacity needs to be increased to accommodate the new element, this method becomes an O(n) operation, where n is Count.
#endregion

#region Linked List Vs List

var normalList=new List<int>();
normalList.Add(1);
normalList.Add(2);
normalList.Add(3);
normalList.Insert(0,6);

var linkedList = new LinkedList<int>();

linkedList.AddFirst(1);

var current = linkedList.FindLast(1);

linkedList.AddAfter(current, 2);
current = linkedList.FindLast(2);
linkedList.AddAfter(current, 3);
linkedList.AddLast(6);

//LinkedList<T>.AddLast(item) constant time
//List<T>.Add(item) amortized constant time, linear worst case

//LinkedList<T>.AddBefore(node, item) constant time
//LinkedList<T>.AddAfter(node, item) constant time
//List<T>.Insert(index, item) linear time

#endregion

#endregion

#region Method Calls

#region OOP

#region Hiding Declarations

User user = new Customer();
Console.WriteLine(user.UserName);
Console.WriteLine("--------------");
//The Problem here is that we are violating liskov principle and base class will hide the parent class implementation
#endregion

#region Dispatching

var shapes = new List<IShape>()
{
    new Shape(),
    new Square(),
    new Shape(),
    new Square()
};

var echo = new Echo();

foreach (dynamic shape in shapes)
{
    echo.Do(shape);
}

Console.WriteLine("--------------");
shapes.ForEach(s => echo.Do(s));

Console.WriteLine("--------------");
//The Problem With OOP Languages like c# and Java is that method invocation is determined at the compile time. we can use dynamic invocation (dispatching) to determine the target type at runtime or use the visitor pattern.


#endregion

#region Calling Virtual Method in Constructor

//var child = new ChildClass();
//Gives Exception. 
//When an object written in C# is constructed, what happens is that the initializers run in order from the most derived class to the base class, and then constructors run in order from the base class to the most derived class.
//Also in .NET objects do not change type as they are constructed, but start out as the most derived type, with the method table being for the most derived type. This means that virtual method calls always run on the most derived type.
//When you combine these two facts you are left with the problem that if you make a virtual method call in a constructor, and it is not the most derived type in its inheritance hierarchy, that it will be called on a class whose constructor has not been run, and therefore may not be in a suitable state to have that method called.
//This problem is, of course, mitigated if you mark your class as sealed to ensure that it is the most derived type in the inheritance hierarchy - in which case it is perfectly safe to call the virtual method.

Console.WriteLine("--------------");
#endregion

#region Covarience-Contravarience

static void AddEmployee(Employee employee)
{
    Console.WriteLine($"Employee With Name {employee.Name} And Family {employee.Family} Added and Type {employee.GetType().ToString()}");
}

AddDelegate<Employee> employeeAddDelegate = AddEmployee;
AddDelegate<Manager> managerAddDelegate = employeeAddDelegate;

managerAddDelegate.Invoke(new Manager() { Name = "Babak", Family = "Taremi", ManagerId = 133 });
#endregion


#endregion

Console.ReadKey();


#endregion

#region OOP

#region Hiding Declaration

public class User
{
    public string UserName { get; set; } = "Base User Name";
}

public class Customer : User
{
    public string UserName { get; set; } = "Customer User Name";
}


#endregion

#region Dispatching

public interface IShape
{

}

public class Shape : IShape
{

}

public class Square : Shape
{

}

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


#endregion

#region Virtual Calls in Constructor

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

#endregion

#region Covarience-Contravarience

public delegate void AddDelegate<in TItem>(TItem item);

public class Employee
{
    public string Name { get; set; }
    public string Family { get; set; }
}

public class Manager : Employee
{
    public int ManagerId { get; set; }
}

#endregion

#endregion

#region Design Patterns

//Which Design Patterns Have you Used Frequently? Describe Them
//Describe Dependency Inversion Principal

public class SalaryCalculator
{
    public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
}

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

public interface ISalaryCalculator
{
    float CalculateSalary(int hoursWorked, float hourlyRate);
}

public class SalaryCalculatorModified : ISalaryCalculator
{
    public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
}

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

//What is the problem of the code below? refactor it to a better one
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

#endregion

#region CSharp

#region Garbage Collection

//What are the generations in C# Garbage Collections?
//Can control when garbage collection happens?
//Can you force GC to happen?
//What are the types of garbage collection modes?

#endregion

#endregion