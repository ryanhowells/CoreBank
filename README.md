
Over the next few iterations we will be adding the following features
Create a transaction enrichment pipeline - we want to categorise the transactions
Adding OWBank connection - We will now accept users that bank with OWBank
Weekly data refreshes - For all connected users we want to update their data every week

How would you ensure these features fit into the system you have started to build?

Transaction enrichment pipeline - I would ensure this fit's into the system through following the same architecture and design pattern,
as it will be enriching the transactions made by users, it is important to understand the types of transactions being made, hence leading
on to the next feature categorising the transactions. 

Categorise transactions - Transactions are currently returning a json field of merchant, so it would be possible to categorise the transactions
based on merchant. For example merchant's like costa coffee, starbucks, greggs, etc. could be categorised to a category called 'catering'. 

Adding OWBank connection = In my project I made a generic API request method in the UserService that will take a URL, so it would be
simple to make the request to OWBank, the only change that I would need to make is to add a new OWBankDto and allow the response to be
serialized by JsonConvert into this Dto. 

Accept users that bank with OWBank - When adding users that bank with OWBank, we would need a Bank table adding that links with the user table
to specify exactly what bank that they are with, in the future it might become apparent that we will be accepting users from other banks. So
adding a BankId on the User table and a whole bank table representing the information from the bank.

Weekly data refreshes - A weekly data refresh could be accomplished by creating a processor that is set to run once a week at a certain time,
this could be made to make a request to an API that would bring back all updated data.

For all connected users, update their data every week - Previous to the prior feature, another processor could be made which will be ran once
a week at a specfic time that again makes a request for the connected users data, which will then be updated.
