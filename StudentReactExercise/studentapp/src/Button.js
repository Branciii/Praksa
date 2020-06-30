import React from 'react';
import './Button.css';

export default class Button extends React.Component {
    render(){
        return <button>{this.props.buttonMessage}</button>;
    }
}