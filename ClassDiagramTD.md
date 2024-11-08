```mermaid

---
Title: Class Diagram Tower Defense
---

classDiagram

class MyClass{
    + Attribute     //public
    - attribute     //private
    + Operation()   //public
    - Operation()   //private
}


ChildClass --|> ParentClass

DependentClass ..> MyClass

MyClass <..> AnotherClass

```