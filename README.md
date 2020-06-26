Applicability
Use Decorator

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

NOTE: please check constant before running application. 
