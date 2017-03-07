Use the Singleton Pattern when: 

- There must be one and only one instance of a class
- The class must be accessible to clients
- The class should not require parameters as part of its construction 

When creating the instance is expensive, a Singleton can improve performance 


Singleton pattern breaks the single responsibility principle
------------------------------------------------------------

Management of object lifetime is a separate responsibility 
Adding this responsibility to a class with other responsibilities violates the Single Responsibility Principle (SRP) 
Using an IOC Container, a separate class can be responsible for managing object lifetimes 




