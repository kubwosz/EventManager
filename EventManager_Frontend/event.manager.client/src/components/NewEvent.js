import React from 'react';
import axios from 'axios';
import { withRouter } from 'react-router-dom'
import {BASE_URL} from '../constants';

class NewEvent extends React.Component {
    constructor()
    {
        super();
        this.state = {
            name: ''
        };
    }
}

export default withRouter(NewEvent);
