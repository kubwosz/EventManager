import React from 'react';
import {render} from 'react-dom';
import {Label, FormControl, Button, ButtonToolbar} from 'react-bootstrap';
import HomeNavbar from './components/Navbar';
import Home from './components/Home';
import NewEvent from './components/NewEvent';
import {BrowserRouter as Router,Route, Switch } from 'react-router-dom';

class App extends React.Component {
  render() {
    return (
      <div className="App">
          <HomeNavbar/>
          <Router>
                  <Switch>
                      <Route exact path="/" component={Home}/>
                  </Switch>
          </Router>


      </div>
    );
  }
}

export default App;
