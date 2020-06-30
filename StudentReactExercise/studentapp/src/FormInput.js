import React from 'react';
import './FormInput.css';

export default class FormInput extends React.Component {
    render(){
        return (
        <input
        type = {this.props.type}
        name = {this.props.name}
        placeholder = {this.props.placeholder}/>)
    }
}