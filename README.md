Applicability- Use Decorator

To add responsibilities to individual objects dynamically and transparently, that is, without affecting other objects
For responsibilities that can be withdrawn
When extension by subclassing is impractical. Sometimes a large number of independent extensions are possible and would produce an explosion of subclasses to support every combination. Or a class definition may be hidden or otherwise unavailable for subclassing

The classes and objects participating in this pattern are:

Component   (LibraryItem)
defines the interface for objects that can have responsibilities added to them dynamically.
ConcreteComponent   (Book, Video)
defines an object to which additional responsibilities can be attached.
Decorator   (Decorator)
maintains a reference to a Component object and defines an interface that conforms to Component's interface.
ConcreteDecorator   (Borrowable)
adds responsibilities to the component.

https://www.dofactory.com/images/diagrams/net/decorator.gif

Application details 
Following tool and technologies used :
1. Visual studio 2017
2. C# 7.3
3. Asp.Net Core 2.1 Console application
4. XDOM - Which uses a builder design pattern
5. SOLID Principal
6. Decorator design pattern (Partial)

Artifacts
1. Employee.Assignment.sln
  1.1 Employee.Assignment - Contains fist problem statement  
  1.2 Employee.Assignment2 - Contains second problem staement
  1.3 Employee.Assignment1.UnitTest - Where able to complete unit test for couple of  class ony becuase of time constarain.
2. xmlfile.txt - Hold 2 files for both assignments.

Note:
1. Files attached having txt extension please change it .zip will open.
2. Assignment shared via google drive.
2. Place XML file at D drive else change file location at the constant file in both applications.
