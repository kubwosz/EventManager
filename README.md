# EventManager
###### Repository made during team project organised by PGS Software.
A very simple application for creating, managing and getting informations about events.


App was made by 5 persons, during the semester, by polish students - that's why it is in polish.
Even the application has a lot of bugs and not working stuff, I don't plan to develop the app further.  
Backend side is very expanded, frontend side needs a lot of work - simmilar app
I'm developing now which is much more advanced - Event Support App.

## How to run this app?

### Backend server

#### You will need:
* Microsoft Visual Studio (eg. VS 2017 Community - free edition)

#### Steps to run:
* Go to *$\EventManager_Backend\EventManager* folder
* Open solution file *EventManager.sln* with VS
* In the *Package Manager Console* run command *update-database* (to open Package Manager Console go to top toolbar -> View -> Other Windows)
* Click the green button *IIS Express*
* This should open your browser with the backend app running on the localhost server, port 53711 (http://localhost:53711)

___

### Frontend server

#### You will need:
* Node.js
* Visual Studio Code - recommended
* Some terminal - Cmder recommended

#### Steps to run:
* Go to *$\EventManager_Frontend\event.manager.client* folder
* Open terminal in this folder (it is important to *npm* commands in the same folder as *package.json* file)
* Run *npm i* command, and wait until instalation ends
* Run *npm start*
* This should open your browser and open the application on the localhost server, port 3000 (http://localhost:3000)

___

### Some screens from the application

#### Event details page
![alt text](https://github.com/kubwosz/EventManager/blob/images/images/event_details.png)

___

#### Events to show page
![alt text](https://github.com/kubwosz/EventManager/blob/images/images/events.png)

___

#### New event page
![alt text](https://github.com/kubwosz/EventManager/blob/images/images/new_event.png)
