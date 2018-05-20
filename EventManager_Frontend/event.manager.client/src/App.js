<<<<<<< HEAD
import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import HomeNavbar from './components/Navbar';
import Event from './components/Event';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';
import NewEvent from './components/NewEvent';
import NewLecture from './components/NewLecture';
import NewReview from './components/NewReview';
import { BrowserRouter, Route } from 'react-router-dom';
=======
import React from 'react';
import HomeNavbar from './components/Navbar/index';
import NewLecture from './components/NewLecture/index';
import Home from './components/Home/index';
import NewEvent from './components/NewEvent/index';
import ShowEvents from './components/ShowEvents/index';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';
>>>>>>> ad5bb47af8f0c9bb6cc20c5af16e9e68a834392e

class App extends React.Component {
  render() {
    return (
      <div className="App">
<<<<<<< HEAD
        <BrowserRouter>
          <div>
              <Route path='/newEvent' component={NewEvent}/>
              <Route path='/newLecture' component={NewLecture}/>
              <Route path='/newReview' component={NewReview}/>
              <Route exact path='/' component={Event}/>
          </div>
        </BrowserRouter>
=======
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
>>>>>>> ad5bb47af8f0c9bb6cc20c5af16e9e68a834392e
      </div>
    );
  }
}

export default App;
