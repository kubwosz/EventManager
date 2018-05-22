import React from 'react';
import HomeNavbar from './components/Navbar';
import NewLecture from './components/NewLecture';
import Home from './components/Home';
import NewEvent from './components/NewEvent';
import ShowEvents from './components/ShowEvents';
import EditEvent from './components/EditEvent';
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
                      <Route exact path="/EditEvent" component={EditEvent}/>
                      <Route exact path="/EditEvent/:id" component={EditEvent}/>

                  </Switch>
          </Router>
      </div>
    );
  }
}

export default App;
