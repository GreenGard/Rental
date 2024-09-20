import React from 'react';

function LogIn() {
    return (
        <div class="login-container">
            <h2>Logga in</h2>
            <form action="/login" method="post">
                <input type="text" name="username" placeholder="Anv�ndarnamn" required/>   
                <input type="password" name="password" placeholder="L�senord" required/>
                <input type="submit" value="Logga in"/>
                        </form>
                        <button class="google-btn">Logga in med Google</button>
                        <a class="signup-link" href="/signup">Skapa ett konto</a>

        </div>
    );
}

export default LogIn;
