import React from 'react';
import HomeNavbar from './components/navbar';
import NewLecture from './components/newLecture';
import Home from './components/home';
import NewEvent from './components/newEvent';
import ShowEvents from './components/listEvents';
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
                      <Route exact path="/NewLecture" component={NewLecture}/>
                      <Route exact path="/ShowEvents" component={ShowEvents}/>

                  </Switch>
          </Router>
      </div>
    );
  }
}

export default App;
