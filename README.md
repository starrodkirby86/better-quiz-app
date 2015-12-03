# Better Quiz App
Because Jeopardy presentations suck. :^)
## Preamble

One particularly large issue with many quiz applications freely available for personal use is the lack of modularity that the quiz user has; essentially, quiz building applications are rather restrictive with their customization. Our application aims to solve this problem.

## Goals and Design Philosophy

Piggybacking on the preamble, our ultimate goal with this project is to give users the ability to tailor their quiz experience to suit their needs. For example, in our application, users will be able to determine the pass rate percentage for their quizzes. Additionally, questions (which are randomly pulled from a pre-existing question pool) can be assigned a particular "weight" to them. Allow me to elaborate--when questions are pulled from the question pool, an algorithm is created to make the questions pulled random. Basically, questions can be assigned a "weight" so that they can be randomly chosen more or less often than other questions in the question pool.

I am sure you can see where I am going with this, and I would much rather not create a description for each feature, so this brief list of user-customizable features will have to suffice:

* Pass rate percentage
* Weight randomization
* Question count
* Question time limit
* User name

## Requirements

You are probably wondering what tools we are using to create our project. Thankfully, the list is relatively short. The application is built on Unity, a game creation engine and IDE. This application does all the heavy-lifting for us by allowing us to easily create powerful applications that directly compiles code and links it to a user-interface creation studio. The programming language we are using is C#. The heart of the application's functionality has been built from the ground-up in C#, and the only C# library used was the extensive C# library provided by Unity. Finally, XML was used to create files which contain the questions and everything pertinent to them, such as their correct answers and randomization weight. These XML files are then parsed in C#.

## Potential Future Features

Though we have reached most of our goals that we originally set, there will inevitably be some features that we would love to see implemented into our application.

* Multiplayer
* User-set timer

Everyone loves sharing their experiences with other people, so wouldn't it be wonderful if two or more people could take a quiz at the same time and compare their scores? Unfortunately, we were unable to implement multiplayer into our application in time for the presentation, but who knows? Perhaps we may continue working on this project in the future, and if so, this feature will definitely be one of our top priorities.

A user-set timer suffered the same fate as multiplayer--namely, we did not implement it in time for the presentation. Nevertheless, allowing users to adjust the amount of time they had on each question could only add to the modularity of our application and give users more control over their quizzing experience.