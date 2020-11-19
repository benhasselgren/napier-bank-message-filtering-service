# Test Summary

## Unit Tests Results

### Data System Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
UTD1|Check loadData() with file|1. Create a csv file with correct message fomratting<br>2. Call loadData()|"Filepath"|List<strings> returned with correct length and format|As Expected|Pass|
UTD2|Check loadData() with no file|1. Create a csv file with correct message fomratting<br>2. Call loadData()|""|Exception with message(File does not exist)|As Expected|Pass|
UTD3|Check saveData() with file|1. Create list of messages <br>2. Call saveData()|"Filepath"|A json sequence is created|As Expected|Pass|
UTD4|Check saveData() with no file|1. Create list of messages <br>2. Call saveData()|""|Exception with message(Filepath needs to be provided)|As Expected|Pass|
UTD5|Check saveData() with empty list of messages|1. Create empty list of messages <br>2. Call saveData()|EmptyList|Exception with message(No messages to save)|As Expected|Pass|
UTD6|Check loadAbbreviations() returns list of abbreviations|1. Call loadAbbreviations()|N/A|List of abbreviations != empty|As Expected|Pass|

### Business System Logic Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
UTB1|Check processMessage() processes an sms message correctly|1. Create sms message <br>2. Call processMessage()|Message|An sms message with correct values|As Expected|Pass|
UTB2|Check processMessage() processes a se email message correctly|1. Create a se email nmessage <br>2. Call processMessage()|Message|A se email message with correct values|As Expected|Pass|
UTB3|Check processMessage() processes a sir email message correctly|1. Create a sir email message <br>2. Call processMessage()|Message|A sir email message with correct values|As Expected|Pass|
UTB4|Check processMessage() processes a tweet email message correctly|1. Create a tweet message <br>2. Call processMessage()|Message|A tweet email message with correct values|As Expected|Pass|
UTB5|Check addHashtag() adds a hashtag to a list|1. Create a string<br>2. Call addHashtag()|"#test"|A hahstag list containing "#test" with count value 1|As Expected|Pass|
UTB6|Check addHashtag() adds an existing hashtag to a list correctly|1. Create a string<br>2. Call addHashtag()|"#test"|A hahstags list containing "#test" with count value 2|As Expected|Pass|
UTB7|Check addHashtag() with empty string|1. Create a string<br>2. Call addHashtag()|""|Exception with message(Empty hashtag string)|As Expected|Pass|
UTB8|Check addSir() adds a sir to a list|1. Create two strings<br>2. Call addSir()|"99-99-99","Theft"|A sirs list containing sir with correct values|As Expected|Pass|
UTB9|Check addSir() with empty strings|1. Create two strings<br>2. Call addSir()|"",""|Exception with message(Empty sortcode or noi)|As Expected|Pass|
UTB10|Check addMention() adds a mention to a list|1. Create a string<br>2. Call addMention()|"@test"|A mentions list containing "@test"|As Expected|Pass|
UTB11|Check addMention() with empty string|1. Create a string<br>2. Call addMention()|""|Exception with message(Empty mention string)|As Expected|Pass|
UTB12|Check addUrl() adds a url to a list|1. Create a string<br>2. Call addUrl()|"https://www.test.com"|A quarantine list containing "https://www.test.com"|As Expected|Pass|
UTB13|Check addUrl() with empty string|1. Create a string<br>2. Call addUrl()|""|Exception with message(Empty url string)|As Expected|Pass|
UTB14|Check getHashtags() returns list of hashtags|1. Call getHashtags()|N/A|List of hashtags|As Expected|Pass|
UTB15|Check getSirs() returns list of sirs|1. Call getSirs()|N/A|List of sirs|As Expected|Pass|
UTB16|Check getMentions() returns list of mentions|1. Call getMentions()|N/A|List of mentions|As Expected|Pass|
UTB17|Check getQuarantineList() returns list of urls|1. Call getQuarantineList()|N/A|List of urls|As Expected|Pass|
UTB18|Check createMessage() returns an unprocessed email message correctly|1. Create an email message <br>2. Call createMessage()|"emailheader","emailbody"|A message with MessageType == EMAIL|As Expected|Pass|
UTB19|Check createMessage() returns an unprocessed sms message correctly|1. Create a sms message <br>2. Call createMessage()|"smsheader","smsheader"|A message with MessageType == SMS|As Expected|Pass|
UTB20|Check createMessage() returns an unprocessed tweet message correctly|1. Create a tweet message <br>2. Call createMessage()|"tweetheader","tweetbody"|A message with MessageType == TWEET|As Expected|Pass|
UTB21|Check getHandler() returns an email handler|1. Create an email message<br>2. Call getHandler()|Message|An email handler object|As Expected|Pass|
UTB22|Check getHandler() returns a sms handler|1. Create a sms message<br>2. Call getHandler()|Message|An sms handler object|As Expected|Pass|
UTB23|Check getHandler() returns a tweet handler|1. Create a tweet message<br>2. Call getHandler()|Message|An tweet handler object|As Expected|Pass|

