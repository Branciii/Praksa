import React from 'react'
import { Navbar,Nav,Button,NavDropdown } from 'react-bootstrap';
import './Navbar.css';
import NavbarButton from './NavbarButton';

export default class NavBar extends React.Component{
    render(){
        return(
            <div>
                <div className="row">
                    <div className="col-md-12">
                        <Navbar bg="dark" variant="dark" expand="lg" sticky="top">
                            <Navbar.Brand>
                                <h1> Books </h1>
                            </Navbar.Brand>
                            <Navbar.Toggle aria-controls="basic-navbar-nav" />
                            <Navbar.Collapse id="basic-navbar-nav">
                                <Nav className="mr-auto">
                                    <div class = "row">
                                        <div class = "col-md-12">
                                
                                            <ul id = "navbar-lett" class="navbar-nav ml-auto align-middle">

                                                <li class="nav-item">
                                                    <Nav.Link href="/home"><NavbarButton buttonMessage = "Home"></NavbarButton></Nav.Link>
                                                </li>       

                                                <li class="nav-item">
                                                    <Nav.Link href="/publishers"><NavbarButton buttonMessage = "See Publishers"></NavbarButton></Nav.Link>
                                                </li>                   

                                                <li class="nav-item">
                                                    <Nav.Link href="/periods"><NavbarButton buttonMessage = "See Periods"></NavbarButton></Nav.Link>
                                                </li>

                                                <li class = "nav-item pt-3">
                                                    <NavDropdown title="Add New" id="basic-nav-dropdown">
                                                        <NavDropdown.Item href="/add_new_book">
                                                            Book
                                                        </NavDropdown.Item>
                                                    </NavDropdown>
                                                </li>

                                            </ul>
                                        </div>
                                    </div>
                                </Nav>
                                <div class = "row">
                                    <div class = "col-md-12">
                                        <input id ="InputSearchBooks" type="text" placeholder="Book Title / Book Author" className="mr-sm-2" />
                                        <Button id = "SearchBooksButton">Search Books</Button>
                                    </div>
                                </div>
                            </Navbar.Collapse>
                        </Navbar>
                        <br/>
                    </div>
                </div>
            </div>
        );  
    }
}