# DeptTechExercise
 Exercise for Dept recruitment process,

 These are my thoughts as I go though the exercise, some questions you may have may be answered here.
 -
 I started with creating a basic Console App in VS 2019.
 I dont have much planned as of creation, I considered TDD'ing my process, but decided against it due to time constraints.
 -
 Check the Commit History for a timeline of what I implemented.
 
 -
 
 First thing I wanted to do was to wrap the actual application in a While(!quit). 
 I decided go ahead and create a Server class which will serve as a manager for the app.
 For now I gave this class a method that returns false, IsRunning().
 I also wrote a few lines for when the app closes.

 -

 Before I started messing around with data I wanted to make sure that I could show it.
 I created a Writer class to do just this. It will also handle the user input.
 For the initial Writer class process, It needed to see the Server, For this I changed the Server into a basic, thread locked, singleton.
 I could have passed the server into the writer on construction, however I only want one server active. This will make future references to the server easier.

 For now the writer has a message when the app starts, and asks the user whether to close the app. I will change this to allow for multiple inputs, to allow the user to specify parameters for their API request.

 -

 So currently there is nothing seperating this from a basic console app, to change that im going to make a make a request to the server. My Idea for this first is not to mess around with any data, but to check for a response.
 I want to make a "Test Response" option on the user input and for now, display the response code. E.g 200 or 400.

 To handle API requests, I created the creativly named API Handler and API Requester classes.
 The Requester class will connect to the API and return its responses. 
 The Handler class will convert this to data models. It will also handle the user inputs, converting those into parameter data.

 -

 I wrote the code to get a response, and the code to display it. And hooray, it displays... (an error code).
 Luckily, it was an "internal server error". After manually checking the endponts in my browser, it seems that the beta endpoints failed. I changed the endpoint to another which worked and its working as intened.