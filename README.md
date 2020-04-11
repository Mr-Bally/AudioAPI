# AudioAPI
This is Web API designed to consume requests for the storage and retrieval of audio files. Written in .NET Core this was written to be a base implementation with the option to extend or modify depending on the purpose.

## Setup
The SQL scripts for the stored procedure and database schema are included in this project. Whilst the development work was done on a SQL Server Express server, the use of [Dapper](https://github.com/StackExchange/Dapper) will allow you to swap out to a vendor of your choice. Simply altering the connections strings and having the appropriate stored procedures and database should be enough to get started.

It is also worth noting that to save files to new directories requires the program to run with privileges else an exception will be thrown when attempting to write the audio file to the given path.

## Feedback
Like all my project, any constructive feedback is always welcome. Feel free to open pull requests or branch this project as you see fit.
