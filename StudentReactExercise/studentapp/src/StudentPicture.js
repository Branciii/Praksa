import React from 'react';
import './StudentPicture.css';

export default class StudentPicture extends React.Component {
    render(){
        return <img src={this.props.imagelink}/>
    }
}