import React from 'react';
import './AddNewBook.css';

export default class AddNewBook extends React.Component {
    state = {
        Title : '',
        Author : '',
        Year : ''
    }

    change = e => {
        this.setState({
            [e.target.name] : e.target.value 
        });
    };

    onSubmit = (e) => {
        e.preventDefault();
        this.setState({
            Title : '',
            Author : '',
            Year : ''
        });
        console.log(this.state);
    };

    render() {
        return(
            <div>
                <form>

                    <br /> 
                    <br /> 

                    <input
                        type = "text" 
                        name = "Title"
                        placeholder = "Book Title "
                        value = {this.state.Title} 
                        onChange = {e=>this.change(e)}
                    ></input>

                    <br /> 
                    <br /> 

                    <input
                        type = "text"
                        name = "Author"
                        placeholder = "Author"
                        value = {this.state.Author} 
                        onChange = {e=>this.change(e)}
                    ></input>

                    <br /> 
                    <br /> 

                    <input
                        type = "number"
                        name = "Year"
                        placeholder = "Year"
                        value = {this.state.Year} 
                        onChange = {e=>this.change(e)}
                    ></input>

                    <br /> 
                    <br /> 

                    <button id = 'formButton' onClick = {e=> this.onSubmit(e)}>Submit</button>
                </form>
            </div>
        ); 
    }
}