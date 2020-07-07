import React from 'react';
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import './App.css';

import Navbar from '././components/Navbar';
import PopularBooks from '././components/PopularBooks';
import Home from '././components/Home';
import AddNewBook from './components/AddNewBook';


function App() {
  return (
    <React.Fragment>

      <Router>
        <Navbar />

        <Switch>
          <Route path="/home" component={Home} />
          <Route path="/popular_books" component={PopularBooks} />
          <Route path="/add_new_book" component={AddNewBook} />
          <Route path='*' exact={true} component={Home} />
        </Switch>

      </Router>

    </React.Fragment>
  );
}

export default App;
