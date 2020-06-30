import React from 'react';
import './Form.css';
import Button from './Button';
import FormInput from './FormInput';

export default class Form extends React.Component {
    state = {
        firstName : '',
        lastName : '',
    }

    change = e => {
        this.setState({
            [e.target.name] : e.target.value 
        });
    };

    onSubmit = (e) => {
        e.preventDefault();
        this.setState({
            firstName : '',
            lastName : '',
        });
        console.log(this.state);
    };

    render() {
        return(
            <form>
                <br /> 

                <FormInput
                    type = "text" 
                    name = "firstName"
                    placeholder = "First name "
                    value = {this.state.firstName} 
                    onChange = {e=>this.change(e)}
                ></FormInput>

                <br /> 

                <FormInput
                    type = "password"
                    name = "lastName"
                    placeholder = "Last name "
                    value = {this.state.lastName} 
                    onChange = {e=>this.change(e)}
                ></FormInput>

                <br /> 

                <Button id = 'formButton' buttonMessage='Submit' onClick = {e=> this.onSubmit(e)}></Button>
            </form>
        ); 
    }
}