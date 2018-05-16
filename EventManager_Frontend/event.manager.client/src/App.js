import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import HomeNavbar from './components/Navbar';
import Event from './components/Event';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';
import NewEvent from './components/NewEvent';
import Home from './components/Home';
import NewLecture from './components/NewLecture';
import { BrowserRouter, Route, Switch } from 'react-router-dom';

class App extends Component {
render() {
  return (
            <div>
<HomeNavbar/>
    </div>
  );
}
}

export default App;
