# Evoution Strategy

## Objectives of evolution

- **Improving the usability and performance of the Napier Bank Message Filtering Application.**

- **Improving the maintainability and interoperability of the system.** 

## Evolution Process & Methods

### Planning
> The product owner will speak to the client, manager and development team to create the evolution cycles.

1. Perform a system quality assessment.
2. Declare the targets and goals that need to be achieved to maintain the application.
3. Plan a workflow for the execution of the cycles.
4. Assess the feasibility of the workflow. This could involve mingration costs, software costs, staff costs, deadlines and more.
5. Once the above has been complete, the project will begin, members will be assignes roles and tasks will be executed using an agile methodology (see below).

### Execution
> An agile methodology will be used to allow new features, changes, corrections and improvements to be made in the system.

1. A sprint meeting will be arranged to discuss what needs to be done in the cycle.
2. Tasks from the evolution cycles will be added to backlog. 
   - These tasks will include different types of maintenance and evolutions that will be applied the system. For example, a new archieture to replace a current architecture in a sub system which supports an increased degree of maintainability and interoperability for the system.
   - Tasks will be prioritised and assigned to different team members.
3. Tasks are executed by the development team .
   - Daily standups will occur to track progress.
   - **Re-engineering** will occur after tasks to ensure the modified/added software is easier to understand and change.
4. The process is repeated. until the evolution cycles are complete.

## Maintenance prediction

### Corrective - Maintenance to repair software faults
> There will be some areas of the application that will need to be corrected in the next development interations.

- One area that needs to be fixed is the way unprocessed message files are processed int the application. They are currently all processed in one go and then saved to a file of the users choice. This needs to be modified so every message in the file is displayed one by one on the GUI.

### Adaptive - Maintenance to adapt software to a different operating environment
> Changing a system so that it operates in a different environment (computer, OS, etc.) from its initial implementation.

- The app is only available for computers using a Windows OS. Future iterations should condsider developing a version that works on OSX systems to allow users with apple devices to run the application.
- Migrate to a database. Preferably a MONGODB database.

### Perfective - Maintenance to add to or modify the system’s functionality
> Modifying the system to satisfy new requirements.

- Allow the user to add abbreviations and other messaging processing criteria so messages can be processed in more depth. 

- An option to save the message metric information (trending list, etc.) to a file.

- A more attractive and informative GUI that incormporates UX methodologies.

## Predicted Maintenance Costs

### Factors affecting costs
- The developers of this application have no contractual responsibility for maintenance so there is no incentive to design for future change.
- Any staff brought in for maintenance may be inexperienced and have limited knowledge of the domain.
- Ageing sofwtare will have high support costs.
