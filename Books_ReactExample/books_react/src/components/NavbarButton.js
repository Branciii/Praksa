import React from 'react';
import './NavbarButton.css';

export default class NavbarButton extends React.Component {
    render(){
        return <button>{this.props.buttonMessage}</button>;
    }
}