# Moscow Analysis

## Must Have
- The system will have a  WPF form that allows a user to input the three different types of message inputs: **SMS messages, Email messages and Tweets.**
- The system must be able to detect the message type and then process that message correctly depending on the type:
  - **SMS Messages:** Textspeak abbreviations must be expanded to their full form enclosed in “&lt;&gt;”, e.g. “Saw your message ROFL can’t wait to see you” becomes “Saw your message ROFL &lt;Rolls on the floor laughing&gt; can’t wait to see you”
  - Email messages are of two types: **Standard email messages** and **Significant Incident Reports** that comprise text reports from bank brunch managers concerning incidents of significance that happened during the working day, such as robberies, significant cash shortages, violent incidents. Both types may contain embedded URLs
    - **Standard email messages** will contain text. Any URLs contained in messages will be removed and written to a quarantine list and replaced by "&lt;URL Quarantined&gt;" in the body of the message.
    - **Significant Incident Reports** will have the Subject in the form “SIR dd/mm/yy” and will comprise a message body as above. The message body will begin with the following standard texts on the first two lines: 
    - **Sort Code:** 99-99-99
    - **Nature of Incident:** which will be one of the following (see over): 
    
      Types of indidents|
      ------------|
      Theft
      Staff Attack
      ATM Theft
      Customer Attack
      Staff Abuse
      Bomb Threat
      Terrorism
      Suspicous Incident
      Intelligence
      Cash Loss
    - Sort Code and Nature of Incident will be written to a SIR list. 
    - Any URLs contained in messages will be removed and written to a quarantine list and replaced by "&lt;URL Quarantined&gt;" in the body of the message.
  - **Tweets:** Textspeak abbreviations will be expanded (as in SMS messages above). Hashtags will be added to a hashtag list that will count the number of uses of each to produce a trending list. “Mentions”, i.e. embedded Twitter IDs will be added to a mentions list.
- The system will write every inputted message that has been processed correctly to a json file.
- At the end of an input session the system should display **the trending list, the list on Mentions and the SIR list.**

## Should Have
- The system will also be able to take it's input from an input file

## Could Have
- The system is connected to a databse and data can be written to the database instead of a json file.
- The system will allow other types of messages to be easily added by use of a form.
- The system will allow existing message types to be updated (eg. nature of incident types list can be added to)
