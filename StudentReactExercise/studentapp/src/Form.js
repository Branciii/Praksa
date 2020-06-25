import React from 'react';
import './Form.css';

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

                <input
                    name = "firstName"
                    placeholder = "First name "
                    value = {this.state.firstName} 
                    onChange = {e=>this.change(e)}
                />

                <br /> 

                <input
                    name = "lastName"
                    placeholder = "Last name "
                    value = {this.state.lastName} 
                    onChange = {e=>this.change(e)}
                />

                <br /> 

                <button onClick = {e=> this.onSubmit(e)}>Submit</button>

            </form>
        ); 
    }
}