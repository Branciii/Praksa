import React from 'react';
import './Home.css';

export default class Home extends React.Component {
    render(){
        return (
            <div class = "container">
                <div class = "row">
                    <div class = "col-5 rounded" id = "popular_books_title">
                        <h3>Popular Books</h3>
                    </div>
                    
                    <div class = "col-5 rounded offset-2" id = "new_books_title">
                        <h3>New Books</h3>
                    </div>
                </div>

                <div class = "row">
                    <div class = "col-5" id = "col_popular_books">
                        <div id = "book_border">
                            <div class = "row pt-4">
                                <div class = "col-12">
                                    <h5>9.9&#9733; The Little Prince</h5>
                                </div>
                            </div>

                            <div class = "row pt-1">
                                <div class = "col-12">
                                    <h5 id = "author"><i>Antoine de Saint-Exupéry </i></h5>
                                </div>
                            </div>
                        </div>

                        <div class = "row pt-5">
                            <div class = "col-12">
                                <h5>9.9&#9733; Harry Potter and the Philosopher's Stone</h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-12">
                                <h5 id = "author"><i>J. K. Rowling</i></h5>
                            </div>
                        </div>

                        <div class = "row pt-5">
                            <div class = "col-12">
                                <h5>9.7&#9733; The Hobbit</h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-12">
                                <h5 id = "author"><i>J. R. R. Tolkien</i></h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-4 offset-4">
                                <button id = "see_more_popular_books">See more</button>
                            </div>
                        </div>

                    </div>

                    <div class = "col-5 offset-2" id = "col_new_books">
                        <div class = "row pt-4">
                            <div class = "col-12">
                                <h5>9.7&#9733; The Order</h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-12">
                                <h5 id = "author"><i>Daniel Silva</i></h5>
                            </div>
                        </div>

                        <div class = "row pt-5">
                            <div class = "col-12">
                                <h5>9.8&#9733; Wonderscape</h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-12">
                                <h5 id = "author"><i>Jennifer Bell</i></h5>
                            </div>
                        </div>

                        <div class = "row pt-5">
                            <div class = "col-12">
                                <h5>9.7&#9733; My Garden World</h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-12">
                                <h5 id = "author"><i>Monty Don</i></h5>
                            </div>
                        </div>

                        <div class = "row pt-1">
                            <div class = "col-4 offset-4">
                                <button id = "see_more_new_books">See more</button>
                            </div>
                        </div>

                    </div>
                
                </div>
            </div>
            
        );
    }
}