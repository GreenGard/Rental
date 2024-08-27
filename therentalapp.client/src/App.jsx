import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './App.css';
import Home from './Components/Home'; 
import LogIn from './Components/LogIn';


function App() {
    return (
        <Router>
            <div>
                <nav>
                    <ul>
                        <li><Link to="/">Home</Link></li>
                        <li><Link to="/login">Login</Link></li>
                    </ul>
                </nav>

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<LogIn />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
