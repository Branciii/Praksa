import React from 'react'
import { Navbar,Nav,NavDropdown,Button } from 'react-bootstrap';
import './Navbar.css';

export default class NavBar extends React.Component{

    render(){
        return(
            <div>
                <div className="row">
                    <div className="col-md-12">
                            <Navbar bg="dark" variant="dark" expand="lg" sticky="top">
                                <Navbar.Brand>Student Navbar</Navbar.Brand>
                                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                                <Navbar.Collapse id="basic-navbar-nav">
                                    <Nav className="mr-auto">
                                        <NavDropdown title="Student">
                                            <NavDropdown.Item>New Student</NavDropdown.Item>
                                            <NavDropdown.Item>Delete Student</NavDropdown.Item>
                                        </NavDropdown>
                                    </Nav>
                                    <div class = "row">
                                        <div class = "col-md-12">
                                            <input id ="InputSearchStudents" type="text" placeholder="Student" className="mr-sm-2" />
                                            <Button id = "SearchStudentsButton">Search Students</Button>
                                        </div>
                                    </div>
                                </Navbar.Collapse>
                            </Navbar>
                            <br />
                    </div>
                </div>
            </div>
        )  
    }
}