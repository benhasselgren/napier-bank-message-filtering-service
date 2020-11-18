# Test Cases

## Unit Tests

### Data System Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
UTD1|Check loadData() with file|1. Create a csv file with correct message fomratting<br>2. Call loadData()|"Filepath"|List<strings> returned with correct length and format|||
UTD2|Check loadData() with no file|1. Create a csv file with correct message fomratting<br>2. Call loadData()|""|Exception with message(File does not exist)|||
UTD3|Check saveData() with file|1. Create list of messages <br>2. Call saveData()|"Filepath"|A json file is created with correct output|||
UTD4|Check saveData() with no file|1. Create list of messages <br>2. Call saveData()|""|Exception with message(Filepath needs to be provided)|||
UTD5|Check saveData() with empty list of messages|1. Create empty list of messages <br>2. Call saveData()|EmptyList|Exception with message(No messages to save)|||
UTD6|Check loadAbbreviations() returns list of abbreviations|1. Call loadAbbreviations()|N/A|List of abbreviations != empty|||

### Business System Logic Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
UTB1|Check processMessage() processes an sms message correctly|1. Create sms message <br>2. Call processMessage()|Message|An sms message with correct values|||
UTB2|Check processMessage() processes a se email message correctly|1. Create a se email nmessage <br>2. Call processMessage()|Message|A se email message with correct values|||
UTB3|Check processMessage() processes a sir email message correctly|1. Create a sir email message <br>2. Call processMessage()|Message|A sir email message with correct values|||
UTB4|Check processMessage() processes a tweet email message correctly|1. Create a tweet message <br>2. Call processMessage()|Message|A tweet email message with correct values|||
UTB5|Check addHashtag() adds a hashtag to a list|1. Create a string<br>2. Call addHashtag()|"#test"|A hahstag list containing "#test" with count value 1|||
UTB6|Check addHashtag() adds an existing hashtag to a list correctly|1. Create a string<br>2. Call addHashtag()|"#test"|A hahstags list containing "#test" with count value 2|||
UTB7|Check addHashtag() with empty string|1. Create a string<br>2. Call addHashtag()|""|Exception with message(Empty hashtag string)|||
UTB8|Check addSir() adds a sir to a list|1. Create two strings<br>2. Call addSir()|"99-99-99","Theft"|A sirs list containing sir with correct values|||
UTB9|Check addSir() with empty strings|1. Create two strings<br>2. Call addSir()|"",""|Exception with message(Empty sortcode or noi)|||
UTB10|Check addMention() adds a mention to a list|1. Create a string<br>2. Call addMention()|"@test"|A mentions list containing "@test"|||
UTB11|Check addMention() with empty string|1. Create a string<br>2. Call addMention()|""|Exception with message(Empty mention string)|||
UTB12|Check addUrl() adds a url to a list|1. Create a string<br>2. Call addUrl()|"https://www.test.com"|A quarantine list containing "https://www.test.com"|||
UTB13|Check addUrl() with empty string|1. Create a string<br>2. Call addUrl()|""|Exception with message(Empty url string)|||
UTB14|Check getHashtags() returns list of hashtags|1. Call getHashtags()|N/A|List of hashtags|||
UTB15|Check getSirs() returns list of sirs|1. Call getSirs()|N/A|List of sirs|||
UTB16|Check getMentions() returns list of mentions|1. Call getMentions()|N/A|List of mentions|||
UTB17|Check getQuarantineList() returns list of urls|1. Call getQuarantineList()|N/A|List of urls|||
UTB18|Check createMessage() returns an unprocessed email message correctly|1. Create an email message <br>2. Call createMessage()|"emailheader","emailbody"|A message with MessageType == EMAIL|||
UTB19|Check createMessage() returns an unprocessed sms message correctly|1. Create a sms message <br>2. Call createMessage()|"smsheader","smsheader"|A message with MessageType == SMS|||
UTB20|Check createMessage() returns an unprocessed tweet message correctly|1. Create a tweet message <br>2. Call createMessage()|"tweetheader","tweetbody"|A message with MessageType == TWEET|||
UTB21|Check getHandler() returns an email handler|1. Create an email message<br>2. Call getHandler()|Message|An email handler object|||
UTB22|Check getHandler() returns a sms handler|1. Create a sms message<br>2. Call getHandler()|Message|An sms handler object|||
UTB23|Check getHandler() returns a tweet handler|1. Create a tweet message<br>2. Call getHandler()|Message|An tweet handler object|||

> No unit tests needed for factory and facade class as methods used are more suited for integration testing.

### Presentation System Layer (GUI)
> No unit tests needed for this layer as methods used are more suited for integration testing. This is down to the design of the 3 layer model application.

## Integration Tests

### Data System Layer
> No integration tests needed for this layer as methods in this layer are integrated in the layer above.

### Business System Logic Layer
Test Case ID|Test Scenario|Test Steps|Test Data|Expected Results|Actual Results|Pass
------------|------------|------------|------------|------------|------------|------------|
ITB1|Check processMessage() processes an sms message correctly|1. Create sms message <br>2. Call processMessage()|"smsheader""smsbody"|An sms message with correct values|||
ITB2|Check processMessage() processes a se email message correctly|1. Create a se email nmessage<br>2. Call processMessage()|"seemailheader","seemailbody"|A se email message with correct values|||
ITB3|Check processMessage() processes a sir email message correctly|1. Create a sir email message<br>2. Call processMessage()|"siremailheader","siremailbody"|A sir email message with correct values|||
ITB4|Check processMessage() processes a tweet email message correctly|1. Create a tweet message<br>2. Call processMessage()|"tweetheader","tweetbody"|A tweet email message with correct values|||
ITB5|Check processMessage() with empty strings|1. Create two empty strings<br>2. Call processMessage()|"",""|Exception with message(Message missing text or header)|||
ITB6|Check processMessagesByFile() with file|1. Create a csv file with correct message fomratting<br>2. Call processMessagesByFile()|"Filepath"|A list of formatted messages|||
ITB7|Check processMessagesByFile() with no file|1. Call processMessagesByFile()|""|Exception with message(You need to provide a file to read from)|||
ITB8|Check saveMessages() with file|1. Create a processed message<br>2. Call saveMessages()|"Filepath"|A list of processed messages saved to a json file|||
ITB9|Check saveMessages() with no file|1. Call saveMessages()|""|Exception with message(You need to provide a file to save to)|||
ITB10|Check verifyMessage() with processed Message|1. Create a processed message<br>2. Call verifyMessage()|Message|A list of processed messages containing the processed message|||
ITB11|Check verifyMessage() with empty message|1. Call verifyMessage()|Empty Message|Exception with message(Message is empty)|||

### Presentation System Layer (GUI)
> Integration tests not a priority for this project.
