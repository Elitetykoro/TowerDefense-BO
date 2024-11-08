```mermaid

//titel is optioneel
---
Title: Class Diagram Tower Defense
---

//geef aan dat je een class diagrm wil maken
classDiagram

//definieer je classes en bijhorende attributen en operaties
class MyClass{
    + Attribute     //public
    - attribute     //private
    + Operation()   //public
    - Operation()   //private
}


//geef alle relaties aan
//Overerving Relatie
ChildClass --|> ParentClass

//Dependancy relatie
DependentClass ..> MyClass

//2 richting relatie
MyClass <..> AnotherClass

```