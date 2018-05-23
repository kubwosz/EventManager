import React from 'react';
import HomeNavbar from './components/navbar/index';
import NewLecture from './components/newLecture/index';
import Home from './components/home/index';
import NewEvent from './components/newEvent/index';
import ShowEvents from './components/showEvents/index';
import NewReview from './components/newReview/index';
import EditEvent from './components/editEvent/index';
import EditLecture from './components/editLecture/index';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';
class App extends React.Component {
  render() {
    return (
      <div className="App">

          <HomeNavbar/>
          <Router>
                  <Switch>
                      <Route exact path="/" component={Home}/>
                      <Route exact path="/home" component={Home}/>
                      <Route exact path="/NewEvent" component={NewEvent}/>
                      <Route exact path="/NewLecture/:id" component={NewLecture}/>
                      <Route exact path="/ShowEvents" component={ShowEvents}/>
                      <Route exact path="/EditEvent/:id" component={EditEvent}/>
                      <Route exact path="/EditLecture" component={EditLecture}/>
                  </Switch>
          </Router>


      </div>
    );
  }
}

export default App;
