# Flight Paths 

![.NET Core](https://github.com/etni/interview-airmap/workflows/.NET%20Core/badge.svg)

This is a simple command line app that I wrote to solve a question I received on an interview.   

### Problem Description
Implement a class called AirMap with two methods:

* add_route(start,destination): adds a one way connection flight from start to destination
* print_all_routes(start,destination): prints all possible routes form start to destination irrespective of hops.

### Sample Input

Given the following routes, print the possible routes between airports C and C.

```
A ---> B
B ---> A
A ---> C
C ---> A
A ---> D
D ---> A
B ---> C
C ---> B
B ---> D
D ---> B
```
### Expected Output
```
C,A,B,D
C,A,D
C,B,A,D
C,B,D 
```

#### Instructions
This code will run on any platform supported by .net core.  Go to the src folder and execute:

```
dotnet run
```

Press any of the following keys A, Q, P at the prompt:
* A - Add to the routes
* Q - Query All Flight Paths between 2 airports
* P - Print all direct flights for an airport
* ESC to quit.

