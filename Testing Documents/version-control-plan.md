# Version Control Plan with Github

## VCS
- A git version control system will be used for this project (Github in this project)

## Issues
- Issues will outline features and goals that need to be completed to create the application.
- All use cases will be created as issues

## Branches
> Branches will be used to allow the option of multiple people to work on this project at the same time. Every time a new feature needs to be implemented a feature branch must be created off the develop branch. Once the feature had been implemented and is fully up to date with the develop branch can it then be merged to the develop branch.
- **Master Branch**
  - Contains only complete version of the application (V1.0, etc.)
  - Only merged to when sprint iterations are full complete and code been implemented and tested.
- **Develop Branch**
  - Contains a more frequently updated version of the code. Used for building off and implementing new features to during new sprints.
- **Feature branches**
  - Everytime a new feature or functionality is being implemented will a feature branch be created. This allows multiple people to work on the same project without clashing.
  
## Zube
> Connected to the github repository
- Zube will be used to manage tickets, team members and sprints throughout the project.
- All github issues are displayed in a kanban board in zube.
- Each issue will have correlating tickets describing what needs to be done to complete the issue.
- Tickets will have team members assigned to. Priority and other attributes will also be added to these tickets to ensure deadlines are met.

## Travis Ci
> Connected to the github repository
- Travis will be used for continuous integration
- It will build the application and will then run all the unit and integration tests.
- Once all the tests are complete, It will then upload code coverage reports to CodeCov
