# Decorator-
Problem statement 

Problem 1: Please consider the below XML code snippet: -
<employees>
<employee>
<name>Mohan</name> <age>25</age> <designation>Developer</designation> </employee> <employee>
<name>Anitha</name> <age>40</age> <designation>Senior Developer</designation> </employee> </employees>
As part of your assignment, please write C# code to implement the following functionalities: -
• Read the XML file.
• Add new or delete existing employees.
• Write to the XML file.
Problem 2: Assume that the above solution (in Problem 1) has been provided to you as part of a third party component. Please extend the C# code to include a new address node and create the provision to add new or delete existing employees.
<employees>
<employee>
<name>Ram</name> <age>30</age> <designation>Software Engineer</designation> </employee> <employee>
<name>Rahim</name> <age>40</age> <designation>Senior Developer</designation> </employee> <employee>
<name>Robert</name>
<age>35</age> <designation>Project Manager</designation> <address>
<doorNo>20</doorNo> <street>Gandhi Road</street> <town>Chennai</town> <state>Tamil Nadu</state> </address> </employee> </employees>

Applicability
Use Decorator

To add responsibilities to individual objects dynamically and transparently, that is, without affecting other objects
For responsibilities that can be withdrawn
When extension by subclassing is impractical. Sometimes a large number of independent extensions are possible and would produce an explosion of subclasses to support every combination. Or a class definition may be hidden or otherwise unavailable for subclassing
