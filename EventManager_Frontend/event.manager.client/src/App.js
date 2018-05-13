import React, { Component } from 'react';
import './App.css';
import HomeNavbar from './components/Navbar';
import Event from './components/Event';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';
import NewEvent from './components/NewEvent';
import EditEvent from './components/EditEvent';
import { BrowserRouter, Route } from 'react-router-dom';

class App extends Component {
render() {
  return (
      <div className="App">
        <BrowserRouter>
          <div>
              <Route exact path='/' component={Event}/>
              <Route path='/editEvent' component={EditEvent}/>
          </div>
        </BrowserRouter>
      </div>
  );
}
}

export default App;
