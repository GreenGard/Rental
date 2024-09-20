import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './App.css';
import Home from './Components/Home';
import LogIn from './Components/LogIn';
import SignUp from './Components/SignUp';  // Korrekt import

function App() {
    return (
        <Router>
            <div>
                <nav className="navbar">
                    <ul className="nav-list">
                        <li className="nav-item"><Link to="/">Home</Link></li>
                        <li className="nav-item"><Link to="/login">Login</Link></li>
                        <li className="nav-item"><Link to="/signup">Sign up</Link></li>
                    </ul>
                </nav>

                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/login" element={<LogIn />} />
                    <Route path="/signup" element={<SignUp />} />  {/* Korrekt användning */}
                </Routes>
            </div>
        </Router>
    );
}

export default App;
