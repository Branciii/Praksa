import React from 'react';
import './App.css';
import NavBar from './Navbar';
import Form from './Form';
import StudentPicture from './StudentPicture';

function App() {
  return (
    <div className="App">
      <NavBar/>
      <Form/>
      <StudentPicture imagelink = "https://image.shutterstock.com/image-photo/portrait-asian-college-student-on-600w-84518011.jpg"></StudentPicture>
    </div>
  );
}

export default App;
