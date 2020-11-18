# Test Plan

## Objectives and Scope

### Objectives
- Check that whether the application is working as expected without any error or bugs in real business environment.
- Verify the usability of the website. Are those functionalities convenient for user or not?

### Scope
- **In scope**
  - This project will focus on testing all the functions of the napier bank message filtering application. (In this case, this will require all 3 layers of the application to be tested).
  - Integration of functions will be tested to see that parts of the applications work together correctly.
- **Out of scope**
  - Nonfunctional testing (eg. softcases in use case diagarm) such as stress, scalability or response time will not be tested.
  - Hardware.
  - The GUI. Due to the limited time left on this project test methods in the presentation layer GUI will not be tested. This decision was made as tasks had to be prioritised and all the functionality of the application is in the business and data layers.

## Test Items, Tasks and Deliverables

### Test Items
Items|Version
------------|------------
Data system (Data Layer)|1.1
Business logic system (Business Layer)|1.1

## Tasks
Order|Task
------------|------------
1|Create the test plan/specification
2|Create the test cases
3|Perform test execution
4|Create a test summary report

### Deliverables
Document|
------------|
Test cases
Test Summary report

## Testing Methods

> In general a **Bottom-Up Integration Testing** approach will be applied.

### Unit Tests
- White box testing will be used to test indidual functions in each system layer. 

### Integration Tests
- Black box testing will be used to test multiple compontents together in each system layer.

## Environmental Needs

### Hardware
- A computer, mouse, keyboard and monitor.

### Software
- Windows 10 or later
- Visual Studio (Community Edition)
- Version 1.0 of the application solution or later.

### Tools
- Visual Studio Unit tests

## Test Schedule

> Please note: All member types refer to one person in this project

Order|Task|Members|Estimate Effort
------------|------------|------------|------------|
1|Create the test plan/specification|Test Designer|2 hours
2|Create the test cases|Test Designer, Test Administrator|3 hours
3|Perform test execution|Tester|10 hours
4|Create a test summary report|Tester|3 hours

## Possible Risks and Solutions
Risks|Solutions
------------|------------
A tester (team member) lacks required skills|Provide practice courses and tutorials to train member
The test plan does not allow for full test coverage of all the application|Amend test plan and add missing tests
The estimated project schedule is not long enough|Set up priority unit tests for each of the sub systems