> No unit tests needed for factory and facade class as methods used are more suited for integration testing.

### Presentation System Layer (GUI)
> No unit tests needed for this layer as methods used are more suited for integration testing. This is down to the design of the 3 layer model application.

## Integration Tests Results

### Data System Layer
> No integration tests needed for this layer as methods in this layer are integrated in the layer above.

### Business System Logic Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
ITB1|Check processMessage() processes an sms message correctly|1. Create sms message <br>2. Call processMessage()|"smsheader""smsbody"|An sms message with correct values|As Expected|Pass|
ITB2|Check processMessage() processes a se email message correctly|1. Create a se email nmessage<br>2. Call processMessage()|"seemailheader","seemailbody"|A se email message with correct values|As Expected|Pass|
ITB3|Check processMessage() processes a sir email message correctly|1. Create a sir email message<br>2. Call processMessage()|"siremailheader","siremailbody"|A sir email message with correct values|As Expected|Pass|
ITB4|Check processMessage() processes a tweet message correctly|1. Create a tweet message<br>2. Call processMessage()|"tweetheader","tweetbody"|A tweet message with correct values|As Expected|Pass|
ITB5|Check processMessage() with empty strings|1. Create two empty strings<br>2. Call processMessage()|"",""|Exception with message(Missing text or header)|As Expected|Pass|
ITB6|Check processMessagesByFile() with file|1. Create a csv file with correct message fomratting<br>2. Call processMessagesByFile()|"Filepath"|A list of formatted messages|As Expected|Pass|
ITB7|Check processMessagesByFile() with no file|1. Call processMessagesByFile()|""|Exception with message(You need to provide a file to read from)|As Expected|Pass|
ITB8|Check saveMessages() with file|1. Create a processed message<br>2. Call saveMessages()|"Filepath"|A list of processed messages saved to a json file|As Expected|Pass|
ITB9|Check saveMessages() with no file|1. Call saveMessages()|""|Exception with message(You need to provide a file to save to)|As Expected|Pass|
ITB10|Check verifyMessage() with null message|1. Call verifyMessage()|null|Exception with message(Message is empty)|As Expected|Pass|

### Presentation System Layer (GUI)
> Integration tests not a priority for this project.

## Analysis 

Overall around 93% of the data and business layer methods have been tested. This value comes from the code coverage reports that are generated when the application is built and integrated on travis. A badge shows this value in the README file. 

The reason only 93% of the methods have been tested is because there was some issues identified with the application while testing. These issues were solved and involved a couple methods being added to the business layer. These new methods have not been tested yet but will be in the next iteration.

However, the testing has shown the application works the way it should with one exception. (Messages read in from a file are not displayed one by one but instead all processed and then saved at once.) Apart from this small exception, the application passed all the tests and is very robust.
